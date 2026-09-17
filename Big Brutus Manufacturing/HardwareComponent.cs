using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Brutus_Manufacturing
{
    public abstract class HardwareComponent //abstract, geen constructor.
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
}
