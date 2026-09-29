using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Brutus_Manufacturing
{
    public abstract class HardwareComponent //abstract, geen constructor.
    {
        public string Name { get; protected set; } // Only set during init.

        public int Id { get; protected set; } // Only set during init.

        public Zone Zone { get; protected set; }


        public void StuurGegevens()
        {
            //Implementeer dit later
            throw new NotImplementedException();
        }

        public virtual void LogEvent() //Hier komt een event argument. Moet de virtual naar abstract veranderen zodra ik klaar ben met het implementeren voor de andere functies.
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

        public EnergieSensor(string name, int id, Zone zone) {
            this.Name = name;
            this.Id = id;
            this.Zone = zone;
            zone.addComponent(this);
            
        }

        public void LogEvent(string name, int level)
        {
            //to be implemented
            
        }
    }

    public class Thermostaat : HardwareComponent
    {
        private int _temperature;

        public int Temperature { get { return _temperature; } set
            {
                if (value >= -20 && value <= 60)
                {
                    _temperature = value;
                }
            }
        }
        public Thermostaat(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
    public class DimbareLamp : HardwareComponent
    {
        private int _brightness;
        public int Brightness { get { return _brightness; } set
            {
                if (value >= 0 && value <= 100)
                {
                    _brightness = value;
                }
            }
        }


        public DimbareLamp(string name, int id) {
            this.Name = name;
            this.Id = id;
        }

    }
    public class Ventilator : HardwareComponent
    {
        public Ventilator() { }
    }
}
