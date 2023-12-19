using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Directory
{
    public class SaveLogTxt : SaveLog
    {
        public void Save(Exception error, string App_Name)
        {
            StackTrace traceLog = new StackTrace();
            var sb = new StringBuilder();
            var trace = new StackTrace(error, true);
            foreach (var frame in trace.GetFrames())
            {
                sb.Append($"Строка:{frame.GetFileLineNumber()}\t");
                sb.Append($"Столбец:{frame.GetFileColumnNumber()}\t");
                sb.Append($"Метод:{frame.GetMethod()}");
            }
            using (StreamWriter writer = new StreamWriter("Error.txt", true))
            {
                writer.Write($"{error.Message}\t{DateTime.Now}\tUTC:{DateTime.Now.ToUniversalTime()}\t{App_Name}\t{sb}||");
            }
        }
    }
}
