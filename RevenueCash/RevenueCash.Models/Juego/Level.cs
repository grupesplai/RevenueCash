using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueCash.Models.Juego
{
    public class Level
    {
        public Level()
        {
        }

        public int LevelNumber { get; set; }
        public Level NextLevel { get; set; }
        public string StringLevel { get; set; }
    }
}
