using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationPrinciple.Model
{
    interface IProduct
    {
        string Title { get; set; }
        string Author { get; set; }
        double Price { get; set; }
        string Topic { get; set; }
        string Duration { get; set; }
    }

    internal class Product: IProduct
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Topic { get; set; }
        public string Duration { get; set; }

    }
}
