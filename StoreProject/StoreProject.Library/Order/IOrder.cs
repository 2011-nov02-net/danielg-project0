using System;
using System.Collections.Generic;
using StoreProject.Library;
using StoreProject.Library.Customer;

namespace StoreProject
{
    public interface IOrder
    {
        /// <summary>
        /// Property to get or set the cost of the order
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// Property to get/set the date an order was placed
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Property to get/set the Location of an order
        /// </summary>
        public Location Location { get; set; }
        /// <summary>
        /// Property to get/set the Customer of an order8=
        /// </summary>
        public CustomerClass Customer { get; set; }
        /// <summary>
        /// Property to get/set the ID of an order
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// calculate the total cost of an order
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public decimal CalculateTotal(List<Product> products);

        /// <summary>
        /// Print the details of an order
        /// </summary>
        public void printDetails();
    }
}
