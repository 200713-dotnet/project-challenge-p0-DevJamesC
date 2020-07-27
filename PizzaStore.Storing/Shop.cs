using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Shop
    {
        public int ShopId { get; set; }
        public int NameId { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime UserModified { get; set; }
        public bool? Active { get; set; }

        public virtual Name Name { get; set; }
    }
}
