using DNSapp.DTO;
using DNSapp.Services;
using System;

namespace DNSapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInfoService userInfoService = new UserInfoService();
            ProductCatalogService productCatalogService = new ProductCatalogService();
            while (true)
            {
                Console.WriteLine("Введите цифру: 1, 2, 3, 4");
                string inputKey = Console.ReadLine();
                int convertKey = Convert.ToInt32(inputKey);
                switch (convertKey)
                {
                    case 1:
                        ShowAllUsers(userInfoService);
                        break;
                    case 2:
                        AddNewUser(userInfoService);
                        break;
                    case 3:
                        EditUser(userInfoService);
                        break;
                    case 4:
                        ShowAllProducts(productCatalogService);
                        break;
                    case 5:
                        AddNewProduct(productCatalogService);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }


        public static void ShowAllUsers(UserInfoService userInfoService)
        {
            Console.WriteLine("Список всех пользователей");
            List<UserInfoDto> usersInfoDto = userInfoService.GetAllDto();
            foreach (UserInfoDto userInfo in usersInfoDto)
            {
                Console.WriteLine($"Id = {userInfo.Id}, FirsName = {userInfo.FirstName}, SecondName = {userInfo.SecondName}, PhoneNumber = {userInfo.PhoneNumber}");
            }
        }



        public static void AddNewUser(UserInfoService userInfoService)
        {
            Console.WriteLine("Добавление нового пользователя");
            Console.WriteLine("Введите FirstName");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите SecondName");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введите номер телефона");
            string phoneNumberStr = Console.ReadLine();
            int phoneNumber = Convert.ToInt32(phoneNumberStr);

            Random random = new Random();
            int Id = random.Next(1000000, 9999999);

            UserInfoDto userInfo = new UserInfoDto() {Id = Id, FirstName = firstName, SecondName = lastName, PhoneNumber = phoneNumber};
            UserInfoDto? newUser = userInfoService.Add(userInfo);
            if (newUser != null )
            {
                Console.WriteLine("Новый пользователь добавлен успешно");
                Console.WriteLine($"Id = {newUser.Id}, FirstName = {newUser.FirstName}, SecondName = {newUser.SecondName}, PhoneNumber = {newUser.PhoneNumber}");
            }
        }



        public static void EditUser(UserInfoService userInfoService)
        {
            Console.WriteLine("Редактирование пользователя");
            Console.WriteLine("Введите идентификатор пользователя");
            string? idInput = Console.ReadLine();
            int newId = Convert.ToInt32(idInput);
            UserInfoDto? newUserDto = userInfoService.GetDto(newId);
            if (newUserDto == null )
            {
                Console.WriteLine($"Пользователя с номером Id {newId} нет в базе");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Выберите параметр: 1 - FirstName, 2 - SecondName, 3 - PhoneNumber");
                    string? inputKey = Console.ReadLine();
                    int convertKey = Convert.ToInt32(inputKey);
                    switch (convertKey)
                    {
                        case 1:
                            string? firstName = Console.ReadLine();
                            newUserDto.FirstName = firstName != null ? firstName : newUserDto.FirstName;
                            break;
                        case 2:
                            string? lastName = Console.ReadLine();
                            newUserDto.SecondName = lastName != null ? lastName : newUserDto.SecondName;
                            break;
                        case 3:
                            string? phoneNumber = Console.ReadLine();
                            int? phoneNumberInt = Convert.ToInt32(phoneNumber);
                            newUserDto.PhoneNumber = phoneNumberInt != null ? phoneNumberInt : newUserDto.PhoneNumber;
                            break;
                        default:
                            break;
                    }
                    break;
                }
                bool editValid = userInfoService.Edit(newUserDto);
                if (editValid == false)
                {
                    Console.WriteLine("Редактирование отменено");
                }
                else
                {
                    Console.WriteLine("Данные пользователя изменены успешно");
                }
            }
        }




        public static void ShowAllProducts(ProductCatalogService productCatalogService)
        {
            Console.WriteLine("Список всех товаров");
            List<ProductCatalogDto> products = productCatalogService.GetAllDto();
            foreach (ProductCatalogDto product in products)
            {
                Console.WriteLine($"Id = {product.Id}, Category = {product.Category}, Product = {product.Product}, Price = {product.Price}, ProductCount = {product.ProductCount}");
            }
        }




        public static void AddNewProduct(ProductCatalogService productCatalogService)
        {
            Console.WriteLine("Добавление нового товара");
            Console.WriteLine("Введите Category");
            string? category = Console.ReadLine();
            Console.WriteLine("Введите Product");
            string? product = Console.ReadLine();
            Console.WriteLine("Введите стоимость");
            string? price = Console.ReadLine();
            int newPrice = Convert.ToInt32(price);
            Console.WriteLine("Введите количество");
            string? quantity = Console.ReadLine();
            int newquantity = Convert.ToInt32(quantity);

            Random random = new Random();
            int Id = random.Next(1000000, 9999999);

            ProductCatalogDto productCatalogDto = new ProductCatalogDto() { Id = Id, Category = category, Price = newPrice, Product = product, ProductCount = newquantity};
            ProductCatalogDto? newProductCatalogDto = productCatalogService.Add(productCatalogDto);
            Console.WriteLine($"Добавлен новый товар");
            Console.WriteLine($"Id = {newProductCatalogDto.Id}, Category = {productCatalogDto.Category}, Price = {productCatalogDto.Price}, Product = {productCatalogDto.Product}, ProductCount = {productCatalogDto.ProductCount}");
        }











        // создаем два объекта User
        //UserInfoDTO tom = new UserInfoDTO { Id = 1000006, FirstName = "Tom", SecondName = "Hanks" };

        //UserInfoDTO result = userInfoService.Add(tom);


        ////UserInfo alice = new UserInfo { Id = 1000007, FirstName = "Alice", SecondName = "Fox" };



        //Console.WriteLine("Объекты успешно сохранены");

        ////получаем объекты из бд и выводим на консоль
        //var users = db.UserInfos.ToList();
        //Console.WriteLine("Список объектов:");
        //foreach (UserInfo u in users)
        //{
        //    Console.WriteLine($"{u.Id}.{u.FirstName} - {u.SecondName}");
        //}





        //var users = db.UserInfos.ToList();
        //Console.WriteLine("Данные после добавления:");
        //foreach (UserInfo u in users)
        //{
        //    Console.WriteLine($"{u.Id}.{u.FirstName} - {u.SecondName}");
        //}





        //// получаем первый объект
        //UserInfo? user = db.UserInfos.FirstOrDefault();
        //if (user != null)
        //{
        //    user.Id = 1000007;
        //    user.FirstName = "Steve";
        //    user.SecondName = "Fox";
        //    //обновляем объект
        //    //db.Users.Update(user);
        //    db.SaveChanges();
        //}
        //// выводим данные после обновления
        //Console.WriteLine("\nДанные после редактирования:");
        //var users = db.UserInfos.ToList();
        //foreach (UserInfo u in users)
        //{
        //    Console.WriteLine($"{u.Id}.{u.FirstName} - {u.SecondName}");
        //}

    }   
}   

