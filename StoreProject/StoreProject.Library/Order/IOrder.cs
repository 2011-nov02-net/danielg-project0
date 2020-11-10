using System;
namespace StoreProject
{
    public interface IOrder
    {

        public string Location { get; }
        public string Customer { get; }
        public int Cost { get; }

    }
}
