﻿using System;
using System.Collections.Generic;
using StoreProject.Library;
using StoreProject.Library.Customer;
using StoreProject.Library.Order;
using Xunit;

namespace StoreProject.Tests
{
    public class OrderTests
    {
        
        [Fact]
        public void TestCartWillFillFail()
        {
            var order = new Order();

            Product prod1 = new Product("Dumb Big Mac", 2);
           
            order.AddToCustomerCart(prod1, 1);

            bool filled = order.Customer.ShoppingCart["Dumb Big Mac"] == 2;

            Assert.False(filled, "Cart was not succesfully filled"); 
        }

        [Fact]
        public void TestCartWillFillPass()
        {
            var order = new Order();

            Product prod1 = new Product("Dumb Big Mac", 2);
            
            order.AddToCustomerCart(prod1, 1);

            bool filled = order.Customer.ShoppingCart["Dumb Big Mac"] == 1;

            Assert.True(filled, "Cart was succesfully filled");
        }


        [Fact]
        public void TestGetOrderTotal()
        {
            var cart = new Dictionary<string, int>()
            {
                { "Dumb Big Mac", 1}
            };
            var customer = new CustomerClass(cart);

            var order = new Order(customer);

            Product prod1 = new Product("Dumb Big Mac", 3);
            
            var amt = order.CalaculateTotalOfOneProduct(prod1);

            bool equal = amt == 3;

            Assert.True(equal, "Price should be 3");
        }

        [Fact]
        public void TestGetOrderTotalFail()
        {
            var cart = new Dictionary<string, int>()
            {
                { "Dumb Big Mac", 1}
            };
            var customer = new CustomerClass(cart);

            var order = new Order(customer);

            Product prod1 = new Product("Dumb Big Mac", 3);

            var amt = order.CalaculateTotalOfOneProduct(prod1);

            bool equal = amt == 3;

            Assert.False(equal, "Price should not be 3");
        }


    }
}
