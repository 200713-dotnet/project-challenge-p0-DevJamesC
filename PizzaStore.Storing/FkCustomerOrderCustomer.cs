using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class FkCustomerOrderCustomer
    {
        public int CustomerOrderCustomerId { get; set; }
        public int CustomerOrderId { get; set; }
        public int CustomerId { get; set; }
        public bool Active { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerOrder CustomerOrder { get; set; }
    }
}
