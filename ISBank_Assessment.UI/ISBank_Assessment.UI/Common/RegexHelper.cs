using ISBank_Assessment.UI.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ISBank_Assessment.UI.Common
{
    public class NumbersOnlyAttribute : RegularExpressionAttribute
    {
        public NumbersOnlyAttribute()
            : base(@Labels.RegexNumbersOnlyPattern)
        {
            ErrorMessageResourceName = "RegexNumbersOnly";
            ErrorMessageResourceType = typeof(Labels);
        }
    }

    public class LettersOnlyAttribute : RegularExpressionAttribute
    {
        public LettersOnlyAttribute()
            : base(@Labels.RegexLettersOnlyPattern)
        {
            ErrorMessageResourceName = "RegexLettersOnly";
            ErrorMessageResourceType = typeof(Labels);
        }
    }

    // ReSharper disable once InconsistentNaming
    public class IPAddressAttribute : RegularExpressionAttribute
    {
        public IPAddressAttribute()
            : base(Labels.RegexIPAddressPattern)
        {
            ErrorMessageResourceName = "RegexIPAddress";
            ErrorMessageResourceType = typeof(Labels);
        }
    }

    public class EmailAttribute : RegularExpressionAttribute
    {
        public EmailAttribute()
            //: base(Labels.RegexEmailPattern)
            : base("^[a-zA-Z0-9._%+-]+@([0-9a-zA-Z][\\-]*[-_0-9a-zA-Z]+\\.)+[a-zA-Z]+$")
        {
            ErrorMessageResourceName = "RegexEmail";
            ErrorMessageResourceType = typeof(Labels);
        }
    }

    public class RegexTimeSpanAttribute : RegularExpressionAttribute
    {
        public RegexTimeSpanAttribute()
            : base(@"^(?:(?:([01]?\d|2[0-3]):)?([0-5]?\d):)?([0-5]?\d)$")
        {
            ErrorMessageResourceName = "RegexTimeSpan";
            ErrorMessageResourceType = typeof(Labels);
        }
    }

    public class DecimalAttribute : RegularExpressionAttribute
    {
        public DecimalAttribute(int IntPart, int FracPart)
            : base(@"^(?!\.?$)\d{0," + IntPart + @"}([\.\,]\d{0," + FracPart + @"})?$")
        {
            ErrorMessageResourceName = "RegularDecimal";
            ErrorMessageResourceType = typeof(Labels);
        }
    }

    public class MoneyAttribute : RegularExpressionAttribute
    {
        public MoneyAttribute()
            : base(@"^\d{0,12}(\.?\,?\d{1,6})?$")
        {
            ErrorMessageResourceName = "MoneyDecimal";
            ErrorMessageResourceType = typeof(Labels);
        }
    }

    public class NegativeMoneyAttribute : RegularExpressionAttribute
    {
        public NegativeMoneyAttribute()
            : base(@"^-?\d{0,12}(\.?\,?\d{1,6})?$")
        {
            ErrorMessageResourceName = "MoneyDecimal";
            ErrorMessageResourceType = typeof(Labels);
        }
    }

    public class URLAttribute : RegularExpressionAttribute
    {
        public static Regex _regex = new Regex(@"((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,15})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        public URLAttribute()
            : base(_regex.ToString())
        {
            ErrorMessageResourceName = "RegexUrl";
            ErrorMessageResourceType = typeof(Labels);
        }
    }

}