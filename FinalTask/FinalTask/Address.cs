
namespace FinalTask
{
    /// <summary>
    /// Defines address structure, provides suitable address
    /// </summary>
    class Address
    {
        public object type { get; set; } // depends on type of delivery

        public static string City = "Москва"; // static: delivery is avaiable for single City only
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PremiseNumber { get; set; }

        public Address() { }

        /// <summary>
        /// Select address of delivery which depends on type of delivery
        /// </summary>
        /// <param name="typeOfDelivery"></param>
        /// <returns></returns>
        public Address GetAddress(Delivery typeOfDelivery)
        {
            Address address = null;
            ShipmentAddresses ShAd = new ShipmentAddresses();
            
            if (typeOfDelivery is HomeDelivery)
            {
                address = ShAd.Addresses.Find(element => element.type.ToString() == typeOfAddress.deliveryToHome.ToString()); 
            }
            if (typeOfDelivery is PickPointDelivery)
            {
                address = ShAd.Addresses.Find(element => element.type.ToString() == typeOfAddress.deliveryToPickPoint.ToString());
            }
            if (typeOfDelivery is ShopDelivery)
            {
                address = ShAd.Addresses.Find(element => element.type.ToString() == typeOfAddress.deliveryToShop.ToString());
            }
            return address;
        }
    }

    /// <summary>
    ///  Provides list of addresses avaiable for delivery
    /// </summary>
    class ShipmentAddresses
    {
        // imitation (instead of DataBase)...
        public List<Address> Addresses = new List<Address>()
        {
            new Address { type = typeOfAddress.deliveryToHome, Street = "По указанию заказчика",
                          HouseNumber = "По указанию заказчика", PremiseNumber = "По указанию заказчика"},
            new Address { type = typeOfAddress.deliveryToPickPoint, Street = "Маши Порываевой",
                          HouseNumber = "14/1", PremiseNumber = "5Б"},
            new Address { type = typeOfAddress.deliveryToShop, Street = "Гоголевский бульвар",
                          HouseNumber = "135", PremiseNumber = "-"}
        };
    }

    /// <summary>
    /// Provide different types of addresses for various types of delivery
    /// </summary>
    enum typeOfAddress 
    { 
        deliveryToHome = 1,
        deliveryToPickPoint,
        deliveryToShop
    }
}
