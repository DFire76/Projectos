using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PokemonWPF
{
    public class Team
    {
        public Pokemon main;
        public Pokemon[] party;
        string trainer;
        bool stealth_rock, swap;
        int barrier, light_screen, spikes, toxic_spikes, number, id_num;
        public Team(string trainerName)
        {
            List<Pokemon> pokedex = loadPokemon();
            Random r = new Random();
            int[] random = new int[6];
            bool control = false;
            id_num = r.Next(0, 65536);
            trainer = trainerName;

            for(int i = 0; i < 6; i++)
            {
                int aux = r.Next(0, pokedex.Count);

                foreach (int n in random)
                    if (n == aux)
                        control = true;

                if (!control)
                {
                    random[i] = aux;
                }
                else
                    i--;
                control = false;
            }

            main = pokedex[random[0]];
            party = new Pokemon[5];
            
            for (int i = 0;  i < 5; i++)
                party[i] = pokedex[random[i + 1]];

            stealth_rock = false;
            swap = false;
            barrier = 0;
            light_screen = 0;
            spikes = 0;
            toxic_spikes = 2;
            number = 0;
        }
        public void swapPoke(bool swap, int number)
        {
            this.swap = swap;
            this.number = number;
        }
        public bool getSwap()
        {
            return swap;
        }
        public void swapped()
        {
            swap = false;
        }
        public int getPos()
        {
            return number;
        }
        public string getOT()
        {
            return trainer;
        }
        public int getID()
        {
            return id_num;
        }
        public static List<Pokemon> loadPokemon()
        {
            List<Pokemon> pokeList = new List<Pokemon>();
            StreamReader file;
            string line;
            string[] edit;

            file = File.OpenText("..\\..\\..\\files\\pokedex.txt");
            do
            {
                line = file.ReadLine();

                if (line != null)
                {
                    edit = line.Split('|');
                    pokeList.Add(new Pokemon(edit[0], edit[1], edit[2], int.Parse(edit[3]), int.Parse(edit[4]), int.Parse(edit[5]), int.Parse(edit[6]), int.Parse(edit[7]), int.Parse(edit[8]), edit[9], edit[10], edit[11], edit[12]));
                }
            } while (line != null);

            file.Close();

            return pokeList;
        }
        public bool getStealthRock()
        {
            return stealth_rock;
        }
        public int getSpikes()
        {
            return spikes;
        }
        public int getToxicSpikes()
        {
            return toxic_spikes;
        }
        public void removeHazzards()
        {
            stealth_rock = false;
            spikes = 0;
            toxic_spikes = 0;
        }
        public void removeBarriers()
        {
            barrier = 0;
            light_screen = 0;
        }
    }
}