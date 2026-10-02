using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Brutus_Manufacturing
{

    public class Logbook<T> where T : Event // alle dingen die worden gelogd zijn events.
    {

        private List<T> _logs = new List<T>();

        public IReadOnlyList<T> Logs { get { return _logs; } }

        public void Add(T item)
        {
            if (item == null)
            {
                return;
            }
            _logs.Add(item);
        }

        public void Remove(T item)
        {
            if (item == null)
            {
                return;
            }
            _logs.Remove(item);
        }

        public List<T> LogsByLevel(Level level)
        {
            return Logs.Where(o => o.Level == level).ToList();
            
        }

        public List<T> LogsByTime()
        {
            return Logs.OrderBy(o => o.time).ToList();
        }

        public void Wipe()
        {
            _logs.Clear();
        }
    }
}
