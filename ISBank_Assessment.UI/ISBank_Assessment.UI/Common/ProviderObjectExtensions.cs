using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISBank_Assessment.UI.Common
{
    public class SelectListItemWithAttributes : SelectListItem
    {
        public IDictionary<string, string> HtmlAttributes { get; set; }
    }
}