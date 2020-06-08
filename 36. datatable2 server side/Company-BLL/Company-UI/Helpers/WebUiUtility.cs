using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;
using System.Globalization;

namespace Company_UI.Helpers
{
    public static class WebUiUtility
    {        
        internal static string ParseErrors(System.Web.Mvc.ModelStateDictionary ModelState)
        {
            StringBuilder errors = new StringBuilder();
            foreach (var value in ModelState.Values)
                if (value.Errors.Count > 0)
                    foreach (var error in value.Errors)
                    {
                        if (string.IsNullOrEmpty(error.ErrorMessage))
                        {
                            Exception innerException = error.Exception;
                            while (innerException != null)
                            {
                                errors.AppendLine(innerException.Message);
                                innerException = innerException.InnerException;
                            }
                        }
                        else
                            errors.AppendLine(error.ErrorMessage);
                    }

            return errors.ToString();
        }        
    }
}