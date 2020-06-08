using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace showing_popup_from_controller
{
    public static class Helper
    {
        // Add the PopupMessageResponse class 
        public static void SetPopupMessageResponse(this Controller self, PopupMessageResponse popupMessageResponse)
        {
            // In the controller you can set or get the tempdatas
            self.TempData[PopupMessageResponse.TEMP_DATA_NAME] = popupMessageResponse;
        }
    }
}