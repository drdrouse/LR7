using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Directory
{
    public class ErrorWrongLetter:Exception
    {
        public ErrorWrongLetter(string message) : base(message)
        {

        }
    }
}
