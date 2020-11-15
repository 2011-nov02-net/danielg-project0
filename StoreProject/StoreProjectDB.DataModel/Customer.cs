using System;
using System.Collections.Generic;

#nullable disable

namespace StoreProjectDB.DataModel
{
    public partial class Customer
    {
        public Customer()
        {
            GenOrders = new HashSet<GenOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GenOrder> GenOrders { get; set; }
    }
}
