using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Size
    {
        public Size()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int SizeId { get; set; }
        public string Name { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime UserModified { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
