using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreDisposeDemo.Helpers
{
    public class DateTimeHelpers
    {
        public DateTimeHelpers()
        {
            LocalTime = DateTime.Now.TimeOfDay.ToString();
        }
        public string LocalTime { get; private set; }
    }
}
