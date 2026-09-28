using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Brutus_Manufacturing
{
    public class Building
    {
        public string Name { get; } // Only set during initialization.
        private List<Zone> _zones = new List<Zone>();
        public IReadOnlyList<Zone> Zones { get { return _zones; } }

        public Campus? Campus;
        public Building(string name)
        {
            if (name == null) { return; }
            this.Name = name;
        }

        public void addZone(Zone zone)
        {
            if (zone == null || _zones.Contains(zone) == true)
            {
                return;
            }
            _zones.Add(zone);
        }
        public void removeZone(Zone zone)
        {
            if (zone == null || _zones.Contains(zone) == false)
            {
                return;
            }
            _zones.Remove(zone);
        }
    }
}
