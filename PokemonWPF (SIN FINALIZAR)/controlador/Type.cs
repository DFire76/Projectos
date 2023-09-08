using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonWPF
{
    public enum TypeList
    {
        FIRE,
        WATER,
        GRASS,
        ELECTRIC,
        GROUND,
        ROCK,
        FLYING,
        STEEL,
        PSYCHIC,
        DARK,
        FIGHTING,
        ICE,
        DRAGON,
        BUG,
        POISON,
        FAIRY,
        NORMAL,
        GHOST,
        NONE,
        NULL
    }
    public class Type
    {
        private TypeList type;
        public Type(string type)
        {
            this.type = searchType(type);
        }
        public string getType()
        {
            return type.ToString();
        }
        public TypeList searchType(string type)
        {
            switch (type)
            {
                case "FIRE":
                    return TypeList.FIRE;
                case "WATER":
                    return TypeList.WATER;
                case "GRASS":
                    return TypeList.GRASS;
                case "ELECTRIC":
                    return TypeList.ELECTRIC;
                case "GROUND":
                    return TypeList.GROUND;
                case "ROCK":
                    return TypeList.ROCK;
                case "FLYING":
                    return TypeList.FLYING;
                case "STEEL":
                    return TypeList.STEEL;
                case "PSYCHIC":
                    return TypeList.PSYCHIC;
                case "DARK":
                    return TypeList.DARK;
                case "FIGHTING":
                    return TypeList.FIGHTING;
                case "ICE":
                    return TypeList.ICE;
                case "DRAGON":
                    return TypeList.DRAGON;
                case "BUG":
                    return TypeList.BUG;
                case "POISON":
                    return TypeList.POISON;
                case "FAIRY":
                    return TypeList.FAIRY;
                case "NORMAL":
                    return TypeList.NORMAL;
                case "GHOST":
                    return TypeList.GHOST;
                case "NONE":
                    return TypeList.NONE;
                default:
                    Console.WriteLine("ERROR: " + type);
                    return  TypeList.NULL;
            }
        }
        public float getMultiplier(Type tObjective)
        {
            switch(tObjective.type)
            {
                case TypeList.BUG:
                    switch(type)
                    {
                        case TypeList.FIGHTING:
                        case TypeList.GROUND:
                        case TypeList.GRASS:
                            return 0.5f;
                        case TypeList.FLYING:
                        case TypeList.ROCK:
                        case TypeList.FIRE:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.DARK:
                    switch (type)
                    {
                        case TypeList.PSYCHIC:
                            return 0f;
                        case TypeList.GHOST:
                        case TypeList.DARK:
                            return 0.5f;
                        case TypeList.FIGHTING:
                        case TypeList.BUG:
                        case TypeList.FAIRY:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.DRAGON:
                    switch (type)
                    {
                        case TypeList.FIRE:
                        case TypeList.WATER:
                        case TypeList.GRASS:
                        case TypeList.ELECTRIC:
                            return 0.5f;
                        case TypeList.ICE:
                        case TypeList.DRAGON:
                        case TypeList.FAIRY:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.ELECTRIC:
                    switch (type)
                    {
                        case TypeList.FLYING:
                        case TypeList.STEEL:
                        case TypeList.ELECTRIC:
                            return 0.5f;
                        case TypeList.GROUND:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.FAIRY:
                    switch (type)
                    {
                        case TypeList.DRAGON:
                            return 0f;
                        case TypeList.FIGHTING:
                        case TypeList.BUG:
                        case TypeList.DARK:
                            return 0.5f;
                        case TypeList.POISON:
                        case TypeList.STEEL:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.FIGHTING:
                    switch (type)
                    {
                        case TypeList.ROCK:
                        case TypeList.BUG:
                        case TypeList.DARK:
                            return 0.5f;
                        case TypeList.FLYING:
                        case TypeList.PSYCHIC:
                        case TypeList.FAIRY:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.FIRE:
                    switch (type)
                    {
                        case TypeList.BUG:
                        case TypeList.STEEL:
                        case TypeList.FIRE:
                        case TypeList.GRASS:
                        case TypeList.ICE:
                        case TypeList.FAIRY:
                            return 0.5f;
                        case TypeList.GROUND:
                        case TypeList.ROCK:
                        case TypeList.WATER:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.FLYING:
                    switch (type)
                    {
                        case TypeList.GROUND:
                            return 0f;
                        case TypeList.FIGHTING:
                        case TypeList.BUG:
                        case TypeList.GRASS:
                            return 0.5f;
                        case TypeList.ROCK:
                        case TypeList.ELECTRIC:
                        case TypeList.ICE:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.GHOST:
                    switch (type)
                    {
                        case TypeList.NORMAL:
                        case TypeList.FIGHTING:
                            return 0f;
                        case TypeList.POISON:
                        case TypeList.BUG:
                            return 0.5f;
                        case TypeList.GHOST:
                        case TypeList.DARK:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.GRASS:
                    switch (type)
                    {
                        case TypeList.GROUND:
                        case TypeList.WATER:
                        case TypeList.GRASS:
                        case TypeList.ELECTRIC:
                            return 0.5f;
                        case TypeList.FLYING:
                        case TypeList.POISON:
                        case TypeList.BUG:
                        case TypeList.FIRE:
                        case TypeList.ICE:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.GROUND:
                    switch (type)
                    {
                        case TypeList.ELECTRIC:
                            return 0f;
                        case TypeList.POISON:
                        case TypeList.ROCK:
                            return 0.5f;
                        case TypeList.WATER:
                        case TypeList.GRASS:
                        case TypeList.ICE:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.ICE:
                    switch (type)
                    {
                        case TypeList.ICE:
                            return 0.5f;
                        case TypeList.FIGHTING:
                        case TypeList.ROCK:
                        case TypeList.STEEL:
                        case TypeList.FIRE:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.NORMAL:
                    switch (type)
                    {
                        case TypeList.GHOST:
                            return 0f;
                        case TypeList.FIGHTING:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.POISON:
                    switch (type)
                    {
                        case TypeList.FIGHTING:
                        case TypeList.POISON:
                        case TypeList.DARK:
                        case TypeList.GRASS:
                        case TypeList.FAIRY:
                            return 0.5f;
                        case TypeList.GROUND:
                        case TypeList.PSYCHIC:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.PSYCHIC:
                    switch (type)
                    {
                        case TypeList.FIGHTING:
                        case TypeList.PSYCHIC:
                            return 0.5f;
                        case TypeList.BUG:
                        case TypeList.GHOST:
                        case TypeList.DARK:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.ROCK:
                    switch (type)
                    {
                        case TypeList.NORMAL:
                        case TypeList.FLYING:
                        case TypeList.FIRE:
                            return 0.5f;
                        case TypeList.FIGHTING:
                        case TypeList.GROUND:
                        case TypeList.STEEL:
                        case TypeList.WATER:
                        case TypeList.GRASS:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.STEEL:
                    switch (type)
                    {
                        case TypeList.POISON:
                            return 0f;
                        case TypeList.NORMAL:
                        case TypeList.FLYING:
                        case TypeList.ROCK:
                        case TypeList.BUG:
                        case TypeList.STEEL:
                        case TypeList.GRASS:
                        case TypeList.PSYCHIC:
                        case TypeList.ICE:
                        case TypeList.DRAGON:
                        case TypeList.FAIRY:
                            return 0.5f;
                        case TypeList.FIGHTING:
                        case TypeList.GROUND:
                        case TypeList.FIRE:
                            return 2f;
                        default:
                            return 1f;
                    }
                case TypeList.WATER:
                    switch (type)
                    {
                        case TypeList.STEEL:
                        case TypeList.FIRE:
                        case TypeList.WATER:
                        case TypeList.ICE:
                            return 0.5f;
                        case TypeList.GRASS:
                        case TypeList.ELECTRIC:
                            return 2f;
                        default:
                            return 1f;
                    }
                default:
                    return 1;
            }
        }
    }
}
