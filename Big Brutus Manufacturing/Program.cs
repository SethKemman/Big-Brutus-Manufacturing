using System.ComponentModel;
using System.Reflection;

namespace Big_Brutus_Manufacturing { 

    class Program
    {

        public static class Globals
        {
            public static Logbook<Meting> MetingLogbook;
            public static Campus campus;
        }

            static void Main(string[] args)
        {
            Globals.campus = new Campus("CHE");

            Building gebouw1 = new Building("Building Alpha");
            Building gebouw2 = new Building("Building Beta");

            Globals.campus.AddBuilding(gebouw1);
            Globals.campus.AddBuilding(gebouw2);
            Zone zone1 = new Zone("ZoneA");
            Zone zone2 = new Zone("ZoneB");
            gebouw1.addZone(zone1);
            gebouw1.addZone(zone2);

            Globals.MetingLogbook = new Logbook<Meting>();

            EnergieSensor energieSensor = new EnergieSensor("Energiesensor 1", 1, zone1, Globals.MetingLogbook);
            EnergieSensor energieSensor2 = new EnergieSensor("Energiesensor 2", 2, zone1, Globals.MetingLogbook);

            Ventilator ventilator1 = new Ventilator("UltraVent", 1, zone2, Globals.MetingLogbook);
            Ventilator ventilator2 = new Ventilator("SuperVentilator", 2, zone2, Globals.MetingLogbook);

            DimbareLamp lamp1 = new DimbareLamp("MooiLampje", 1, zone2, Globals.MetingLogbook);
            lamp1.SetBrightness(0);
            ventilator2.SetRPM(0);


            Terminal terminal = new Terminal();



        }

    }

}