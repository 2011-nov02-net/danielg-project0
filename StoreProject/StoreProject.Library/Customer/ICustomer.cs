using System;
using System.Collections;
using System.Collections.Generic;

namespace StoreProject
{
    public interface ICustomer
    {
        /// <summary>
        /// Information Identifying the Customer
        /// </summary>
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string Id { get; set; }

        /// <summary>
        /// Order Information so that it is possible to find a 
        /// </summary>

        IEnumerable<IOrder> OrderHistory { get; set; }
        IEnumerable<IOrder> RecallOrders(string id);

        void PlaceOrder();
    }
}
