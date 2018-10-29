using RevenueCash.Models.Juego;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueCash.Models
{
    public static class Configurations
    {
        static Configurations()
        {

            Levels = new List<Level>();
            Level level1 = new Level()
            {
                StringLevel = @"XXXXXXXXXX
                                XXXXXXXXXX
                                XXXXXXXXXX
                                XXXXXXXXXX
                                XXXXXXRXXX
                                XXXXXXXXXX
                                XXXXXXXXXX
                                XXXXXXXXXX
                                XXRXXXXXXX
                                XXXXXXXXXX",
                LevelNumber = 1
            };

            Level level2 = new Level()
            {
                StringLevel = @"XXXXXXXXXX
                                XXXXXXXXXX
                                XXXXXXXXXX
                                XXXXXXXXXX
                                XXXRXXXXXX
                                XXXXXXXRXX
                                XXXXXXXXXX
                                XXXXXXXXXX
                                XXXXXRXXXX
                                XXRXXXXXXX",
                LevelNumber = 2
            };
            level1.NextLevel = level2;
            Levels.Add(level2);

            Level level3 = new Level()
            {
                StringLevel = @"XXXXXXXXXX
                                XXXXXXXXXX
                                XXXRXXXXXX
                                XXXXXXXXXX
                                XXXRXXXXXX
                                XXXXXXXRXX
                                XXXRXXXXXX
                                XXXXXXXXXX
                                XXXXXRXXXX
                                XXRXXXXXXX",
                LevelNumber = 3
            };
            level2.NextLevel = level3;
            Levels.Add(level2);
        }

        public static IList<Level> Levels { get; set; }
    }
}
