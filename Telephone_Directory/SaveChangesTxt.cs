using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Directory
{
    public class SaveChangesTxt : SaveChanges
    {
        public void SaveChanges(string Name_User,Users user, string old, string change)
        {
            using (StreamWriter writer = new StreamWriter("Change.txt", true))
            {
                writer.Write($"Пользователь: {Name_User}\t" +
                    $"Объект: {user.idUser} {user.surname} {user.name} {user.secondname} {user.phoneNumber} {user.email} {user.blocked}" +
                    $"Меняем: {old} -> {change}||");
            }
        }
    }
}
