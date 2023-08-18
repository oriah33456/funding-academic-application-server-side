using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModels.DTO.Enums
{
    public enum  Product:byte
    {
        [Description("Report")]
        Report=1,
        [Description("Model")]
        Model,
        [Description("Software")]
        Software,
        [Description("Algorithmics")]
        Algorithmics,
        [Description("Datasets")]
        Datasets,
        [Description("Hardware")]
        Hardware,
        [Description("Presentation")]
        Presentation,
        [Description("Patents")]
        Patents
    }
     
}
