using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebApp.Models;

namespace WebApp.Services
{
    public class SetTempDataMessage : Controller
    {
        public void Display(ITempDataDictionary tempData, string title, string message, CssClassNameEnum e = CssClassNameEnum.alert_primary)
        {
            var cssClassName = e.ToString().Replace("_", "-");

            tempData["message"] = new MessageViewModel()
            {
                CssClassName = cssClassName,
                Message = message,
                Title = title
            };
        }

        /// <summary>
        /// getbootstrap.com/docs/4.0/components/alerts/
        /// </summary>
        public enum CssClassNameEnum
        {
            alert_primary, //blue
            alert_danger, //red
            alert_warning, //orange
        }
    }
}
