using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Directory
{
    public class ErrorWongId:Exception
    {
        public ErrorWongId(string message) : base(message)
        {

        }
    }
}
