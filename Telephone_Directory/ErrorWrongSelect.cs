using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Directory
{
    public class ErrorWrongSelect : Exception
    {
        public ErrorWrongSelect(string message) : base(message)
        {

        }
    }
}
