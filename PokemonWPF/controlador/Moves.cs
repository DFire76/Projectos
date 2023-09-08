using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PokemonWPF
{
    public class Moves
    {
        string name;
        Type type;
        string category, desc, priority;
        bool makesContact;
        int power, accuracy;
        int pp;
        int maxPP;
        public Moves(string name, string type, string category, bool makesContact, string priority, string power, string accuracy, int pp, string desc)
        {
            this.name = name.Split(' ')[0].Replace('_', ' ');
            this.type = new Type(type);
            this.category = category;
            this.makesContact = makesContact;
            this.priority = priority;

            if (power != "-")
                this.power = int.Parse(power);
            else
                this.power = 0;
            if (accuracy != "-")
                this.accuracy = int.Parse(accuracy);
            else
                this.accuracy = 0;
            this.maxPP = this.pp = pp;

            this.desc = desc;
        }
        public Moves(Moves m)
        {
            this.name = m.name;
            this.type = new Type(m.getType().getType());
            this.category = m.category;
            this.desc = m.desc;
            this.priority = m.priority;
            this.makesContact = m.makesContact;
            this.power = m.power;
            this.accuracy = m.accuracy;
            this.pp = m.pp;
            this.maxPP = m.maxPP;
        }
        public string getName()
        {
            return name;
        }
        public int getPPs()
        {
            return pp;
        }
        public int getMaxPPs()
        {
            return maxPP;
        }
        public Type getType()
        {
            return type;
        }
        public int getPower()
        {
            return power;
        }
        public int getAccuracy()
        {
            return accuracy;
        }
        public string getDescription()
        {
            return desc;
        }
        
        public ArrayList attack(Stage s, Team t1, Team t2)
        {
            int prec = precissionCalculator(s, t1.main, t2.main);
            int rng = new Random().Next(1, 101);

            if (prec <= 100 && rng > prec)
            {
                ArrayList ret = new ArrayList();
                ret.Add(t2.main.getName() + " avoided the attack!");
                return ret;
            }

            switch (name)
            {
                case "AGILITY":
                    return agility(s, t1.main, t2.main);
                case "AQUA TAIL":
                    return aqua_tail(s, t1.main, t2.main);
                case "BELLY DRUM":
                    return belly_drum(s, t1.main, t2.main);
                case "BODY SLAM":
                    return body_slam(s, t1.main, t2.main);
                case "BRAVE BIRD":
                    return brave_bird(s, t1.main, t2.main);
                case "BUG BUZZ":
                    return bug_buzz(s, t1.main, t2.main);
                case "BULK UP":
                    return bulk_up(s, t1.main, t2.main);
                case "BULLET PUNCH":
                    return bullet_punch(s, t1.main, t2.main);
                case "CLOSE COMBAT":
                    return close_combat(s, t1.main, t2.main);
                case "COIL":
                    return coil(s, t1.main, t2.main);
                case "CRUNCH":
                    return crunch(s, t1.main, t2.main);
                case "CURSE":
                    return curse(s, t1.main, t2.main);
                case "DARK_PULSE":
                    return dark_pulse(s, t1.main, t2.main);
                case "DEFOG":
                    return defog(s, t1, t2);
                case "DISCHARGE":
                    return discharge(s, t1.main, t2.main);
                case "DOUBLE-EDGE":
                    return double_edge(s, t1.main, t2.main);
                case "DRAGON DANCE":
                    return dragon_dance(s, t1.main, t2.main);
                case "DRAIN PUNCH":
                    return drain_punch(s, t1.main, t2.main);
                case "DRILL PECK":
                    return drill_peck(s, t1.main, t2.main);
                case "DRILL RUN":
                    return drill_run(s, t1.main, t2.main);
                case "DUAL WINGBEAT":
                    return dual_wingbeat(s, t1.main, t2.main);
                case "EARTH POWER":
                    return earth_power(s, t1.main, t2.main);
                case "EARTHQUAKE":
                    return earthquake(s, t1.main, t2.main);
                case "ENERGY BALL":
                    return energy_ball(s, t1.main, t2.main);
                case "EXPLOSION":
                    return explosion(s, t1.main, t2.main);
                case "FACADE":
                    return facade(s, t1.main, t2.main);
                case "FAKE OUT":
                    return fake_out(s, t1.main, t2.main);
                case "FIRE BLAST":
                    return fire_blast(s, t1.main, t2.main);
                case "FIRE PUNCH":
                    return fire_punch(s, t1.main, t2.main);
                case "FIRST IMPRESSION":
                    return first_impression(s, t1.main, t2.main);
                case "FLAMETHROWER":
                    return flamethrower(s, t1.main, t2.main);
                case "FLARE BLITZ":
                    return flare_blitz(s, t1.main, t2.main);
                case "FLASH CANNON":
                    return flash_cannon(s, t1.main, t2.main);
                case "FLIP TURN":
                    return flip_turn(s, t1.main, t2.main);
                case "FOCUS BLAST":
                    return focus_blast(s, t1.main, t2.main);
                case "FREEZE-DRY":
                    return freeze_dry(s, t1.main, t2.main);
                case "FRUSTRATION":
                    return frustration(s, t1.main, t2.main);
                case "FUTURE SIGHT":
                    return future_sight(s, t1.main, t2.main);
                case "GIGA DRAIN":
                    return giga_drain(s, t1.main, t2.main);
                case "GROWTH":
                    return growth(s, t1.main, t2.main);
                case "GUNK SHOT":
                    return gunk_shot(s, t1.main, t2.main);
                case "HEAL BELL":
                    return heal_bell(s, t1.main, t2.main);
                case "HEAT WAVE":
                    return heat_wave(s, t1.main, t2.main);
                case "HIDDEN POWER FIRE":
                    return hidden_power(s, t1.main, t2.main);
                case "HIGH HORSEPOWER":
                    return high_horsepower(s, t1.main, t2.main);
                case "HORN DRILL":
                    return horn_drill(s, t1.main, t2.main);
                case "HURRICANE":
                    return hurricane(s, t1.main, t2.main);
                case "HYDRO PUMP":
                    return hydro_pump(s, t1.main, t2.main);
                case "HYPNOSIS":
                    return hypnosis(s, t1.main, t2.main);
                case "ICE BEAM":
                    return ice_beam(s, t1.main, t2.main);
                case "ICE FANG":
                    return ice_fang(s, t1.main, t2.main);
                case "ICE PUNCH":
                    return ice_punch(s, t1.main, t2.main);
                case "ICICLE SPEAR":
                    return icicle_spear(s, t1.main, t2.main);
                case "IRON HEAD":
                    return iron_head(s, t1.main, t2.main);
                case "JUMP KICK":
                    return jump_kick(s, t1.main, t2.main);
                case "KNOCK OFF":
                    return knock_off(s, t1.main, t2.main);
                case "LAVA PLUME":
                    return lava_plume(s, t1.main, t2.main);
                case "LEAF BLADE":
                    return leaf_blade(s, t1.main, t2.main);
                case "LEAF STORM":
                    return leaf_storm(s, t1.main, t2.main);
                case "LEECH LIFE":
                    return leech_life(s, t1.main, t2.main);
                case "LIGHT SCREEN":
                    return light_screen(s, t1.main, t2.main);
                case "LIQUIDATION":
                    return liquidation(s, t1.main, t2.main);
                case "LOVELY KISS":
                    return lovely_kiss(s, t1.main, t2.main);
                case "MACH PUNCH":
                    return mach_punch(s, t1.main, t2.main);
                case "MEGAHORN":
                    return megahorn(s, t1.main, t2.main);
                case "MEMENTO":
                    return memento(s, t1.main, t2.main);
                case "METEOR BEAM":
                    return meteor_beam(s, t1.main, t2.main);
                case "MOONBLAST":
                    return moonblast(s, t1.main, t2.main);
                case "MORNING SUN":
                    return morning_sun(s, t1.main, t2.main);
                case "MYSTICAL FIRE":
                    return mystical_fire(s, t1.main, t2.main);
                case "NASTY PLOT":
                    return nasty_plot(s, t1.main, t2.main);
                case "PAIN SPLIT":
                    return pain_split(s, t1.main, t2.main);
                case "PERISH SONG":
                    return perish_song(s, t1.main, t2.main);
                case "POISON JAB":
                    return poison_jab(s, t1.main, t2.main);
                case "POWER WHIP":
                    return power_whip(s, t1.main, t2.main);
                case "PROTECT":
                    return protect(s, t1.main, t2.main);
                case "PSYCHIC":
                    return psychic(s, t1.main, t2.main);
                case "PSYSHOCK":
                    return psyshock(s, t1.main, t2.main);
                case "PSYSTRIKE":
                    return psystrike(s, t1.main, t2.main);
                case "QUICK ATTACK":
                    return quick_attack(s, t1.main, t2.main);
                case "QUIVER DANCE":
                    return quiver_dance(s, t1.main, t2.main);
                case "RAIN DANCE":
                    return rain_dance(s, t1.main, t2.main);
                case "RAPID SPIN":
                    return rapid_spin(s, t1.main, t2.main);
                case "RECOVER":
                    return recover(s, t1.main, t2.main);
                case "REFLECT":
                    return reflect(s, t1.main, t2.main);
                case "REST":
                    return rest(s, t1.main, t2.main);
                case "RETURN":
                    return return_m(s, t1.main, t2.main);
                case "ROCK BLAST":
                    return rock_blast(s, t1.main, t2.main);
                case "ROCK SLIDE":
                    return rock_slide(s, t1.main, t2.main);
                case "ROOST":
                    return roost(s, t1.main, t2.main);
                case "SCALD":
                    return scald(s, t1.main, t2.main);
                case "SCORCHING SANDS":
                    return scorching_sands(s, t1.main, t2.main);
                case "SEISMIC TOSS":
                    return seismic_toss(s, t1.main, t2.main);
                case "SHADOW BALL":
                    return shadow_ball(s, t1.main, t2.main);
                case "SHEER COLD":
                    return sheer_cold(s, t1.main, t2.main);
                case "SHELL SMASH":
                    return shell_smash(s, t1.main, t2.main);
                case "SLACK OFF":
                    return slack_off(s, t1.main, t2.main);
                case "SLEEP POWDER":
                    return sleep_powder(s, t1.main, t2.main);
                case "SLEEP TALK":
                    return sleep_talk(s, t1.main, t2.main);
                case "SLUDGE BOMB":
                    return sludge_bomb(s, t1.main, t2.main);
                case "SLUDGE WAVE":
                    return sludge_wave(s, t1.main, t2.main);
                case "SOFT BOILED":
                    return soft_boiled(s, t1.main, t2.main);
                case "SPIKES":
                    return spikes(s, t1.main, t2.main);
                case "SPORE":
                    return spore(s, t1.main, t2.main);
                case "STEALTH ROCK":
                    return stealth_rock(s, t1.main, t2.main);
                case "STOMPING TANTRUM":
                    return stomping_tantrum(s, t1.main, t2.main);
                case "STONE EDGE":
                    return stone_edge(s, t1.main, t2.main);
                case "STRENGTH SAP":
                    return strength_sap(s, t1.main, t2.main);
                case "SUBSTITUTE":
                    return substitute(s, t1.main, t2.main);
                case "SUCKER PUNCH":
                    return sucker_punch(s, t1.main, t2.main);
                case "SUPER FANG":
                    return super_fang(s, t1.main, t2.main);
                case "SUPERPOWER":
                    return superpower(s, t1.main, t2.main);
                case "SURF":
                    return surf(s, t1.main, t2.main);
                case "SWORD DANCE":
                    return sword_dance(s, t1.main, t2.main);
                case "SYNTHESIS":
                    return synthesis(s, t1.main, t2.main);
                case "TAUNT":
                    return taunt(s, t1.main, t2.main);
                case "TELEPORT":
                    return teleport(s, t1.main, t2.main);
                case "THROAT CHOP":
                    return throat_chop(s, t1.main, t2.main);
                case "THUNDER PUNCH":
                    return thunder_punch(s, t1.main, t2.main);
                case "THUNDER WAVE":
                    return thunder_wave(s, t1.main, t2.main);
                case "THUNDERBOLT":
                    return thunderbolt(s, t1.main, t2.main);
                case "TOXIC":
                    return toxic(s, t1.main, t2.main);
                case "TOXIC SPIKES":
                    return toxic_spikes(s, t1.main, t2.main);
                case "TRANSFORM":
                    return transform(s, t1.main, t2.main);
                case "TRI ATTACK":
                    return tri_attack(s, t1.main, t2.main);
                case "U-TURN":
                    return u_turn(s, t1.main, t2.main);
                case "VOLT SWITCH":
                    return volt_switch(s, t1.main, t2.main);
                case "WATERFALL":
                    return waterfall(s, t1.main, t2.main);
                case "WEATHER BALL":
                    return weather_ball(s, t1.main, t2.main);
                case "WHIRLPOOL":
                    return whirlpool(s, t1.main, t2.main);
                case "WILL-O-WISP":
                    return will_o_wisp(s, t1.main, t2.main);
                case "wish":
                    return wish(s, t1.main, t2.main);
                case "X-SCISSOR":
                    return x_scissor(s, t1.main, t2.main);
                case "ZEN HEADBUTT":
                    return zen_headbutt(s, t1.main, t2.main);
                default:
                    ArrayList ret = new ArrayList();
                    ret.Add("ERROR: Move:"+ this.name);
                    return ret;
            }
        }
        private int damageCalculator(Stage s, Pokemon p1, Pokemon p2, bool crit = false)
        {
            float B = 1f, E, V, N = 50, A, P = power, D;

            if ((p1.getType1().getType() == type.getType()) || (p1.getType2().getType() == type.getType()))
                B = 1.5f;

            E = type.getMultiplier(p2.getType1()) * type.getMultiplier(p2.getType2());
            V = new Random().Next(85, 101) / 100;

            if (p1.isBurned())
                A = p1.getAtk() * 0.5f;
            else
                A = p1.getAtk();

            if (category == "PHYSICAL")
                A *= p1.getDebuffs().atk;
            else
                A = p1.getSAtk() * p1.getDebuffs().sAtk;

            if(crit)
                P *= 1.5f;


            if (category == "PHYSICAL")
                D = p2.getDef() * p2.getDebuffs().def;
            else
                D = p2.getSDef() * p2.getDebuffs().sDef;

            return (int)(0.01f * B * E * V * (((0.2f * N + 1) * A * P) / (25 * D) + 2));
        }
        public int precissionCalculator(Stage s, Pokemon p1, Pokemon p2)
        {
            float PMbase = accuracy, Patacante = p1.getDebuffs().getDebuff("acc"), Erival = p2.getDebuffs().getDebuff("ev");

            return (int) (PMbase * Patacante / Erival);
        }
        private ArrayList agility(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();

            p1.setSpeedDB(2);
            ret.Add(p1.getName() +"\'s SPEED sharply rose!");
            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList aqua_tail(Stage s, Pokemon p1, Pokemon p2)
        {
            /*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            p2.reduceHealth(damage);

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList belly_drum(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();

            if(p1.getHP() < (p1.getMaxHP() / 2))
            {
                ret.Add(p1.getName() + "\'s health is too low!");
                return ret;
            }

            p1.setAttackDB(18);
            p1.reduceHealth(p1.getMaxHP() / 2);
            ret.Add(p1.getName() + " cut its own HP and maximized it ATTACK!");

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList body_slam(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            if (new Random().Next(1, 101) <= 30f)
            {
                p2.setParalyzed();
                ret.Add(p2.getName() + " is now paralyzed!");
            }

            p2.reduceHealth(damage);

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList brave_bird(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            p1.reduceHealth((int)(damage * 0.33f));
            p2.reduceHealth(damage);
            ret.Add(p1.getName() + " is damaged by the recoil!");

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList bug_buzz(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }
            if (new Random().Next(1, 101) <= 10f)
            {
                p2.setSDefenseDB(-1);
                ret.Add(p2.getName() + "\'s SPECIAL DEFENSE fell!");
            }
            p2.reduceHealth(damage);

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList bulk_up(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();

            p1.setAttackDB(1);
            p1.setDefenseDB(1);
            ret.Add(p1.getName() + "\'s ATTACK rose!");
            ret.Add(p1.getName() + "\'s DEFENSE rose!");

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList bullet_punch(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            p2.reduceHealth(damage);

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList close_combat(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            p1.setDefenseDB(-1);
            p1.setSDefenseDB(-1);
            ret.Add(p1.getName() + "\'s DEFENSE fell!");
            ret.Add(p1.getName() + "\'s SPECIAL DEFENSE fell!");
            p2.reduceHealth(damage);
            
            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList coil(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();

            p1.setAttackDB(1);
            p1.setDefenseDB(1);
            p1.setAccuracyDB(1);
            ret.Add(p1.getName() + "\'s ATTACK rose!");
            ret.Add(p1.getName() + "\'s DEFENSE rose!");
            ret.Add(p1.getName() + "\'s ACCURACY rose!");

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList crunch(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }
            if (new Random().Next(1, 101) <= 20f)
            {
                p2.setDefenseDB(-1);
                ret.Add(p2.getName() + "\'s DEFENSE fell!");
            }

            p2.reduceHealth(damage);

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList curse(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();

            if(p1.getType1().getType() != "GHOST" || p1.getType2().getType() != "GHOST")
            {
                p1.setSpeedDB(-1);
                p1.setAttackDB(1);
                p1.setDefenseDB(1);
                ret.Add(p1.getName() + "\'s SPEED fell!");
                ret.Add(p1.getName() + "\'s ATTACK rose!");
                ret.Add(p1.getName() + "\'s DEFENSE rose!");
            } else
            {
                p1.reduceHealth(p1.getMaxHP() / 2);
                p2.setCurse();
                ret.Add(p1.getName() + " cut its onw HP and laid a CURSE on " + p2.getName() + "!");
            }

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList dark_pulse(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            if (new Random().Next(1, 101) <= 20f)
                p2.setFlinch();

            p2.reduceHealth(damage);

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList defog(Stage s, Team t1, Team t2)
        {/*
            ArrayList ret = new ArrayList();

            t2.main.setEvasionDB(-1);
            ret.Add(t2.main.getName() + "\'s EVASSIVENESS fell!");

            t1.removeHazzards();
            t2.removeHazzards();
            ret.Add("All hazzards were removed!");

            t1.removeBarriers();
            ret.Add("All barriers were removed from " + t1.getOT() + "'s team!");

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList discharge(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            if (new Random().Next(1, 101) <= 30f)
            {
                p2.setParalyzed();
                ret.Add(p2.getName() + " is now paralyzed!");
            }

            p2.reduceHealth(damage);

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList double_edge(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            p1.reduceHealth((int)(damage * 0.33f));
            p2.reduceHealth(damage);
            ret.Add(p1.getName() + " is damaged by the recoil!");

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList dragon_dance(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();

            p1.setAttackDB(1);
            p1.setSpeedDB(1);
            ret.Add(p1.getName() + "\'s ATTACK rose!");
            ret.Add(p1.getName() + "\'s SPEED rose!");

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList drain_punch(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            p1.restoreHealth((int)(damage * 0.5f));
            p2.reduceHealth(damage);
            ret.Add(p1.getName() + " had its energy drained!");

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList drill_peck(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            p2.reduceHealth(damage);

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList drill_run(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 12.5f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            p2.reduceHealth(damage);

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList dual_wingbeat(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            p2.reduceHealth(damage);

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            p2.reduceHealth(damage);
            ret.Add("The Pokémon was hit 2 times!");

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList earth_power(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            if (new Random().Next(1, 101) <= 10f)
            {
                p2.setDefenseDB(-1);
                ret.Add(p2.getName() + "\'s DEFENSE fell!");
            }

            p2.reduceHealth(damage);

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList earthquake(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            p2.reduceHealth(damage);

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList energy_ball(Stage s, Pokemon p1, Pokemon p2)
        {/*
            ArrayList ret = new ArrayList();
            int damage = 0;

            if (new Random().Next(1, 101) > 6.25f)
                damage = damageCalculator(s, p1, p2);
            else
            {
                damage = damageCalculator(s, p1, p2, true);
                ret.Add("A critical hit!");
            }

            if (new Random().Next(1, 101) <= 10f)
            {
                p2.setSDefenseDB(-1);
                ret.Add(p2.getName() + "\'s SPECIAL DEFENSE fell!");
            }

            p2.reduceHealth(damage);

            return ret;*/
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList explosion(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList facade(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList fake_out(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList fire_blast(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList fire_punch(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList first_impression(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList flamethrower(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList flare_blitz(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList flash_cannon(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList flip_turn(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList focus_blast(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList freeze_dry(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList frustration(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList future_sight(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList giga_drain(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList growth(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList gunk_shot(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList heal_bell(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList heat_wave(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList hidden_power(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList high_horsepower(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList horn_drill(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList hurricane(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList hydro_pump(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList hypnosis(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList ice_beam(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList ice_fang(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList ice_punch(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList icicle_spear(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList iron_head(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList jump_kick(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList knock_off(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList lava_plume(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList leaf_blade(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList leaf_storm(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList leech_life(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList light_screen(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList liquidation(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList lovely_kiss(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList mach_punch(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList megahorn(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList memento(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList meteor_beam(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList moonblast(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList morning_sun(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList mystical_fire(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList nasty_plot(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList pain_split(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList perish_song(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList poison_jab(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList power_whip(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList protect(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList psychic(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList psyshock(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList psystrike(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList quick_attack(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList quiver_dance(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList rain_dance(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList rapid_spin(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList recover(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList reflect(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList rest(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList return_m(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList rock_blast(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList rock_slide(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList roost(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList scald(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList scorching_sands(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList seismic_toss(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList shadow_ball(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList sheer_cold(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList shell_smash(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList slack_off(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList sleep_powder(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList sleep_talk(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList sludge_bomb(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList sludge_wave(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList soft_boiled(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList spikes(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList spore(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList stealth_rock(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList stomping_tantrum(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList stone_edge(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList strength_sap(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList substitute(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList sucker_punch(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList super_fang(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList superpower(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList surf(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList sword_dance(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList synthesis(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList taunt(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList teleport(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList throat_chop(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList thunder_punch(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList thunder_wave(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList thunderbolt(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList toxic(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList toxic_spikes(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList transform(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList tri_attack(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList u_turn(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList volt_switch(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList waterfall(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList weather_ball(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList whirlpool(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList will_o_wisp(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList wish(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList x_scissor(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
        private ArrayList zen_headbutt(Stage s, Pokemon p1, Pokemon p2)
        {
            ArrayList ret = new ArrayList();
            ret.Add("Used: " + this.name);
            return ret;
        }
    }
}