using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Directory
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<Users> Users_Directory = new List<Users>()
            {
                new Users(1,"Павлов","Михаил","Романович","7(296)018-07-61","jadouwittudou-9303@yopmail.com",true),
                new Users(2,"Шевцов","Василиса","Кирилловна","7(324)813-49-73","vellupezauje-9469@yopmail.com",false),
                new Users(3,"Дмитриева","Александра","Тимофеевна","7(835)590-88-78","jaujetoinnougeu-1691@yopmail.com",true),
                new Users(4,"Рыжков","Арсений","Александрович","7(705)157-31-54","rihequefrellou-4880@yopmail.com",true)
            };
            Directory directory = new Directory();
            Console.WriteLine("СПРАВОЧНИК ТЕЛЕФОНОВ");
            Console.Write("Чтобы вы хоели сделать?\n" +
                "1. Просмотреть весь справочник\n" +
                "2. Добавить новую запись\n" +
                "3. Изменить запись\n" +
                "4. Заблокировать пользователя\n" +
                "5. Удалить пользователя\n" +
                "6. Выйти\n" +
                "Введите команду: ");
            string message = Console.ReadLine();
            while (message != "6")
            {
                switch (message)
                {
                    case "1":
                        directory.View(Users_Directory);
                        break;
                    case "2":
                        directory.Add("Иванов","Иван","Иванович", "7(000)000-00-00", "test@mail.com", Users_Directory);
                        break;
                    case "3":
                        directory.Change(Users_Directory, "Фамилия", "Иванов", 1);
                        break;
                    case "4":
                        directory.WillBlocked(Users_Directory);
                        break;
                    case "5":
                        directory.Delete(6, Users_Directory);
                        break;
                    default:
                        Console.WriteLine("Такой команды нет\n");
                        break;
                }
                Console.Write("\nЧтобы вы хоели сделать?\n" +
                "1. Просмотреть весь справочник\n" +
                "2. Добавить новую запись\n" +
                "3. Изменить запись\n" +
                "4. Заблокировать пользователя\n" +
                "5. Удалить пользователя\n" +
                "6. Выйти\n" +
                "Введите команду: ");
                message = Console.ReadLine();
            }
        }
    }
}
