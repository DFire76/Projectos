using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonWPF
{
    public class Debuff
    {
        public int atk { get; set; }
        public int def { get; set; }
        public int sAtk { get; set; }
        public int sDef { get; set; }
        public int spd { get; set; }
        public int acc { get; set; }
        public int ev { get; set; }
        public Debuff()
        {
            atk = 0;
            def = 0;
            sAtk = 0;
            sDef = 0;
            spd = 0;
            acc = 0;
            ev = 1;
        }
        private float getStatsMultiplier(int mult)
        {
            switch (mult)
            {
                case -6:
                    return 0.25f;
                case -5:
                    return 0.285f;
                case -4:
                    return 0.333f;
                case -3:
                    return 0.4f;
                case -2:
                    return 0.5f;
                case -1:
                    return 0.666f;
                case 1:
                    return 1.5f;
                case 2:
                    return 2f;
                case 3:
                    return 2.5f;
                case 4:
                    return 3f;
                case 5:
                    return 3.5f;
                case 6:
                    return 4f;
                default:
                    return 1f;
            }
        }
        private float getPreccision(int mult)
        {
            switch (mult)
            {
                case -6:
                    return 0.33f;
                case -5:
                    return 0.38f;
                case -4:
                    return 0.43f;
                case -3:
                    return 0.5f;
                case -2:
                    return 0.6f;
                case -1:
                    return 0.75f;
                case 1:
                    return 1.33f;
                case 2:
                    return 1.67f;
                case 3:
                    return 2f;
                case 4:
                    return 2.33f;
                case 5:
                    return 2.67f;
                case 6:
                    return 3f;
                default:
                    return 1f;
            }
        }
        public float getDebuff(string s)
        {
            switch(s)
            {
                case "atk":
                    return getStatsMultiplier(atk);
                case "def":
                    return getStatsMultiplier(def);
                case "satk":
                    return getStatsMultiplier(sAtk);
                case "sdef":
                    return getStatsMultiplier(sDef);
                case "spd":
                    return getStatsMultiplier(spd);
                case "acc":
                    return getPreccision(-acc);
                case "ev":
                    return getPreccision(ev);
                default:
                    return 0;
            }
        }
    }
}