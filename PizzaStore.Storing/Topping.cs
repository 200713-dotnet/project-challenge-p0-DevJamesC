using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Topping
    {
        public Topping()
        {
            FkPizzaToppingId = new HashSet<FkPizzaToppingId>();
        }

        public int ToppingId { get; set; }
        public string Name { get; set; }
        public DateTime DateModified { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<FkPizzaToppingId> FkPizzaToppingId { get; set; }
    }
}
