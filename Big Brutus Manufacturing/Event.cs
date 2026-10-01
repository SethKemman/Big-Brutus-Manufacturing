using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Brutus_Manufacturing
{

    public enum Level
    {
        Informational,
        Warning,
        Critical

    }
    public abstract class Event
    {
        public string Content { get; protected set; }
        public Level Level { get; protected set; } // level 1 = informational, level 2 = warning, level 3 = critical

        public Zone Zone { get; protected set; }

        public string HardwareType { get; protected set; }

        public DateTime time { get; protected set; }



        
    }

    public class Meting : Event
    {
        public Meting(string content, Level level, Zone zone, string hardware)
        {
            this.Content = content;
            this.Level = level;
            this.Zone = zone;
            this.HardwareType = hardware;
            this.time = DateTime.Now;
        }

    }
}
