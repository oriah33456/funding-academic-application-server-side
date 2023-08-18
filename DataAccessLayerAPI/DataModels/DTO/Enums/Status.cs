using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModels.DTO.Enums
{
    public enum Status : byte
    {
        [Description("New")]
        New =1,
        [Description("Approved")]
        Approved,
        [Description("Rejected")]
        Rejected,
        [Description("Canceled")]
        Canceled
    }
}
