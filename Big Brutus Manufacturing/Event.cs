using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Brutus_Manufacturing
{
    public class Event
    {
        public string Name { get; set; }
        public int Level { get; private set; } // level 1 = informational, level 2 = warning, level 3 = critical

        public Zone Zone { get; private set; }

        public string HardwareType { get; private set; }

        public DateTime time { get; private set; }

        public Event(string name, int level, Zone zone, string hardware)
        {
            this.Name = name;
            this.Level = level;
            this.Zone = zone;
            this.HardwareType = hardware;
            this.time = DateTime.Now;
        }
    }
}
