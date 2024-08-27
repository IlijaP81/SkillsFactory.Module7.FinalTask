
namespace FinalTask
{
    /// <summary>
    /// Define & Show to customer all products avaiable in WebShop
    /// </summary>
    internal class WareHouse
    {
        /// <summary>
        /// Shows all products avaiable in WebShop
        /// </summary>
        public void ShowProducts()
        {
            Console.WriteLine("В нашем магазине доступны следующие товары:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < Equipments.Count; i++)
            {
                Console.WriteLine(
                                 " Код товара: " + Equipments[i].ProductID.ToString() + "\n" +
                                 " Тип товара: " + Equipments[i].EquipmentType.ToString() + "\n" +
                                 " Название: " + Equipments[i].ProductName.ToString() + "\n" +
                                 " Описание: " + Equipments[i].ProductDescription.ToString() + "\n" +
                                 " Стоимость: " + Equipments[i].ProductPrice.ToString() + "\n" +
                                 " Доступно: " + Equipments[i].TotalQuantity.ToString() + "\n" +
                                 "--------------------------------------"
                                 );
            }
        }

        // imitation (instead of DataBase)...
        // Product's list should be selected from DataBase
        
        /// <summary>
        /// Provides list of avaiable products
        /// </summary>
        public List<PowerEquipment> Equipments = new List<PowerEquipment>
        {
            new Drill { ProductID = "Dr1", ProductName = "Electric Drill",
                        ProductDescription = "High Perfomance Drill with Punch function",
                        ProductPrice = 100.00, TotalQuantity = 5, BookedQuantity = 0,
                        EquipmentType = "Electric Drilling Tools", MaxRPM = 2000 },
            new Drill { ProductID = "Dr2", ProductName = "Manual Drill",
                        ProductDescription = "Low Perfomance Drill with ManualDrive",
                        ProductPrice = 45.00, TotalQuantity = 5, BookedQuantity = 0,
                        EquipmentType = "Manual Drilling Tools", MaxRPM = 60  },
            new Generator { ProductID = "Gen1", ProductName = "Electric Generator",
                            ProductDescription = "Oil generator",
                            ProductPrice = 300.00, TotalQuantity = 7, BookedQuantity = 0,
                            EquipmentType = "Power Stations", MaxPower = 2 },
            new Generator { ProductID = "Gen2", ProductName = "Electric Generator",
                            ProductDescription = "Oil/Gaz generator",
                            ProductPrice = 350.00, TotalQuantity = 2, BookedQuantity = 0,
                            EquipmentType = "Power Stations", MaxPower = 2.5 },
        };
    }
}

