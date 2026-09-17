using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Brutus_Manufacturing
{
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
}
