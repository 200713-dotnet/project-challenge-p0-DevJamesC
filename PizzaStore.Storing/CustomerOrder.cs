using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            FkCustomerOrderCustomer = new HashSet<FkCustomerOrderCustomer>();
        }

        public int CustomerOrderId { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime UserModified { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<FkCustomerOrderCustomer> FkCustomerOrderCustomer { get; set; }
    }
}
