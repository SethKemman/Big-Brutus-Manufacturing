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

            EnergieSensor energieSensor = new EnergieSensor("Energiesensor 1", 1, zone1);
            EnergieSensor energieSensor2 = new EnergieSensor("Energiesensor 2", 2, zone1);

            


            foreach (HardwareComponent component in zone1.HardwareComponents)
            {
                Console.WriteLine(component.Name);
            }

            //Terminal terminal = new Terminal();



        }

    }
    
}