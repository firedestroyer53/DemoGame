using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGame
{
    internal class Type
    {
        // change the strings of weakness resistance and immunity to lists
        public string Name { get; set; }
        public List<Type> Weaknesses { get; set; }
        public List<Type> Resistances { get; set; }
        public List<Type> Immunities { get; set; }

        
        
        public Type(string name, List<Type> weaknesses, List<Type> resistances, List<Type> immunities)
        {
            Name = name;
            Weaknesses = weaknesses;
            Resistances = resistances;
            Immunities = immunities;
        }
        // add a to string method that returns the name of the type, the weaknesses, the resistances, and the immunities
        public override string ToString()
        {
            return $"{Name} is weak to {Weaknesses}, resistant to {Resistances}, and immune to {Immunities}";
        }
        // when called in Item.cs, make it so it just says the name of the type
        public string ToString2()
        {
            return $"{Name}";
        }
    }
}
