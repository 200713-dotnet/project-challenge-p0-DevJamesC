using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Name
    {
        public Name()
        {
            Customer = new HashSet<Customer>();
            Shop = new HashSet<Shop>();
        }

        public int NameId { get; set; }
        public DateTime DateModified { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Shop> Shop { get; set; }
    }
}
