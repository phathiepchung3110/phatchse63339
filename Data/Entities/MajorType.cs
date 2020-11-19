using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class MajorType
    {
        public string MajorCode { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public virtual Major MajorCodeNavigation { get; set; }
    }
}
