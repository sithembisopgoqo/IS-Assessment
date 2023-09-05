using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ISBank_Assessment.UI.Common
{
    public static class LocalizationHelper
    {
        #region DateTime Properties

        private static string _fullDateTimeFormat = ConfigurationManager.AppSettings["FullDateTimeFormat"];
        public static string FullDateTimeFormat
        {
            get { return _fullDateTimeFormat; }
            set { _fullDateTimeFormat = value; }
        }

        public static string FullDateTimeFormatParameterized
        {
            get { return ConfigurationManager.AppSettings["FullDateTimeFormatParam"]; }
        }

        private static string _dateTimeFormat = ConfigurationManager.AppSettings["DateTimeFormat"];
        public static string DateTimeFormat
        {
            get { return _dateTimeFormat; }
            set { _dateTimeFormat = value; }
        }

        public static string DateTimeFormatParameterized
        {
            get { return ConfigurationManager.AppSettings["DateTimeFormatParam"]; }
        }

        public static string ShortDateTimeFormat
        {
            get { return ConfigurationManager.AppSettings["ShortDateTimeFormat"]; }
        }
        public static string ShortDateTimeFormatParameterized
        {
            get { return ConfigurationManager.AppSettings["ShortDateTimeFormatParam"]; }
        }

        public static string ToFullDateTimeFormat(this string datetime)
        {
            return string.Format(datetime, FullDateTimeFormat);
        }

        public static string ToDateTimeFormat(this string datetime)
        {
            return string.Format(datetime, DateTimeFormat);
        }

        public static string ToShortDateTimeFormat(this string datetime)
        {
            return string.Format(datetime, ShortDateTimeFormat);
        }

        #endregion DateTime Properties
    }
}