using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Brutus_Manufacturing
{
    public class Logbook<T>
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
    }
}
