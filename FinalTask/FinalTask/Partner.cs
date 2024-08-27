
namespace FinalTask
{
    abstract class Partner
    {
        public object PartnerID { get; set; }
        public PartnerType PartnerType { get; set; }
        public PartnerRole PartnerRole { get; set; }

        /// <summary>
        /// Creates new partner
        /// </summary>
        public abstract void CreatePartner();
        
        /// <summary>
        /// Delete existing partner
        /// </summary>
        public abstract void DeletePartner();
    }

    class Customer : Partner
    {
        /// <summary>
        /// Creates new customer
        /// </summary>
        public override void CreatePartner()
        {
            Console.WriteLine("Добавлен новый покупатель");
        }

        /// <summary>
        /// Delete existing customer
        /// </summary>
        public override void DeletePartner()
        {
            Console.WriteLine("Существующий покупатель удален");
        }
    }

    class Courier : Partner
    {
        public MobilityType MobilityType { get; set; }

        /// <summary>
        /// Creates new courier
        /// </summary>
        public override void CreatePartner()
        {
            Console.WriteLine("Добавлен новый курьер");
        }

        /// <summary>
        /// Delete existing courier
        /// </summary>
        public override void DeletePartner()
        {
            Console.WriteLine("Существующий курьер удален");
        }
    }

    enum PartnerType
    {
        LegalEntity = 1, 
        Resident         
    }
    enum PartnerRole
    {
        Customer = 1,    
        Courier          
    }
    enum MobilityType
    {
        Пеший_Курьер = 1,
        Транспортом
    }
}
