using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoGame;

namespace DemoGame
{
    internal class Sector
    {
        //Sector class with name, list of monsters, list of connected sectors
        public string Name; // name of sector
        public List<Enemy> Enemies; //list of enemies
        public List<Sector> ConnectedSectors; //list of connected sectors

        public Sector(string name, List<Enemy> enemies, List<Sector> connectedSectors)
        {
            Name = name;
            Enemies = enemies;
            ConnectedSectors = connectedSectors;
        }
    }
}
