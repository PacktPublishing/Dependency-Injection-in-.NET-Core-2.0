using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using InterfaceSegregationPrinciple.Model;

namespace InterfaceSegregationPrinciple.Utilities
{
    internal class Utilities
    {
        internal static List<Product> ReadData(string fileId)
        {
            var filename = "Data/ProductStore" + fileId + ".json";
            var cadJSON = ReadFile(filename);
            return JsonConvert.DeserializeObject<List<Product>>(cadJSON);
        }

        internal static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }

    }
}
