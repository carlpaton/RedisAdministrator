using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Services
{
    public class SetTempDataMessage : Controller
    {
        public void Display(ITempDataDictionary tempData, string title, string message, CssClassNameEnum e = CssClassNameEnum.alert_primary, bool append = false)
        {
            var cssClassName = e.ToString().Replace("_", "-");
            var listMessageViewModel = new List<MessageViewModel>();

            if (tempData["message"] != null && append)
                listMessageViewModel = (List<MessageViewModel>)tempData["message"];

            listMessageViewModel.Add(new MessageViewModel(){ 
                CssClassName = cssClassName,
                Message = message,
                Title = title             
            });

            tempData["message"] = listMessageViewModel;
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
