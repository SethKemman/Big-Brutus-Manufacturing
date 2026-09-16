namespace BigBrutus { 

    public class Campus //class
    {
        private string _name;
        private List<Gebouw> _gebouwen = new List<Gebouw>();
        public Campus(string naam) 
        {
            if (string.IsNullOrWhiteSpace(naam)) { 
                throw new ArgumentException("Naam mag niet leeg zijn."); 
            }
            _name = naam;
        }

        public void addGebouw(Gebouw gebouw) // Method om gebouwen toe te voegen aan de campus
        {
            if (gebouw == null || _gebouwen.Contains(gebouw) == true)
            {
                throw new ArgumentException("Gebouw is null of is al toegevoegd.");
            }
            _gebouwen.Add(gebouw);
            gebouw.Campus = this;
        }

        public void removeGebouw(Gebouw gebouw)
        {
            if (gebouw == null || _gebouwen.Contains(gebouw) == false)
            {
                throw new ArgumentException("Moet dit nog implementeren");
            }
            _gebouwen.Remove(gebouw);
        }
    }
    public class Gebouw
    {
        private string _name;
        private List<Zone> _zones = new List<Zone>();

        public Campus? Campus;
        public Gebouw(string name)
        {
            if (name == null) { return ;}
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

    public class Zone
    {
        public Zone() { 
        }
    }
}