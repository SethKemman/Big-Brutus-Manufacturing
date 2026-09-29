using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Brutus_Manufacturing
{
    public abstract class Event
    {
        public string Content { get; protected set; }
        public int Level { get; protected set; } // level 1 = informational, level 2 = warning, level 3 = critical

        public Zone Zone { get; protected set; }

        public string HardwareType { get; protected set; }

        public DateTime time { get; protected set; }



        
    }

    public class Meting : Event
    {

        protected Logbook<Meting> _metingen = new Logbook<Meting>();
        public Logbook<Meting> Metingen { get { return _metingen; } }

        public Meting(string content, int level, Zone zone, string hardware)
        {
            this.Content = content;
            this.Level = level;
            this.Zone = zone;
            this.HardwareType = hardware;
            this.time = DateTime.Now;

            Metingen.Add(this);
        }

    }
}
