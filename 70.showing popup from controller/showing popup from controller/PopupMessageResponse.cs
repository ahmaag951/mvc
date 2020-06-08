using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using showing_popup_from_controller.Resources;

namespace showing_popup_from_controller
{
    [Serializable]
    public sealed class PopupMessageResponse
    {
        [Serializable]
        public enum PopupType
        {
            Success = 1,
            Error = 2,
            Alert = 3
        }

        private enum LabelType
        {
            Header,
            Message,
            Close
        }

        public const string TEMP_DATA_NAME = nameof(PopupMessageResponse);
        public PopupType Type { private set; get; }
        public string Header { private set; get; }
        public string Message { private set; get; }
        public string CloseLabel { private set; get; }

        private PopupMessageResponse()
        {
        }

        private static string GetElementOrDefault(string value, string defaultValue)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var defaultString = defaultValue;
                    return $"`{defaultString}`";
                }
                else
                {
                    return $"`{value.Replace("\r\n", "<br />").Replace("\n", "<br />")}`";
                }
            }
            catch
            {
                return "``";
            }
        }

        private static PopupMessageResponse Set(PopupType type, string message, string header = null, string closeLabel = null)
        {
            return new PopupMessageResponse
            {
                Type = type,
                Message = message,
                Header = header,
                CloseLabel = closeLabel
            };
        }

        public static PopupMessageResponse SetSuccess(string message, string header = null, string closeLabel = null)
        {
            return Set(PopupType.Success, message, header, closeLabel);
        }

        public static PopupMessageResponse SetError(string message, string header = null, string closeLabel = null)
        {
            return Set(PopupType.Error, message, header, closeLabel);
        }

        public static PopupMessageResponse SetAlert(string message, string header = null, string closeLabel = null)
        {
            return Set(PopupType.Alert, message, header, closeLabel);
        }

        public static IHtmlString GetPopupMessageHtmlString(PopupType type, string message, string header = null, string closeLabel = null)
        {
            switch (type)
            {
                case PopupType.Alert:
                    {
                        return new HtmlString($"PopupMessageAlert({GetElementOrDefault(header,  Resource.Alert_Header)}, {GetElementOrDefault(message, Resource.Alert_Message)}, {GetElementOrDefault(closeLabel, Resource.Close)});");
                    }
                case PopupType.Error:
                    {
                        return new HtmlString($"PopupMessageError({GetElementOrDefault(header, Resource.Error_Header)}, {GetElementOrDefault(message, Resource.Error_Message)}, {GetElementOrDefault(closeLabel, Resource.Close)});");
                    }
                case PopupType.Success:
                    {
                        return new HtmlString($"PopupMessageSuccess({GetElementOrDefault(header, Resource.Success_Header)}, {GetElementOrDefault(message, Resource.Success_Message)}, {GetElementOrDefault(closeLabel, Resource.Close)});");
                    }
                default:
                    {
                        return new HtmlString("");
                    }
            }
        }

        public IHtmlString GetPopupMessageHtmlString()
        {
            return GetPopupMessageHtmlString(Type, Message, Header, CloseLabel);
        }
    }
}