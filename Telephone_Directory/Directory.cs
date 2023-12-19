using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Telephone_Directory
{
    public class Directory
    {
        SaveLog saveLogTXT = new SaveLogTxt();
        SaveChanges save_change_txt = new SaveChangesTxt();
        public void View(List<Users> Users_Directory)
        {
            foreach (var user in Users_Directory)
            {
                Console.Write($"Идентификатор: {user.idUser}\nФамилия: {user.surname}\nИмя: {user.name}\nОтчество: {user.secondname}\n" +
                    $"Номер телефона: {user.phoneNumber}\nE-mail: {user.email}\nСтатус: {user.blocked}\n");
                Console.WriteLine("----------------------------------\n");
            }
        }

        public bool Add(string sur, string name, string sname, string phone, string email, List<Users> Users_Directory)
        {
            bool check_email = false;
            bool check_phone = false;
            bool check_case_surname = false;
            bool check_case_name = false;
            bool check_case_secondname = false;

            //while (check_email == false)
            //{
                check_email = CheckEmail(email);

                //if (check_email == false)
                //{
                //    //Console.Write("Неверный введённый e-mail. Введите e-mail снова: ");
                //    email = Console.ReadLine();
                //}
            //}

            //while (check_phone == false)
            //{
                check_phone = CheckPhone(phone);

                //if (check_phone == false)
                //{
                //    Console.Write("Номер телефона не соответсвует фомату 8(ХХХ)ХХХ-ХХ-ХХ, 7(ХХХ)ХХХ-ХХ-ХХ. Введите номер телефона снова: ");
                //    phone = Console.ReadLine();
                //}
            //}

            //while (check_case_surname == false)
            //{
                check_case_surname = CheckCase(sur);

                //if (check_case_surname == false)
                //{
                //    Console.Write("Фамилия написана с маленькой буквы. Введите фамилию: ");
                //    sur = Console.ReadLine();
                //}
            //}

            //while (check_case_name == false)
            //{
                check_case_name = CheckCase(name);

                //if (check_case_name == false)
                //{
                //    Console.Write("Имя написано с маленькой буквы. Введите имя: ");
                //    name = Console.ReadLine();
                //}
            //}

            //while (check_case_secondname == false)
            //{
                check_case_secondname = CheckCase(sname);

            //if (check_case_secondname == false)
            //{
            //    Console.Write("Отчество написано с маленькой буквы. Введите отчество: ");
            //    sname = Console.ReadLine();
            //}
            //}

            if (check_email && check_phone && check_case_surname && check_case_name && check_case_secondname)
            {
                
                Users_Directory.Add(new Users(Users_Directory.Last().idUser + 1, sur, name, sname, phone, email, true));
                return true;
            }
            else
                return false;
        }

        public void WillBlocked(List<Users> Users_Directory)
        {
            List<int> ids = new List<int>();
            int id_select = 0;
            Console.WriteLine("\nСписок идентификаторов пользователей, доступных для блокировки:");

            foreach (var us in Users_Directory)
                if (us.blocked)
                {
                    ids.Add(us.idUser);
                    Console.WriteLine(us.idUser);
                }

            id_select = Select(ids, id_select);

            Users user = Find(id_select, Users_Directory);
            save_change_txt.SaveChanges(System.Security.Principal.WindowsIdentity.GetCurrent().Name, user, user.blocked.ToString(), Convert.ToString(!user.blocked));
            user.blocked = !user.blocked;

            Console.WriteLine("Пользователь заблокирован.");
        }

        public bool Delete(int id_select, List<Users> Users_Directory)
        {
            List<int> ids = new List<int>();
            int count_old = Users_Directory.Count;

            //Console.WriteLine("\nСписок идентификаторов пользователей, доступных для удаления:");

            foreach (var us in Users_Directory)
            {
                ids.Add(us.idUser);
                //Console.WriteLine(us.idUser);
            }

            id_select = Select(ids, id_select);
            if (id_select == 0)
                return false;

            Users user = Find(id_select, Users_Directory);

            Users_Directory.Remove(user);

            int count_new = Users_Directory.Count;

            if (count_new != count_old)
                return true;
            else 
                return false;
            //Console.WriteLine("Пользователь удалён.");
        }

        public bool Change(List<Users> Users_Directory, string item, string meaning, int id_select)
        {
            List<int> ids = new List<int>();
            //int id_select = 0;

            //Console.WriteLine("\nСписок идентификаторов пользователей, доступных для изменения:");

            foreach (var us in Users_Directory)
            {
                ids.Add(us.idUser);
                //Console.WriteLine(us.idUser);
            }

            id_select = Select(ids, id_select);

            Users user = Find(id_select, Users_Directory);

            //Console.Write($"\nВыбирите пункт для изменения:\nФамилия: {user.surname}\nИмя: {user.name}\nОтчество: {user.secondname}\n" +
            //$"Номер телефона: {user.phoneNumber}\nE-mail: {user.email}\nВыберети пунтк для изменения: ");

            //string item = Console.ReadLine();   

            if (Switch(user, item, meaning))
                return true;
            else 
                return false;

            //Console.WriteLine("Изменения сохранены.");
        }

        private bool Switch(Users user, string item, string meaning)
        {
            bool check_email = false;
            bool check_phone = false;
            bool check_case_surname = false;
            bool check_case_name = false;
            bool check_case_secondname = false;            

            switch (item)
            {
                case "Фамилия":
                    //Console.Write("Введите новую фамилию: ");
                    string surname = meaning;
                    //while (check_case_surname == false)
                    //{
                        check_case_surname = CheckCase(surname);

                    //if (check_case_surname == false)
                    //{
                    //    Console.Write("Фамилия написана с маленькой буквы. Введите фамилию: ");
                    //    surname = Console.ReadLine();
                    //}
                    //}
                    if (check_case_surname)
                    {
                        save_change_txt.SaveChanges(System.Security.Principal.WindowsIdentity.GetCurrent().Name, user, user.surname, surname);
                        user.surname = surname;
                        return true;
                    }
                    else
                        return false;
                     break;
                case "Имя":
                    //Console.Write("Введите новое имя: ");
                    string name = meaning;
                    //while (check_case_name == false)
                    //{
                        check_case_name = CheckCase(name);

                    //if (check_case_name == false)
                    //{
                    //    Console.Write("Имя написано с маленькой буквы. Введите имя: ");
                    //    name = Console.ReadLine();
                    //}
                    //}
                    if (check_case_name)
                    {
                        save_change_txt.SaveChanges(System.Security.Principal.WindowsIdentity.GetCurrent().Name, user, user.name, name);
                        user.name = name;
                        return true;
                    }
                    else
                        return false;
                    break;
                case "Отчество":
                    //Console.Write("Введите новое отчество: ");
                    string secondname = meaning;
                    //while (check_case_secondname == false)
                    //{
                        check_case_secondname = CheckCase(secondname);

                    //    if (check_case_secondname == false)
                    //    {
                    //        Console.Write("Отчество написано с маленькой буквы. Введите отчество: ");
                    //        secondname = Console.ReadLine();
                    //    }
                    //}
                    if (check_case_secondname)
                    {
                        save_change_txt.SaveChanges(System.Security.Principal.WindowsIdentity.GetCurrent().Name, user, user.secondname, secondname);
                        user.secondname = secondname;
                        return true;
                    }
                    else
                        return false;
                    break;
                case "Номер телефона":
                    //Console.Write("Введите новый номер телефона: ");
                    string phone = meaning;
                    //while (check_phone == false)
                    //{
                        check_phone = CheckPhone(phone);

                    //    if (check_phone == false)
                    //    {
                    //        Console.Write("Номер телефона не соответсвует фомату 8(ХХХ)ХХХ-ХХ-ХХ, 7(ХХХ)ХХХ-ХХ-ХХ. Введите номер телефона снова: ");
                    //        phone = Console.ReadLine();
                    //    }
                    //}
                    if (check_phone)
                    {
                        save_change_txt.SaveChanges(System.Security.Principal.WindowsIdentity.GetCurrent().Name, user, user.phoneNumber, phone);
                        user.phoneNumber = phone;
                        return true;
                    }
                    else
                        return false;
                    break;
                case "E-mail":
                    //Console.Write("Введите новый e-mail: ");
                    string email = Console.ReadLine();
                    //while (check_email == false)
                    //{
                        check_email = CheckEmail(email);

                    //    if (check_email == false)
                    //    {
                    //        Console.Write("Неверный введённый e-mail. Введите e-mail снова: ");
                    //        email = Console.ReadLine();
                    //    }
                    //}
                    if (check_email)
                    {
                        save_change_txt.SaveChanges(System.Security.Principal.WindowsIdentity.GetCurrent().Name, user, user.email, email);
                        user.email = email;
                        return true;
                    }
                    else
                        return false;
                    break;
            }
            return false;
        }
        private int Select(List<int> ids, int id_select)
        {
            bool checkID = false;
            //while (!checkID)
            //{
                //Console.Write("Выберети идентификатор пользователя: ");
                //id_select = int.Parse(Console.ReadLine());               
                for (int i = 0; i < ids.Count; i++)
                {
                    if (ids[i] == id_select)
                    {
                        checkID = true;
                        break;
                    }
                    else
                        checkID = false;
                }
                try
                {
                    if (!checkID)
                    {
                        throw new ErrorWongId("Ошибка: Неверно введён id пользователя");                       
                    }
                    else
                    {
                        return id_select;
                    }
                }
                catch(ErrorWongId ex) {
                    //Console.WriteLine(ex.Message);
                    saveLogTXT.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString()); 
                }
            //}

            return 0;
        }

        private Users Find(int id, List<Users> Users_Directory)
        {
            return Users_Directory.Find(us => us.idUser == id);
        }

        private bool CheckEmail(string email)
        {
            try
            {
                string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
                if (Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
                    return true;
                else
                    throw new ErrorWrongEmail("Ошибка: Введён невенрный email");
            }
            catch(ErrorWrongEmail ex) 
            {
                //Console.WriteLine(ex.Message);
                saveLogTXT.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                return false;
            }
        }
        private bool CheckPhone(string phone)
        {
            string pattern = @"^(8|7)\([0-9]{3}\)\d{3}-\d{2}-\d{2}";
            try
            {
                if (Regex.IsMatch(phone, pattern, RegexOptions.IgnoreCase))
                    return true;
                else
                    throw new ErrorWrongPhone("Ошибка: Введён неверный номер телефона");
            }
            catch (ErrorWrongPhone ex)
            {
                //Console.WriteLine(ex.Message);
                saveLogTXT.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                return false;
            }
        }

        private bool CheckCase(string initial)
        {
            try
            {
                bool check = false;
                for (int i = 1; i < initial.Length; i++)
                    if (Char.IsUpper(initial, 0) && Char.IsLower(initial, i))
                        check = true;
                    else                        
                        check = false;
                if (check)
                    return true;
                else
                    throw new ErrorWrongLetter("Ошибка: Слово введено неверно");
            }
            catch (ErrorWrongLetter ex)
            {
                //Console.WriteLine(ex.Message);
                saveLogTXT.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                return false;
            }
        }
    }
}
