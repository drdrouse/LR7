using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Directory
{
    public class ErrorWrongPhone:Exception
    {
        public ErrorWrongPhone(string message) : base(message)
        {

        }
    }
}
