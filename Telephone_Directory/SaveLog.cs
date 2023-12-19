using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Directory
{
    internal interface SaveLog
    {
        void Save(Exception error, string App_Name);
    }
}
