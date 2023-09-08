using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonWPF
{
    public class Status
    {
        public int badPoisonTurns;
        public bool burn { get; set; }
        public bool paralyzed { get; set; }
        public bool frozen { get; set; }
        public bool poisoned { get; set; }
        public bool bad_poisoned { get; set; }
        public bool sleep { get; set; }
        public bool confusion { get; set; }
        public bool taunted { get; set; }
        public bool cursed { get; set; }
        public bool flinched { get; set; }
        public Status()
        {
            burn = false;
            paralyzed = false;
            frozen = false;
            poisoned = false;
            bad_poisoned = false;
            badPoisonTurns = 0;
            sleep = false;
            confusion = false;
            taunted = false;
            cursed = false;
            flinched = false;
        }
        public bool checkStatus()
        {
            if (burn == false && paralyzed == false && frozen == false && poisoned == false && bad_poisoned == false && sleep == false && confusion == false)
                return false;

            return true;
        }
        public void resetBadPoison()
        {
            badPoisonTurns = 0;
        }
        public void increaseBadPoisonTurns()
        {
            badPoisonTurns++;
        }
        public int getBadPoisonTurns()
        {
            return badPoisonTurns;
        }
    }
}