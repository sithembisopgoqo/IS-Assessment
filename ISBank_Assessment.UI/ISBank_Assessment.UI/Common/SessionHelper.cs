using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ISBank_Assessment.UI.Common
{
    public static class SessionHelper
    {
        public static T Get<T>(string index)
        {
            if (HttpContext.Current.Session == null)
            {
                throw new System.ComponentModel.DataAnnotations.ValidationException("Your session has expired and you are currently logged out.");
            }
            if (HttpContext.Current.Session[index] != null)
            {
                return (T)HttpContext.Current.Session[index];
            }
            else
            {
                //TODO Redirect to login page
                var path = ConfigurationManager.AppSettings["ServerPath"] + "Home/Index";
                HttpContext.Current.Response.Redirect(path, true);

                throw new System.ComponentModel.DataAnnotations.ValidationException(string.Format("Your session has expired and you are currently logged out.", index));

            }
        }

        public static void Set<T>(string index, T value)
        {
            HttpContext.Current.Session[index] = value;
        }

        public static void Remove(string index)
        {
            if (Contains(index)) HttpContext.Current.Session.Remove(index);
        }

        public static bool Contains(string index)
        {
            if (HttpContext.Current.Session == null) return false;

            return HttpContext.Current.Session[index] != null;
        }

        public static bool IsSessionValid()
        {
            return Contains("UserName");
        }
    }
}