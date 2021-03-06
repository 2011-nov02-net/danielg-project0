﻿using System;
using System.Collections.Generic;

#nullable disable

namespace StoreProjectDB.DataModel
{
    public partial class AggOrder
    {
        public int OrderId { get; set; }
        public string Product { get; set; }
        public int Amount { get; set; }

        public virtual GenOrder Order { get; set; }
        public virtual Product ProductNavigation { get; set; }
    }
}
