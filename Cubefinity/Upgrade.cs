using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubefinity
{
    [Serializable]
    public class Upgrade
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public bool IsActive { get; set; }
        public Upgrade() { }
        public Upgrade(string name, double cost)
        {
            Name = name;
            Cost = cost;
            IsActive = false;
        }

        public bool CanAfford(double cubes)
        {
            return cubes >= Cost;
        }

        public void Buy()
        {
            IsActive = true;
        }

        public void Reset()
        {
            IsActive = false;
        }

    }
}
