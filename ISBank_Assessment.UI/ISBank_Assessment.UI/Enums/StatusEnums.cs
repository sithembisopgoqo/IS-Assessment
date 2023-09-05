using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ISBank_Assessment.UI.Enums
{
    [DataContract]
    public enum AccountStatus
    {
        [DescriptionAttribute("Open")]
        [EnumMember]
        Open = 1,

        [DescriptionAttribute("Closed")]
        [EnumMember]
        Closed = 2,

    }
}