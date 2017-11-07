using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public interface IConnection
    {
        void dial();
        void hangup();
    }
}