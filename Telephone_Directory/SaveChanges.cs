using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Directory
{
    internal interface SaveChanges
    {
        void SaveChanges(string Name_User, Users user, string old, string change);
    }
}
