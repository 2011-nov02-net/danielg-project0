﻿using System;
using System.Collections.Generic;
using StoreProject.Library.Customer;

namespace StoreProject.Library.Order
{
    public class Order : IOrder
    {
        /// <summary>
        /// Private fields to store data pertaining to an order
        /// </summary>
        private Location _location;
        private CustomerClass _customer;
        private DateTime date;
        private decimal cost;


        /// <summary>
        /// Constructor used to create an order
        /// </summary>
        public Order(Location location, CustomerClass customer)
        {
            Location = location;
            Customer = customer;
            Date = DateTime.Now;
            
        }


        /// <summary>
        /// roperty to get or set the location of an order
        /// </summary>
        public Location Location { get => _location; set => _location = value; }

        /// <summary>
        /// Property to get or set the customer of an order
        /// </summary>
        public CustomerClass Customer { get => _customer; set => _customer = value; }


        /// <summary>
        /// Property to get/set the date an order was placed
        /// </summary>
        public DateTime Date { get => date; set => date = value; }

        /// <summary>
        /// Property to get or set the cost of the order
        /// </summary>
        public decimal Cost { get => cost; set => cost = value; }


        /// <summary>
        /// Calculate the total of an order, pass in the list of prodcuts from the database
        /// </summary>
        public void CalculateTotal(List<Product> products)
        {
            decimal orderTotal = 0.00M;
            // Get a dictionary of products and prices and get a dictionary of currentorder
            // iterate through the order, matching the amount and price by the product
            foreach (var product in Customer.ShoppingCart)
            {
                // get the product name for shopping cart to search in store inventory 
                var productName = product.Key;
                // Return Product that matches productName in shopping cart
                Product productAddSum = products.Find(p => p.ProductName == productName);
                // Get the price of the product according to DB
                var priceOfProduct = productAddSum.Price;
                // Add the total of 
                orderTotal += (priceOfProduct *= product.Value);
            }
            // Set the cost in this class to the sum of all of the products and prices
            Cost = orderTotal;
        }


        public void printDetails()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Current Order");
            foreach (var product in Customer.ShoppingCart)
            {
                if (product.Value > 1)
                {
                    Console.WriteLine($"({product.Value}) {product.Key}");
                }
                if (product.Value == 1)
                {
                    Console.WriteLine($"(1) {product.Key}");
                }
                
            }
        }
    }
}
