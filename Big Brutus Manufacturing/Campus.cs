using BigBrutus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Brutus_Manufacturing
{
    public class Campus //class
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private List<Building> _buildings = new List<Building>();
        public IReadOnlyList<Building> Buildings
        {

            get { return _buildings; }
        }

        public Campus(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Naam mag niet leeg zijn.");
            }
            _name = name;
        }

        public void AddBuilding(Building building) // Method om Buildings toe te voegen aan de campus
        {
            if (building == null || Buildings.Contains(building) == true)
            {
                throw new ArgumentException("Building is null of is al toegevoegd.");
            }
            _buildings.Add(building);
            building.Campus = this;
        }

        public void RemoveBuilding(Building building)
        {
            if (building == null || Buildings.Contains(building) == false)
            {
                throw new ArgumentException("Moet dit nog implementeren");
            }
            _buildings.Remove(building);
        }
    }
}
