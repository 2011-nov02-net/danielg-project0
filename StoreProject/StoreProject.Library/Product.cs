using System;
namespace StoreProject.Library
{
    public class Product
    {
        // Private fields to store the name and price of the Products
        private string _productName;
        private decimal _price;

        // Constructor creates the product with a name and a price
        public Product(string productName, decimal? price)
        {
            ProductName = productName;
            Price = (decimal)price;
        }

        // Public properties to get or set the value of the products
        public string ProductName { get => _productName; set => _productName = value; }
        public decimal Price { get => _price; set => _price = value; }
    }
}
