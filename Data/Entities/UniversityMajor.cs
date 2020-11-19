using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class UniversityMajor
    {
        public string UniCode { get; set; }
        public string MajorCode { get; set; }

        public virtual Major MajorCodeNavigation { get; set; }
        public virtual University UniCodeNavigation { get; set; }
    }
}
