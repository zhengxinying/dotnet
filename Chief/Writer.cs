using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Chief
{
    public class Writer
    {
        public void WriteText(string file, List<string> output)
        {
            var streamWriter = new StreamWriter(file);

            foreach (var o in output)
            {
                streamWriter.WriteLine(o);
            }
            streamWriter.Close();
        }
    }
}
