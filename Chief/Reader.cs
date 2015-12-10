using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Chief
{
    public class Reader
    {
        public List<string> ReadText(string file)
        {
            var results = new List<string>();

            var streamReader = new StreamReader(file, Encoding.GetEncoding("GB2312"));
            var read = string.Empty;
            while ((read = streamReader.ReadLine()) != null)
            {
                results.Add(read);
            }
            streamReader.Close();

            return results;
        }
    }
}
