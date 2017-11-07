using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public interface IDataChannel
    {
        void send();
        void recv();
    }
}