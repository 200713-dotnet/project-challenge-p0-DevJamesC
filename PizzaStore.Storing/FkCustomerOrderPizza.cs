using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class FkCustomerOrderPizza
    {
        public int CustomerOrderPizzaId { get; set; }
        public int CustomerOrderId { get; set; }
        public int PizzaId { get; set; }
        public bool Active { get; set; }

        public virtual CustomerOrder CustomerOrder { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
