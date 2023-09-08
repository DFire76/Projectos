using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PokemonWPF
{
    class MoveList
    {
        private List<Moves> moveList;
        public MoveList()
        {
            moveList = new List<Moves>();

            StreamReader file;
            string line;
            string[] edit;

            file = File.OpenText("..\\..\\..\\files\\movimientos.txt");
            do
            {
                line = file.ReadLine();

                if (line != null) 
                {
                    edit = line.Split('|');
                    bool aux = false;
                    if (edit[6] == "1")
                        aux = true;
                    moveList.Add(new Moves(edit[0], edit[1], edit[2], aux, edit[7], edit[3], edit[4], int.Parse(edit[5]), edit[8]));
                }
            } while (line != null);
            
            file.Close();
        }
        public Moves getMove(string name)
        {
            foreach (Moves m in moveList)
                if (m.getName() == name)
                    return m;

            return null;
        }
    }
    public class Pokemon
    {
        string name, ability, item;
        bool defeated;
        Type type1;
        Type type2;
        int hp;
        int maxHP, atk, def, sAtk, sDef, spd;
        Moves[] moves;
        Moves selectedMove, lastMove;
        Debuff debuffs;
        Status status;
        public Pokemon(string name, string type1, string type2, int hp, int atk, int def, int sAtk, int sDef, int spd, string m1 = null, string m2 = null, string m3 = null, string m4 = null, string ability = "", string item = "")
        {
            this.name = name;
            defeated = false;
            this.type1 = new Type(type1);
            this.type2 = new Type(type2);
            this.ability = ability;
            this.item = item;

            this.hp = this.maxHP = hp;
            this.atk = atk;
            this.def = def;
            this.sAtk = sAtk;
            this.sDef = sDef;
            this.spd = spd;
            selectedMove = null;
            lastMove = null;
            debuffs = new Debuff();
            status = new Status();

            MoveList moveList = new MoveList();
            moves = new Moves[4];
            if(m1 != null)
                moves[0] = moveList.getMove(m1.Replace('_',' '));
            if (m2 != null)
                moves[1] = moveList.getMove(m2.Replace('_', ' '));
            if (m3 != null)
                moves[2] = moveList.getMove(m3.Replace('_', ' '));
            if (m4 != null)
                moves[3] = moveList.getMove(m4.Replace('_', ' '));
        }
        public Pokemon(Pokemon p, int currentHP)
        {
            new Pokemon(p.name, p.type1.ToString(), p.type2.ToString(), p.hp, p.atk, p.def, p.sAtk, p.sDef, p.spd);
            hp = currentHP;
            lastMove = p.lastMove;
            selectedMove = p.selectedMove;

            moves[0] = p.moves[0];
            moves[1] = p.moves[1];
            moves[2] = p.moves[2];
            moves[3] = p.moves[3];
        }
        public string getName()
        {
            return name;
        }
        public int getHP()
        {
            return hp;
        }
        public int getMaxHP()
        {
            return maxHP;
        }
        public int getAtk()
        {
            return atk;
        }
        public int getDef()
        {
            return def;
        }
        public int getSAtk()
        {
            return sAtk;
        }
        public int getSDef()
        {
            return sDef;
        }
        public int getSpd()
        {
            return spd;
        }
        public Type getType1()
        {
            return type1;
        }
        public Type getType2()
        {
            return type2;
        }
        public Moves[] getMoves()
        {
            return moves;
        }
        public void reduceHealth(int num)
        {
            hp -= num;

            if (hp <= 0)
            {
                hp = 0;
                defeated = true;
            }
        }
        public void restoreHealth(int num)
        {
            hp += num;

            if (hp >= maxHP)
                hp = maxHP;
        }
        public bool isBurned()
        {
            return status.burn;
        }
        public void applyBurn()
        {
            hp -= maxHP / 16;

            if (hp <= 0)
            {
                hp = 0;
                defeated = true;
            }
        }
        public void applyPoison()
        {
            hp -= maxHP / 8;

            if (hp <= 0)
            {
                hp = 0;
                defeated = true;
            }
        }
        public void applyBadPoison()
        {
            hp -= (maxHP * (1 + status.getBadPoisonTurns())) / 16;
            status.increaseBadPoisonTurns();

            if(hp <= 0)
            {
                hp = 0;
                defeated = true;
            }
        }
        public bool isDefeated()
        {
            return defeated;
        }
        public bool isGrounded()
        {
            if (type1.getType() == "FLYING" || type2.getType() == "FLYING" || ability == "LEVITATE")
                return false;

            return true;
        }
        public bool isPoisonable()
        {
            if (status.checkStatus() || type1.getType() == "STEEL" || type2.getType() == "STEEL" || type1.getType() == "POISON" || type2.getType() == "POISON")
                return false;

            return true;
        }
        public void setPoison()
        {
            status.poisoned = true;
        }
        public void setParalyzed()
        {
            status.paralyzed = true;
        }
        public void setBadPoison()
        {
            status.bad_poisoned = true;
        }
        public void setCurse()
        {
            status.cursed = true;
        }
        public void setFlinch()
        {
            status.flinched = true;
        }
        public Status getStatus()
        {
            return status;
        }
        public void selectMove(Moves moves)
        {
            if(moves != null)
                selectedMove = new Moves(moves);
        }
        public Moves getSelectedMove()
        {
            return selectedMove;
        }
        public Debuff getDebuffs()
        {
            return debuffs;
        }
        public void setAttackDB(int b)
        {
            int f = debuffs.atk + b;

            if (f < -6)
                f = -6;
            if (f > 6)
                f = 6;

            debuffs.atk = f;
        }
        public void setDefenseDB(int b)
        {
            int f = debuffs.def + b;

            if (f < -6)
                f = -6;
            if (f > 6)
                f = 6;

            debuffs.def = f;
        }
        public void setSAttackDB(int b)
        {
            int f = debuffs.sAtk + b;

            if (f < -6)
                f = -6;
            if (f > 6)
                f = 6;

            debuffs.sAtk = f;
        }
        public void setSDefenseDB(int b)
        {
            int f = debuffs.sDef + b;

            if (f < -6)
                f = -6;
            if (f > 6)
                f = 6;

            debuffs.sDef = f;
        }
        public void setSpeedDB(int b)
        {
            int f = debuffs.spd + b;

            if (f < -6)
                f = -6;
            if (f > 6)
                f = 6;

            debuffs.spd = f;
        }
        public void setAccuracyDB(int b)
        {
            int f = debuffs.acc + b;

            if (f < -6)
                f = -6;
            if (f > 6)
                f = 6;

            debuffs.acc = f;
        }
        public void setEvasionDB(int b)
        {
            int f = debuffs.ev + b;

            if (f < -6)
                f = -6;
            if (f > 6)
                f = 6;

            debuffs.ev = f;
        }
    }
}