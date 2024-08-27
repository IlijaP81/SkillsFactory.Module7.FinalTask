
namespace FinalTask
{
    class Order<TDelivery> where TDelivery : Delivery
    {
        public Guid OrderID { get; set; } // order's Systen Identificator
        
        public int ItemID = 0; // order's item Identificator
        public DateTime OrderTime { get; set; } // order's Date/Time

        public object ProductID { get; set; } // product's Identificator

        public int Quantity { get; set; } // product's Quantity

        public double OrderPrice { get; set; } // order's Price

        public Order<TDelivery> order = null;

        public void CreateOrder(Order<TDelivery> order, object ProductID, int quantity)
        {
            order.OrderID = Guid.NewGuid();
            order.ItemID++;
            order.OrderTime = DateTime.Now;
            order.ProductID = ProductID;
            order.Quantity = quantity;

            // find product by ProductID, calculates order's price
            WareHouse storage = new WareHouse();
            var good = storage.Equipments.Find(element => element.ProductID.ToString() == ProductID.ToString());
            order.OrderPrice = CalculateOrder(Quantity, good.ProductPrice);
            
            Console.ForegroundColor = ConsoleColor.White;
            if (order is Order<HomeDelivery>) // shipment to home
            {
                HomeDelivery homeDelivery = new HomeDelivery();
                Address address = new Address();
                Address addr = address.GetAddress(homeDelivery);
                // order's Header
                string headOfOrder =
                $"Создан заказ: {order.OrderID.ToString()} Дата создания: {order.OrderTime.ToString()} " +
                $"Стоимость: {order.OrderPrice.ToString()} " +
                $"Адрес доставки : Город: {Address.City} Улица: {addr.Street} " +
                $"Номер дома: {addr.HouseNumber} Номер помещения: {addr.PremiseNumber}";

                // order's Item
                string itemsOfOrder =
                $"Позиция заказа : {order.ItemID.ToString()} Товар : {order.ProductID.ToString()} " +
                $"Количество : {order.Quantity} Доставка : {homeDelivery.Courier.MobilityType}" + 
                $" Время доставки: {homeDelivery.PickUpTime.AddDays(3)}";
                Console.WriteLine(headOfOrder);
                Console.WriteLine(itemsOfOrder);
            }
            if (order is Order<PickPointDelivery>) // shipment to Point Of Delivery
            {
                PickPointDelivery pickPointDelivery = new PickPointDelivery();
                Address address = new Address();
                Address addr = address.GetAddress(pickPointDelivery);
                // order's Header
                string headOfOrder =
                $"Создан заказ: {order.OrderID.ToString()} Дата создания: {order.OrderTime.ToString()} " +
                $"Стоимость: {order.OrderPrice.ToString()} " +
                $"Адрес доставки : Город: {Address.City} Улица: {addr.Street} " +
                $"Номер дома: {addr.HouseNumber} Номер помещения: {addr.PremiseNumber}";

                // order's Item
                string itemsOfOrder =
                $"Позиция заказа : {order.ItemID.ToString()} Товар : {order.ProductID.ToString()} " +
                $"Количество : {order.Quantity} + Дата/время окончания хранения: {pickPointDelivery.PickPointStorageTime.AddDays(5)}";
                Console.WriteLine(headOfOrder);
                Console.WriteLine(itemsOfOrder);
            }
            if (order is Order<ShopDelivery>) // shipment to Shop (parcel automat)
            {
                ShopDelivery shopDelivery = new ShopDelivery();
                Address address = new Address();
                Address addr = address.GetAddress(shopDelivery);
                // order's Header
                string headOfOrder =
                $"Создан заказ: {order.OrderID.ToString()} Дата создания: {order.OrderTime.ToString()} " +
                $"Стоимость: {order.OrderPrice.ToString()} " +
                $"Адрес доставки : Город: {Address.City} Улица: {addr.Street} " +
                $"Номер дома: {addr.HouseNumber} Номер помещения: {addr.PremiseNumber}";

                // order's Item
                string itemsOfOrder =
                $"Позиция заказа : {order.ItemID.ToString()} Товар : {order.ProductID.ToString()} " +
                $"Количество : {order.Quantity} + Дата/время окончания хранения : {shopDelivery.ShopStorageTime.AddDays(7)} " +
                $"Номер ячейки в постамате: {shopDelivery.StorageCellNumber}";
                Console.WriteLine(headOfOrder);
                Console.WriteLine(itemsOfOrder);
            }
            // TO DO: order's data to be stored in DataBase
        }
 
        /// <summary>
        ///  Calculates price of order by multiplication of Quantity and ProductPrice
        /// </summary>
        /// <param name="Quantity"></param>
        /// <param name="ProductPrice"></param>
        /// <returns></returns>
        public double CalculateOrder(int Quantity, double ProductPrice)
        {
            return Quantity * ProductPrice; 
        }
    }
}
