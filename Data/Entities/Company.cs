using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Company
    {
        public Company()
        {
            Connection = new HashSet<Connection>();
        }

        public string Code { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Description { get; set; }

        public virtual Account EmailNavigation { get; set; }
        public virtual ICollection<Connection> Connection { get; set; }
    }
}
