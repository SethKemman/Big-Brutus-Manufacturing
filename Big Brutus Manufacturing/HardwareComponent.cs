using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace Big_Brutus_Manufacturing
{

    public abstract class HardwareComponent //abstract, zonder constructor.
    {
        public int PowerUsage { get; protected set; }
        public string Name { get; protected set; } // Only set during init.

        public int Id { get; protected set; } // Only set during init.

        public Zone Zone { get; protected set; }

        public virtual void LogEvent()
        {
            throw new NotImplementedException();
        }

        public virtual void VoerDiagnoseUit()
        {
            throw new NotImplementedException();
        }

        public virtual int BerekenHuidigVerbruik()
        {
            throw new NotImplementedException();
        }

    }

    public abstract class  SensorTemplate : HardwareComponent
    {
        

        private Logbook<Meting> logbook;
        public SensorTemplate(string name, int id, Zone zone, Logbook<Meting> logbook)
        {

            this.Name = name;
            this.Id = id;
            this.Zone = zone;
            this.logbook = logbook;
            this.PowerUsage = 3; //3 watt
            zone.addComponent(this);
        }

        public void LogEvent(string content, Level level)
        {
            Meting meting = new Meting(content, level, this.Zone, this.GetType().Name);
            logbook.Add(meting);

        }
        public override void VoerDiagnoseUit()
        {
            LogEvent($"PlaceholderDiagnose voor device {this.Id} in {this.Zone.Name}", Level.Placeholder); // Ik heb echt werkelijk geen idee wat de functionaliteit van de sensoren is. Ik bedoel ik snap dat een bewegingssensor een functie kan krijgen als MovementDetected() die dan een logevent aanmaakt ofzo, maar ik zie in de huidige casus hier nog niet echt een nut voor. Dan zou ik een random bool maken (random int tussen 1 en 2, 1 is true 2 is false bijvoorbeeld) die dan bij true een logevent doet. Niet echt nuttig.
        }

        public override int BerekenHuidigVerbruik()
        {
            return PowerUsage;
        }

    }

    public abstract class DeviceTemplate : HardwareComponent
    {

        public bool Power { get; protected set;  } = false;

        protected Logbook<Meting> logbook;
        public DeviceTemplate(string name, int id, Zone zone, Logbook<Meting> logbook)
        {

            this.Name = name;
            this.Id = id;
            this.Zone = zone;
            this.logbook = logbook;
            zone.addComponent(this);
            this.PowerUsage = 3; //3 watt
        }

        public void LogEvent(string content, Level level)
        {
            Meting meting = new Meting(content, level, this.Zone, this.GetType().Name);
            logbook.Add(meting);

        }
        public override void VoerDiagnoseUit()
        {
            throw new NotImplementedException();
        }

        public override int BerekenHuidigVerbruik()
        {
            return PowerUsage;
        }

        public void SetPower(bool power) // Om devices in en uit te schakelen
        {
            this.Power = power;
        }

    }

    public class TemperatuurSensor : SensorTemplate
    {
        public TemperatuurSensor(string name, int id, Zone zone, Logbook<Meting> logbook) : base(name, id, zone, logbook) { }
    }
    public class BewegingSensor : SensorTemplate
    {
        public BewegingSensor(string name, int id, Zone zone, Logbook<Meting> logbook) : base(name, id, zone, logbook) { }
    }
    public class EnergieSensor : SensorTemplate
    {
        public EnergieSensor(string name, int id, Zone zone, Logbook<Meting> logbook) : base(name, id, zone, logbook) { }
    }

    public class Thermostaat : DeviceTemplate
    {
        private int _temperature;


        public int Temperature { get { return _temperature; } set
            {
                if (value >= -20 && value <= 60)
                {
                    _temperature = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Temperature");
                }
            }
        }
        public Thermostaat(string name, int id, Zone zone, Logbook<Meting>logbook) : base(name, id, zone, logbook)
        {
            this.PowerUsage = 4;
            this.Power = true;
        }

        public override void VoerDiagnoseUit()
        {
            if (Power == true)
            {
                LogEvent($"Thermostaat {this.Id} in {this.Zone.Name} is ingesteld met {this.Temperature}", Level.Informational);
            }
            else
            {
                LogEvent($"Thermostaat {this.Id} in {this.Zone.Name} is uitgeschakeld", Level.Warning);
            }
        }

        public override int BerekenHuidigVerbruik()
        {
            if (this.Power == false)
            {
                return 0;
            }
            else
            {
                return PowerUsage;
            }
        }

        public void setTemperature(int temperature)
        {
            this.Temperature = temperature;
        }
    }
    public class DimbareLamp : DeviceTemplate
    {
        private int _brightness;
        public int Brightness { get { return _brightness; } set
            {
                if (value >= 0 && value <= 100)
                {
                    _brightness = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Brightness");
                }
            }
        }

        public DimbareLamp(string name, int id, Zone zone, Logbook<Meting> logbook) : base(name, id, zone, logbook)
        {
            this.Power = true;
            this.PowerUsage = 12; //12 watts
        }
        public override void VoerDiagnoseUit()
        {
            if (this.Power == true)
            {
                if (Brightness > 0)
                {
                    LogEvent($"Lamp {this.Id} in {this.Zone.Name} brandt met een helderheid van {Brightness}%", Level.Informational);
                }
                else
                {
                    LogEvent($"Lamp {this.Id} in {this.Zone.Name} brandt met een helderheid van {Brightness}%. Overweeg om de lamp uit te schakelen.", Level.Warning);
                }
            }
            else
            {
                LogEvent($"Lamp {this.Id} in {this.Zone.Name} is op het moment uitgeschakeld.", Level.Informational);
            }

        }

        public override int BerekenHuidigVerbruik()
        {
            if (this.Power == false)
            {
                return 0;
            }
            else
            {
                return ((PowerUsage / 100) * Brightness);
            }
        }

        public void SetBrightness(int brightness)
        {
            this.Brightness = brightness;
        }

    }
    public class Ventilator : DeviceTemplate
    {
        private int _RPM = 40; //default value
        public int RPM
        {
            get { return _RPM; }
            set
            {
                if (value >= 0 && value <= 40)
                {
                    _RPM = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("RPM");
                }
            }
        }
        public Ventilator(string name, int id, Zone zone, Logbook<Meting> logbook) : base(name, id, zone, logbook) 
        {
            this.PowerUsage = 40; //40 watt.
            this.Power = true;
        }
        public override void VoerDiagnoseUit()
        {
            if (this.Power == true)
            {
                if (RPM > 0)
                {
                    LogEvent($"Ventilator {this.Id} in {this.Zone.Name} draait {RPM}", Level.Informational);
                }
                else
                {
                    LogEvent($"Ventilator {this.Id} is ingeschakeld maar draait niet.", Level.Critical); //Dit is gekker dan een lamp met 0% brightness, dus daarom critical. Dit zou ook een mechanische fout kunnen zijn namelijk.
                }
                
            }
            else
            {
                LogEvent($"Ventilator {this.Id} in {this.Zone.Name} is currently turned off.", Level.Informational);
            }
        }

        public override int BerekenHuidigVerbruik()
        {
            if (this.Power == false)
            {
                return 0;
            }
            else
            {
                return (PowerUsage / 40) * RPM;
            }
        }

        public void SetRPM(int rpm)
        {
            this.RPM = rpm;
        }
    }
}
