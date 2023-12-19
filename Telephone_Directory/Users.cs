using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Directory
{
    public class Users
    {
        private int IdUser;
        private string Surname;
        private string Name;
        private string Secondname;
        private string PhoneNumber;
        private string Email;
        private bool Blocked;

        public Users(int Id, string Sur, string Name, string SecName, string PhoNum, string email, bool Block)
        {
            this.IdUser = Id;
            this.Surname = Sur;
            this.Name = Name;
            this.Secondname = SecName;
            this.PhoneNumber = PhoNum;
            this.Email = email;
            this.Blocked = Block;
        }

        public int idUser { get => IdUser; set => IdUser = value; }
        public string surname { get => Surname; set => Surname = value; }
        public string name { get => Name; set => Name = value; }
        public string secondname { get => Secondname; set => Secondname = value; }
        public string phoneNumber { get => PhoneNumber; set => PhoneNumber = value; }
        public string email { get => Email; set => Email = value; }
        public bool blocked { get => Blocked; set => Blocked = value; }
    }
}
