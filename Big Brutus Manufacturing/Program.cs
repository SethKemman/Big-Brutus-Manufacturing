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
           
            Logbook<Meting> MetingLogbook = new Logbook<Meting>();

            EnergieSensor energieSensor = new EnergieSensor("Energiesensor 1", 1, zone1, MetingLogbook);
            EnergieSensor energieSensor2 = new EnergieSensor("Energiesensor 2", 2, zone1, MetingLogbook);

            energieSensor.LogEvent("Nieuwe update", Level.Informational);
            Thread.Sleep(2000);
            energieSensor2.LogEvent("Sensor loopt vast", Level.Critical);

            foreach (Meting meting in MetingLogbook.LogsByLevel(Level.Informational))
            {
                Console.WriteLine($"{meting.Level}: {meting.Content} @ {meting.time}");
            }


            //Terminal terminal = new Terminal();



        }

    }
    
}