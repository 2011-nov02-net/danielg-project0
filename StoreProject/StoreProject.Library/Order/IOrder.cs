using System;
namespace StoreProject
{
    public interface IOrder
    {

        public string Location { get; set; }
        public string Customer { get; set; }
        public string DateAndTime { get; set; }

    }
}
