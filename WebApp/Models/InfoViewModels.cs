using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class InfoViewModel
    {
        public string Info { get; set; }
        public string SelectedFilter { get; set; }
        public List<SelectListItem> Filter { get; set; }
        public string Connection { get; set; }
    }
}
