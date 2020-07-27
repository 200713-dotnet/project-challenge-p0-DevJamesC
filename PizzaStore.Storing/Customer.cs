using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Customer
    {
        public Customer()
        {
            FkCustomerOrderCustomer = new HashSet<FkCustomerOrderCustomer>();
        }

        public int CustomerId { get; set; }
        public int NameId { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime UserModified { get; set; }
        public bool? Active { get; set; }

        public virtual Name Name { get; set; }
        public virtual ICollection<FkCustomerOrderCustomer> FkCustomerOrderCustomer { get; set; }
    }
}
