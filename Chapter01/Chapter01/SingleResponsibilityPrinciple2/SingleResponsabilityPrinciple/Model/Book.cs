using System;
using System.Collections.Generic;
using System.Text;

class Book : IBook
{
    public string Author { get; set; }
    public double Price { get; set; }
    public string Title { get; set; }
}
