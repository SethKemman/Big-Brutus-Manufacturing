using System.ComponentModel;
using System.Reflection;

namespace Big_Brutus_Manufacturing { 

    class Program
    {
        static void Main(string[] args)
        {
            Campus campus1 = new Campus("CHE");
            Building gebouw1 = new Building("Building Alpha");
            Building gebouw2 = new Building("Building Beta");
            campus1.AddBuilding(gebouw1);
            campus1.AddBuilding(gebouw2);
            Zone zone1 = new Zone("joehoe");

            Logbook<Meting> logbook = new Logbook<Meting>(); // Logbook voor metingen
            EnergieSensor energieSensor = new EnergieSensor("Energiesensor 1", 1, zone1, logbook);
            EnergieSensor energieSensor2 = new EnergieSensor("Energiesensor 2", 2, zone1, logbook);
            // 
            // Console.WriteLine(energieSensor.Name);
            // Console.WriteLine(energieSensor2.Name)

            energieSensor.LogEvent("Nieuwe update", Level.Informational);
            Thread.Sleep(2000);
            energieSensor2.LogEvent("Sensor loopt vast", Level.Critical);

            foreach (Meting meting in logbook.Logs)
            {
                Console.WriteLine(meting.Content + $"Met level {meting.Level}");
            }


            foreach (HardwareComponent component in zone1.HardwareComponents)
            {
                Console.WriteLine(component.Name);
                if (component.GetType() == typeof(EnergieSensor))
                {
                    EnergieSensor energieding = (EnergieSensor)component;
                    //energieding.LogEvent($"Naam van sensor is {component.Name}", 1);
                }
            }

            //Terminal terminal = new Terminal();



        }

    }
    
}