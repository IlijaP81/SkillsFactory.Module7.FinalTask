
namespace FinalTask
{
    /// <summary>
    /// Defines product structure & abstract methods to operate with product
    /// </summary>
    public abstract class Product
    {
        public object ProductID { get; set; } // product's identificator
        public string ProductName { get; set; } // product's title
        public string ProductDescription { get; set; } // product's description
        public double ProductPrice { get; set; } // product's price
        public int TotalQuantity { get; set; } // product's quantity in total
        public int BookedQuantity { get; set; } // product's quantity booked

        /// <summary>
        /// Creates new product in WebShop
        /// </summary>
        public abstract void CreateProduct();

        
        /// <summary>
        /// Delete existing product from WebShop
        /// </summary>
        public abstract void DeleteProduct();
    }

    /// <summary>
    /// Defines groupes of product
    /// </summary>
    public class PowerEquipment : Product
    {
        public string EquipmentType { get; set; }

        public override void CreateProduct() 
        {
            Console.WriteLine("Создан новый продукт");
        }
        public override void DeleteProduct() 
        {
            Console.WriteLine("Продукт удален");
        }
    }


    /// <summary>
    /// Defines product, overrides methods to operate with product
    /// </summary>
    public class Drill : PowerEquipment
    {
        public int MaxRPM { get; set; } // RotatesPerMinute
    }


    /// <summary>
    /// Defines product, overrides methods to operate with product
    /// </summary>
    public class Generator : PowerEquipment
    {
        public double MaxPower { get; set; } // defines max value of power
    }

}
