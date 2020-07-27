using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            FkCustomerOrderCustomer = new HashSet<FkCustomerOrderCustomer>();
            FkCustomerOrderPizza = new HashSet<FkCustomerOrderPizza>();
        }

        public int CustomerOrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderedFrom { get; set; }
        public DateTime DateModified { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<FkCustomerOrderCustomer> FkCustomerOrderCustomer { get; set; }
        public virtual ICollection<FkCustomerOrderPizza> FkCustomerOrderPizza { get; set; }
    }
}
