using RevenueCash.Models.Juego;
using System.Collections.Generic;
namespace RevenueCash.Models
{
    public static class Configurations
    {
        static Configurations()
        {

            Levels = new List<Level>();
            Level level1 = new Level()
            {
                StringLevel = @"----------
                                ----------
                                --R----B--
                                ----------
                                ------R---
                                ----------
                                ----------
                                ----------
                                --R-------
                                ---------R",
                LevelNumber = 1
            };
            Levels.Add(level1);


            Level level2 = new Level()
            {
                StringLevel = @"----R-----
                                ----------
                                ----------
                                --B-------
                                ---R------
                                ------B-R--
                                -R--------
                                ----------
                                -----R----
                                --R-------",
                LevelNumber = 2
            };
            level1.NextLevel = level2;
            Levels.Add(level2);

            Level level3 = new Level()
            {
                StringLevel = @"----------
                                -------R--
                                ---RB-----
                                ----R-----
                                ---R------
                                -----B--R--
                                ---R------
                                ----------
                                -----R-B--
                                --R-------",
                LevelNumber = 3
            };
            level2.NextLevel = level3;
            Levels.Add(level2);

            Level level4 = new Level()
            {
                StringLevel = @"---R-----R
                                ----------
                                -RR-B-----
                                ----------
                                ------R---
                                ---B------
                                R--------R
                                -R--------
                                --RB------
                                B----R---R",
                LevelNumber = 4
            };
            level3.NextLevel = level4;
            Levels.Add(level3);
        }

        public static IList<Level> Levels { get; set; }
    }
}
