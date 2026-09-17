using Big_Brutus_Manufacturing;

namespace BigBrutus { 

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
            foreach (var building in campus1.Buildings)
            {
                Console.WriteLine(building.Name);
            }
            Console.WriteLine("-----------------");

            EnergieSensor energieSensor = new EnergieSensor();
            energieSensor.Name = "Energiesensor 1";
            EnergieSensor energieSensor2 = new EnergieSensor();
            energieSensor2.Name = "Energiesensor 2";

            Console.WriteLine(energieSensor.Name);
            Console.WriteLine(energieSensor2.Name);
            
        }

    }
    
    }