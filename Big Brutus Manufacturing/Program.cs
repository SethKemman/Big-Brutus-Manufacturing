namespace BigBrutus { 

    public class Campus //class
    {
        private string _name;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }
        private List<Gebouw> _gebouwen = new List<Gebouw>();
        public IReadOnlyList<Gebouw> Gebouwen {
        
            get {  return _gebouwen; }
        }

        public Campus(string name) 
        {
            if (string.IsNullOrWhiteSpace(name)) { 
                throw new ArgumentException("Naam mag niet leeg zijn."); 
            }
            _name = name;
        }

        public void AddGebouw(Gebouw gebouw) // Method om gebouwen toe te voegen aan de campus
        {
            if (gebouw == null || Gebouwen.Contains(gebouw) == true)
            {
                throw new ArgumentException("Gebouw is null of is al toegevoegd.");
            }
            _gebouwen.Add(gebouw);
            gebouw.Campus = this;
        }

        public void RemoveGebouw(Gebouw gebouw)
        {
            if (gebouw == null || Gebouwen.Contains(gebouw) == false)
            {
                throw new ArgumentException("Moet dit nog implementeren");
            }
            _gebouwen.Remove(gebouw);
        }
    }
    public class Gebouw
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private List<Zone> _zones = new List<Zone>();
        public IReadOnlyList<Zone> Zones { get { return  _zones; }  }

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
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        private int _id;

        public int Id { get { return _id; } } // readonly

        private List<HardwareComponent> _hardwareComponents = new List<HardwareComponent>();

        public IReadOnlyList<HardwareComponent> HardwareComponents
        {
            get { return _hardwareComponents; }
        }
        public Zone(string name)
        {
            this._name = name;
        }
        
    };

    public class HardwareComponent //abstract, geen constructor.
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        private int _id;

        public int Id { get { return _id; } set { _id = value; } }

        public void StuurGegevens()
        {
            //Implementeer dit later
            throw new NotImplementedException();
        }

        public void LogEvent() //Hier komt een event argument
        {
            throw new NotImplementedException();
        }
    }

    public class TemperatuurSensor : HardwareComponent
    {
        public TemperatuurSensor() { }
    }
    public class Bewegingsensor : HardwareComponent
    {
        public Bewegingsensor() { }
    }
    public class EnergieSensor : HardwareComponent
    {
        public EnergieSensor() { }
    }

    public class Thermostaat : HardwareComponent
    {
        public Thermostaat() { }
    }
    public class DimbareLamp : HardwareComponent
    {
        public DimbareLamp() { }
    }
    public class Ventilator : HardwareComponent
    {
        public Ventilator() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Campus campus1 = new Campus("CHE");
            Gebouw gebouw1 = new Gebouw("Gebouw Alpha");
            Gebouw gebouw2 = new Gebouw("Gebouw Beta");
            campus1.AddGebouw(gebouw1);
            campus1.AddGebouw(gebouw2);
            Zone zone1 = new Zone("joehoe");
            foreach (var gebouw in campus1.Gebouwen)
            {
                Console.WriteLine(gebouw.Name);
            }

        }

    }
    
    }