
namespace FinalTask
{
    class Delivery
    {
        public object typeOfDelivery = null;
    }

    class HomeDelivery : Delivery
    {
        public Courier Courier { get; set; } 
        public DateTime PickUpTime { get; set; } // Date/Time of shipment

        public HomeDelivery() // shipment to home
        {
            Courier = new Courier();
            Courier.MobilityType = MobilityType.Транспортом; // way of delivery
            PickUpTime = DateTime.Now; // delivery base- Date/Time (to be corrected in Order)
        }
    }
    class PickPointDelivery : Delivery // shipment to Point Of Delivery
    {
        public DateTime PickPointStorageTime { get; set; } 
        
        public PickPointDelivery()
        {
            PickPointStorageTime = DateTime.Now; // base- Date/Time End of storage (to be corrected in Order)
        }
    }
    class ShopDelivery : Delivery // shipment to Shop (parcel automat)
    {
        public DateTime ShopStorageTime { get; set; } // base- Date/Time End of storage (...)
        public int StorageCellNumber { get; set; } // numeric number of storage cell
        public ShopDelivery()
        {
            ShopStorageTime = DateTime.Now;
            Random cellID = new Random();
            var randomBetween1And99 = cellID.Next(1, 99);
            StorageCellNumber = randomBetween1And99;
        }
    }
}
