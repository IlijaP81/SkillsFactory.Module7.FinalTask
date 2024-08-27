// КРАТКОЕ ОПИСАНИЕ:
// 1. Класс Program - реализация диалога с пользователем:
//      1.1 демонстрация имеющихся в наличии товаров;
//      1.2 выбор товара, количества, способа доставки;
//      1.3 реализация сервисных функций.
// 2. Класс Product (абстрактный) - реализация структуры продукта,
//    определение абстрактных методов, подлежащих реализации:
//      2.1 класс PowerEquipment (электрооборудование, наследуемый) -
//          реализация методов абстрактного родительского класса;
//      2.2 класс Drill (наследуемый) - конкретный тип электрооборудования;
//      2.3 класс Generator (наследуемый) - конкретный тип электрооборудования.
// 3. Класс WareHouse - работа с номенклатурой товаров:
//      3.1 реализация метода для демонстрации имеющихся в наличии товаров;
//      3.2 реализация примера номенклатуры товаров.
// 4. Класс Address (статичное поле) - реализация структуры адреса и логики работы с адресами: 
//      4.1 класс ShipmentAddresses - реализация перечня доступных для доставки
//          адресов в зависимости от типа доставки;
//      4.2 реализация метода выбора адреса доставки в зависимости от типа доставки.
// 5. Класс Partner - базовый класс для различных типов партнеров:
//      5.1 класс Customer (покупатель, наследуемый) - имитация методов создания/удаления покупателя;
//      5.2 класс Courier (курьер, наследуемый) - имитация методов создания/удаления курьера;
// 6. Класс Delivery - базовый класс для различных типов доставки:
//      6.1 класс HomeDelivery (наследуемый) - реализация специфичных парметров для типа доставки;
//      6.2 класс PickPointDelivery (наследуемый) - реализация специфичных парметров для типа доставки;
//      6.3 класс ShopDelivery (наследуемый) - реализация специфичных парметров для типа доставки; 
// 7. Класс Order (обобщение с ограничением) - реализация структуры заказа и логики работы с заказами:
//      7.1 метод CreateOrder - вывод в консоль данных заказа с параметрами, специфичными для типа доставки
//      7.2 метод CalculateOrder - расчет стоимости заказа.



using FinalTask;

class Program
{
    static void Main(string[] args)
    {
        StartWork();
    }

    private static void StartWork()
    {
        bool result = false;
        int quantity, actionType;

        // show avaiable products
        WareHouse wareHouse = new WareHouse();
        wareHouse.ShowProducts();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Укажите код товара в точности как в номенклатуре (например, Dr1):");
        object productID = Console.ReadLine();

        do
        {
            Console.WriteLine("Определите количество как целое положительное число");
            result = int.TryParse(Console.ReadLine(), out quantity);
        }
        while (!result);

        Console.WriteLine("Выберите способ доставки: "          +
                            "1 - доставка на дом, "             +
                            "2 - доставка в пункт выдачи, "     +
                            "3 - доставка в магазин "           + 
                            "0 - перейти в сервисный режим");
        int answer = int.Parse(Console.ReadLine());

        switch (answer)
        {
            case 0: // creating/deleting product, partner  
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Выберите действие: " +
                            "1 - создать продукт " +
                            "2 - удалить продукт " +
                            "3 - создать клиента " +
                            "4 - удалить клиента " +
                            "5 - создать курьера " +
                            "6 - удалить курьера ");
                    do
                    {
                        Console.WriteLine("Выберите действие из списка");
                        result = int.TryParse(Console.ReadLine(), out actionType);
                    }
                    while (!result);

                    //int actionType = int.Parse(Console.ReadLine());

                    switch (actionType)
                    {
                        case 1: // create product
                            {
                                PowerEquipment powerEquipment = new PowerEquipment();
                                powerEquipment.CreateProduct();
                                break;
                            }

                        case 2: // delete product
                            {
                                PowerEquipment powerEquipment = new PowerEquipment();
                                powerEquipment.DeleteProduct();
                                break;
                            }
                        
                        case 3: // create customer
                            {
                                Customer customer = new Customer();
                                customer.CreatePartner();
                                break;
                            }

                        case 4: // delete customer
                            {
                                Customer customer = new Customer();
                                customer.DeletePartner();
                                break;
                            }

                        case 5: // create courier
                            {
                                Courier courier = new Courier();
                                courier.CreatePartner();
                                break;
                            }

                        case 6: // delete courier
                            {
                                Courier courier = new Courier();
                                courier.DeletePartner();
                                break;
                            }
                        default:
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("Вы не ввели ни одно из возможных значений");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            }
                    }
                    break;
                }
            
            case 1: // delivery to home
                {
                    Order<HomeDelivery> order = new Order<HomeDelivery>();
                    order.CreateOrder(order, productID, quantity);
                    break;
                }
            case 2: // delivery to Point Of Delivery
                {
                    Order<PickPointDelivery> order = new Order<PickPointDelivery>();
                    order.CreateOrder(order, productID, quantity);
                    break;
                }
            case 3: // delivery to Shop
                {
                    Order<ShopDelivery> order = new Order<ShopDelivery>();
                    order.CreateOrder(order, productID, quantity);
                    break;
                }
            default:
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы не ввели ни одно из возможных значений");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                }
        }
    }
}
