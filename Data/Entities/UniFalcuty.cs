using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class UniFalcuty
    {
        public string FalcutyCode { get; set; }
        public string UniCode { get; set; }

        public virtual Falcuty FalcutyCodeNavigation { get; set; }
        public virtual University UniCodeNavigation { get; set; }
    }
}
