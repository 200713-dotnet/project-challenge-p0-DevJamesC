﻿using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Pizza
    {
        public Pizza()
        {
            FkCustomerOrderPizza = new HashSet<FkCustomerOrderPizza>();
            FkPizzaToppingId = new HashSet<FkPizzaToppingId>();
        }

        public int PizzaId { get; set; }
        public int? CrustId { get; set; }
        public int? SizeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateModified { get; set; }
        public bool? Active { get; set; }

        public virtual Crust Crust { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<FkCustomerOrderPizza> FkCustomerOrderPizza { get; set; }
        public virtual ICollection<FkPizzaToppingId> FkPizzaToppingId { get; set; }
    }
}
