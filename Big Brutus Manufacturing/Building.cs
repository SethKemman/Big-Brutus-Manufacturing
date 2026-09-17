using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Brutus_Manufacturing
{
    public class Building
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private List<Zone> _zones = new List<Zone>();
        public IReadOnlyList<Zone> Zones { get { return _zones; } }

        public Campus? Campus;
        public Building(string name)
        {
            if (name == null) { return; }
            _name = name;
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
