using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGame
{
    [Serializable]
    internal class World
    {
        //randomly generate a world with a certain number of sectors
        public List<Sector> Sectors { get; set; }

        public World(List<Sector> sectors)
        {
            Sectors = sectors;
        }
    }
}
