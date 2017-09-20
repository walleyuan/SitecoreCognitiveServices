using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.OleChat
{
    public enum IntentOptionType {
        [Display(Name = "Radio")] Radio,
        [Display(Name = "Link")] Link,
        [Display(Name = "Checkbox")] Checkbox,
        [Display(Name = "None")] None
    }
}