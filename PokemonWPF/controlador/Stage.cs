using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonWPF
{
    public class Stage
    {
        public Team red;
        public Team blue;
        int sun, rain, sandstorm, hail;
        public Stage()
        {
            Random r = new Random();
            string[] trainerList = { "RED", "BLUE", "JESSIE", "JAMES", "GIOVANNI", "MISTY", "BROCK", "LANCE", "SILVER", "WALLY", "STEVEN", "ARCHIE", "MAXIE", "CYNTHIA", "CYRUS", "CHEREN", "BIANCA", "ALDER", "IRIS", "GETCHIS" };
            int t1 = r.Next(0, trainerList.Length);
            red = new Team(trainerList[t1]);

            int t2 = 0;
            do
            {
                t2 = r.Next(0, trainerList.Length);
            } while (t2 == t1);
            blue = new Team(trainerList[t2]);

            sun = 0;
            rain = 0;
            sandstorm = 0;
            hail = 0;
        }
        public void checkRedSwap(Stage s)
        {
            if (red.getSwap())
            {
                Pokemon swap = red.party[red.getPos()];
                red.party[red.getPos()] = red.main;
                red.main = swap;

                red.main.getStatus().resetBadPoison();
            }
        }
        public void checkBlueSwap(Stage s)
        {
            if (blue.getSwap())
            {
                Pokemon swap = blue.party[blue.getPos()];
                blue.party[blue.getPos()] = blue.main;
                blue.main = swap;
            }
        }
        public string getHazzardness(Team t, Pokemon p)
        {
            if (t.getStealthRock())
            {
                Type rock = new Type("ROCK");
                float multiplier = rock.getMultiplier(p.getType1()) * rock.getMultiplier(p.getType2());

                switch (multiplier)
                {
                    case 4f:
                        p.reduceHealth(int.Parse(p.getMaxHP() * 1/2 + ""));
                        break;
                    case 2f:
                        p.reduceHealth(int.Parse(p.getMaxHP() * 1/4 + ""));
                        break;
                    case 1f:
                        p.reduceHealth(int.Parse(p.getMaxHP() * 1/8 + ""));
                        break;
                    case 0.5f:
                        p.reduceHealth(int.Parse(p.getMaxHP() * 625/10000 + ""));
                        break;
                    case 0.25f:
                        p.reduceHealth(int.Parse(p.getMaxHP() * 3125/100000 + ""));
                        break;
                }

                return "Pointed stones dug into " + p.getName();
            }

            if(t.getSpikes() > 0 && p.isGrounded())
            {
                switch(t.getSpikes())
                {
                    case 1:
                        p.reduceHealth(int.Parse(p.getMaxHP() * 1/8 + ""));
                        break;
                    case 2:
                        p.reduceHealth(int.Parse(p.getMaxHP() * 1/6 + ""));
                        break;
                    case 3:
                        p.reduceHealth(int.Parse(p.getMaxHP() * 1/4 + ""));
                        break;
                }

                return p.getName() + " was hurt by the spikes";
            }

            if(t.getToxicSpikes() > 0 && p.isPoisonable())
            {
                switch(t.getToxicSpikes())
                {
                    case 0:
                        p.setPoison();
                        return p.getName() + " was poisoned";
                    default:
                        p.setBadPoison();
                        return p.getName() + " was badly poisoned";
                }
            }

            return "";
        }
    }
}