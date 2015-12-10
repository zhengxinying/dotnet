using System.Collections.Generic;
using System.IO;

namespace Chief.InOut
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
