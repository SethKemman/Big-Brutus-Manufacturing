using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Brutus_Manufacturing
{
    public class Zone
    {
        public string Name { get;  } // Only set during init.

        public int Id { get; } // Only set during init.

        private List<HardwareComponent> _hardwareComponents = new List<HardwareComponent>();

        public IReadOnlyList<HardwareComponent> HardwareComponents
        {
            get { return _hardwareComponents; }
        }

        public Zone(string name)
        {
            this.Name = name;
        }

        public void addComponent(HardwareComponent component)
        {
            if (component == null)
            {
                return;
            }
            _hardwareComponents.Add(component);
        }

    };
}
