using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PokemonWPF
{
    /// <summary>
    /// Lógica de interacción para ActionWindow.xaml
    /// </summary>
    public partial class ActionWindow : Window
    {
        Stage stage;
        Moves m1, m2;
        bool redDefeated, blueDefeated;
        public ActionWindow()
        {
            PokemonWindow pw = new PokemonWindow();
            InitializeComponent();
            stage = new Stage();
            m1 = null;
            m2 = null;
            redDefeated = false;
            blueDefeated = false;
        }
        private async void load()
        {
            ArrayList textList = new ArrayList();
            string text = "";

            if (!redDefeated && !blueDefeated)
            {
                showPokemon();
                if (stage.red.getSwap())
                {
                    text = stage.red.getOT() + " retrieved " + stage.red.main.getName();
                    stage.checkRedSwap(stage);
                    text += " and took out " + stage.red.main.getName() + ".";
                    showDialog(text);
                    showPokemon();
                    await System.Threading.Tasks.Task.Delay(2000);

                    text = stage.getHazzardness(stage.red, stage.red.main);
                    if (text != "")
                    {
                        showDialog(text);
                        showPokemon();
                        await System.Threading.Tasks.Task.Delay(2000);
                    }

                    if (stage.red.main.isDefeated())
                    {
                        showDialog(stage.red.main.getName() + " fainted.");
                        T1_img.Visibility = Visibility.Hidden;
                        await System.Threading.Tasks.Task.Delay(2000);
                    }
                }

                if (stage.blue.getSwap())
                {
                    text = stage.blue.getOT() + " retrieved " + stage.blue.main.getName();
                    stage.checkBlueSwap(stage);
                    text += " and took out " + stage.blue.main.getName() + ".";
                    showDialog(text);
                    showPokemon();
                    await System.Threading.Tasks.Task.Delay(2000);

                    text = stage.getHazzardness(stage.blue, stage.blue.main);
                    if (text != "")
                    {
                        showDialog(text);
                        showPokemon();
                        await System.Threading.Tasks.Task.Delay(2000);
                    }

                    if (stage.blue.main.isDefeated())
                    {
                        showDialog(stage.blue.main.getName() + " fainted.");
                        T2_img.Visibility = Visibility.Hidden;
                        await System.Threading.Tasks.Task.Delay(2000);
                    }
                }

                Pokemon p1 = stage.red.main, p2 = stage.blue.main;

                if ((p1.getSpd() * p1.getDebuffs().getDebuff("spd")) > (p2.getSpd() * p2.getDebuffs().getDebuff("spd")))
                {
                    if (!p1.isDefeated() && !stage.red.getSwap())
                    {
                        showDialog(p1.getName() + " used " + m1.getName() + ".");
                        await System.Threading.Tasks.Task.Delay(2000);

                        textList = m1.attack(stage, stage.red, stage.blue);
                        foreach (string s in textList)
                                MessageBox.Show(s);
                        await System.Threading.Tasks.Task.Delay(2000);

                        if (stage.red.main.isDefeated())
                        {
                            showDialog(stage.red.main.getName() + " fainted.");
                            T1_img.Visibility = Visibility.Hidden;
                            await System.Threading.Tasks.Task.Delay(2000);
                        }
                    }

                    if (!p2.isDefeated() && !stage.blue.getSwap())
                    {
                        showDialog(p2.getName() + " enemy used " + m2.getName() + ".");
                        await System.Threading.Tasks.Task.Delay(2000);

                        textList = m2.attack(stage, stage.red, stage.blue);
                        foreach (string s in textList)
                                MessageBox.Show(s);
                        await System.Threading.Tasks.Task.Delay(2000);

                        if (stage.blue.main.isDefeated())
                        {
                            showDialog(stage.blue.main.getName() + " fainted.");
                            T2_img.Visibility = Visibility.Hidden;
                            await System.Threading.Tasks.Task.Delay(2000);
                        }
                    }

                    applyRedStatus();
                }
                else if ((p1.getSpd() * p1.getDebuffs().getDebuff("spd")) < (p2.getSpd() * p2.getDebuffs().getDebuff("spd")))
                {
                    if (!p2.isDefeated() && !stage.blue.getSwap())
                    {
                        showDialog(p2.getName() + " enemy used " + m2.getName() + ".");
                        await System.Threading.Tasks.Task.Delay(2000);

                        textList = m2.attack(stage, stage.red, stage.blue);
                        foreach (string s in textList)
                                MessageBox.Show(s);
                        await System.Threading.Tasks.Task.Delay(2000);

                        if (stage.blue.main.isDefeated())
                        {
                            showDialog(stage.blue.main.getName() + " fainted.");
                            T2_img.Visibility = Visibility.Hidden;
                            await System.Threading.Tasks.Task.Delay(2000);
                        }
                    }

                    if (!p1.isDefeated() && !stage.red.getSwap())
                    {
                        showDialog(p1.getName() + " used " + m1.getName() + ".");
                        await System.Threading.Tasks.Task.Delay(2000);
                        textList = m1.attack(stage, stage.red, stage.blue);
                        foreach (string s in textList)
                                MessageBox.Show(s);
                        await System.Threading.Tasks.Task.Delay(2000);

                        if (stage.red.main.isDefeated())
                        {
                            showDialog(stage.red.main.getName() + " fainted.");
                            T1_img.Visibility = Visibility.Hidden;
                            await System.Threading.Tasks.Task.Delay(2000);
                        }
                    }

                    applyRedStatus();
                }
                else if ((p1.getSpd() * p1.getDebuffs().getDebuff("spd")) == (p2.getSpd() * p2.getDebuffs().getDebuff("spd")))
                {
                    Random r = new Random();

                    if (r.Next(0, 2) == 0)
                    {
                        if (!p1.isDefeated() && !stage.red.getSwap())
                        {
                            showDialog(p1.getName() + " used " + m1.getName() + ".");
                            await System.Threading.Tasks.Task.Delay(2000);

                            textList = m1.attack(stage, stage.red, stage.blue);
                            foreach (string s in textList)
                                    MessageBox.Show(s);
                            await System.Threading.Tasks.Task.Delay(2000);

                            if (stage.red.main.isDefeated())
                            {
                                showDialog(stage.red.main.getName() + " fainted.");
                                T1_img.Visibility = Visibility.Hidden;
                                await System.Threading.Tasks.Task.Delay(2000);
                            }
                        }

                        if (!p2.isDefeated() && !stage.blue.getSwap())
                        {
                            showDialog(p2.getName() + " enemy used " + m2.getName() + ".");
                            await System.Threading.Tasks.Task.Delay(2000);

                            textList = m2.attack(stage, stage.red, stage.blue);
                            foreach (string s in textList)
                                    MessageBox.Show(s);
                            await System.Threading.Tasks.Task.Delay(2000);

                            if (stage.blue.main.isDefeated())
                            {
                                showDialog(stage.blue.main.getName() + " fainted.");
                                T2_img.Visibility = Visibility.Hidden;
                                await System.Threading.Tasks.Task.Delay(2000);
                            }
                        }

                        applyRedStatus();
                    }
                    else
                    {
                        if (!p2.isDefeated() && !stage.blue.getSwap())
                        {
                            showDialog(p2.getName() + " enemy used " + m2.getName() + ".");
                            await System.Threading.Tasks.Task.Delay(2000);

                            textList = m2.attack(stage, stage.red, stage.blue);
                            foreach (string s in textList)
                                    MessageBox.Show(s);
                            await System.Threading.Tasks.Task.Delay(2000);

                            if (stage.blue.main.isDefeated())
                            {
                                showDialog(stage.blue.main.getName() + " fainted.");
                                T2_img.Visibility = Visibility.Hidden;
                                await System.Threading.Tasks.Task.Delay(2000);
                            }
                        }

                        if (!p1.isDefeated() && !stage.red.getSwap())
                        {
                            showDialog(p1.getName() + " used " + m1.getName() + ".");
                            await System.Threading.Tasks.Task.Delay(2000);

                            textList = m1.attack(stage, stage.red, stage.blue);
                            foreach (string s in textList)
                                    MessageBox.Show(s);
                            await System.Threading.Tasks.Task.Delay(2000);

                            if (stage.red.main.isDefeated())
                            {
                                showDialog(stage.red.main.getName() + " fainted.");
                                T1_img.Visibility = Visibility.Hidden;
                                await System.Threading.Tasks.Task.Delay(2000);
                            }
                        }

                        applyRedStatus();
                    }
                }
            } else if(redDefeated)
            {
                text = stage.red.getOT() + " retrieved " + stage.red.main.getName();
                stage.checkRedSwap(stage);
                text += " and took out " + stage.red.main.getName() + ".";
                redDefeated = false;
                showDialog(text);
                showPokemon();
                await System.Threading.Tasks.Task.Delay(2000);

                text = stage.getHazzardness(stage.red, stage.red.main);
                if (text != "")
                {
                    showDialog(text);
                    showPokemon();
                    await System.Threading.Tasks.Task.Delay(2000);
                }

                defeatedPokemon();
            } else if(blueDefeated)
            {
                text = stage.blue.getOT() + " retrieved " + stage.blue.main.getName();
                stage.checkBlueSwap(stage);
                text += " and took out " + stage.blue.main.getName() + ".";
                showDialog(text);
                showPokemon();
                await System.Threading.Tasks.Task.Delay(2000);

                text = stage.getHazzardness(stage.blue, stage.blue.main);
                if (text != "")
                {
                    showDialog(text);
                    showPokemon();
                    await System.Threading.Tasks.Task.Delay(2000);
                }

                finish();
            }
        }
        private void finish()
        {
            if (!stage.red.main.isDefeated() && !stage.blue.main.isDefeated())
            {
                stage.red.swapped();
                stage.blue.swapped();

                MainWindow mw = new MainWindow();
                mw.shareInfo(stage, false);
                this.Close();
                mw.Show();
            }
        }
        private async void applyRedStatus()
        {   
            if(!stage.red.main.isDefeated() && !stage.red.getSwap())
                if (stage.red.main.getStatus().burn) {
                    stage.red.main.applyBurn();
                    decreaseBar(T1_healthbar, stage.red.main, false);
                    showDialog(stage.red.main.getName() + " took damage due to its burn.");
                    await System.Threading.Tasks.Task.Delay(2000);

                    if (stage.red.main.isDefeated())
                    {
                        showDialog(stage.red.main.getName() + " fainted.");
                        T1_img.Visibility = Visibility.Hidden;
                        await System.Threading.Tasks.Task.Delay(2000);
                    }
                } else if (stage.red.main.getStatus().poisoned)
                {
                    stage.red.main.applyPoison();
                    decreaseBar(T1_healthbar, stage.red.main, false);
                    showDialog(stage.red.main.getName() + " was hurt by poison.");
                    await System.Threading.Tasks.Task.Delay(2000);

                    if (stage.red.main.isDefeated())
                    {
                        showDialog(stage.red.main.getName() + " fainted.");
                        T1_img.Visibility = Visibility.Hidden;
                        await System.Threading.Tasks.Task.Delay(2000);
                    }
                } else if (stage.red.main.getStatus().bad_poisoned)
                {
                    stage.red.main.applyBadPoison();
                    decreaseBar(T1_healthbar, stage.red.main, false);
                    showDialog(stage.red.main.getName() + " was hurt by poison.");
                    await System.Threading.Tasks.Task.Delay(2000);

                    if (stage.red.main.isDefeated())
                    {
                        showDialog(stage.red.main.getName() + " fainted.");
                        T1_img.Visibility = Visibility.Hidden;
                        await System.Threading.Tasks.Task.Delay(2000);
                    }
                }

            applyBlueStatus();
        }
        private async void applyBlueStatus()
        {
            if (!stage.blue.main.isDefeated() && !stage.blue.getSwap())
                if (stage.blue.main.getStatus().burn)
                {
                    stage.blue.main.applyBurn();
                    decreaseBar(T2_healthbar, stage.blue.main, true);
                    showDialog(stage.blue.main.getName() + " took damage due to its burn.");
                    await System.Threading.Tasks.Task.Delay(2000);

                    if (stage.blue.main.isDefeated())
                    {
                        showDialog(stage.blue.main.getName() + " fainted.");
                        T2_img.Visibility = Visibility.Hidden;
                        await System.Threading.Tasks.Task.Delay(2000);
                    }
                }
                else if (stage.blue.main.getStatus().poisoned)
                {
                    stage.blue.main.applyPoison();
                    decreaseBar(T2_healthbar, stage.blue.main, true);
                    showDialog(stage.blue.main.getName() + " was hurt by poison.");
                    await System.Threading.Tasks.Task.Delay(2000);

                    if (stage.blue.main.isDefeated())
                    {
                        showDialog(stage.blue.main.getName() + " fainted.");
                        T2_img.Visibility = Visibility.Hidden;
                        await System.Threading.Tasks.Task.Delay(2000);
                    }
                }
                else if (stage.blue.main.getStatus().bad_poisoned)
                {
                    stage.blue.main.applyBadPoison();
                    decreaseBar(T2_healthbar, stage.blue.main, true);
                    showDialog(stage.blue.main.getName() + " was hurt by poison.");
                    await System.Threading.Tasks.Task.Delay(2000);

                    if (stage.blue.main.isDefeated())
                    {
                        showDialog(stage.blue.main.getName() + " fainted.");
                        T2_img.Visibility = Visibility.Hidden;
                        await System.Threading.Tasks.Task.Delay(2000);
                    }
                }

            defeatedPokemon();
        }
        private void defeatedPokemon()
        {
            if (stage.red.main.isDefeated())
            {
                PokemonWindow pw = new PokemonWindow();
                pw.shareInfo(stage, false, true, false);
                this.Close();
                pw.Show();
            } else
            if (stage.blue.main.isDefeated())
            {
                PokemonWindow pw = new PokemonWindow();
                pw.shareInfo(stage, true, false, true);
                this.Close();
                pw.Show();
            }

            finish();
        }
        private async void showDialog(string text)
        {
            dialog.Text = "";
            foreach (char c in text)
            {
                dialog.Text += c;
                await System.Threading.Tasks.Task.Delay(25);
            }
        }
        private void showPokemon()
        {
            T1_pokemon.Text = stage.red.main.getName();
            T1_img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + stage.red.main.getName() + "2.png", UriKind.Absolute));
            T1_health.Text = stage.red.main.getHP() + "/" + stage.red.main.getMaxHP();
            T1_healthbar.Minimum = 0;
            T1_healthbar.Value = stage.red.main.getHP();
            T1_healthbar.Maximum = stage.red.main.getMaxHP();
            setBarColor(T1_healthbar);

            T2_pokemon.Text = stage.blue.main.getName();
            T2_img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + stage.blue.main.getName() + "1.png", UriKind.Absolute));
            T2_health.Text = stage.blue.main.getHP() + "/" + stage.blue.main.getMaxHP();
            T2_healthbar.Value = stage.blue.main.getHP();
            T2_healthbar.Minimum = 0;
            T2_healthbar.Maximum = stage.blue.main.getMaxHP();
            setBarColor(T2_healthbar);

            setStatus();
        }
        private async void decreaseBar(ProgressBar pb, Pokemon p, bool team)
        {
            do
            {
                if (!team)
                    T1_health.Text = (int.Parse(T1_health.Text.Split("/")[0]) - 1) + "/" + p.getMaxHP();
                else
                    T2_health.Text = (int.Parse(T2_health.Text.Split("/")[0]) - 1) + "/" + p.getMaxHP();
                pb.Value--;
                setBarColor(pb);
                await System.Threading.Tasks.Task.Delay(25);
            } while (pb.Value > p.getHP());
        }
        private void setStatus()
        {
            Status s = stage.red.main.getStatus();

            if (s.poisoned || s.bad_poisoned)
            {
                T1_status.Text = "PSN";
                T1_status.BorderBrush = Brushes.Black;
                T1_status.Background = Brushes.MediumPurple;
            }
            else if (s.burn)
            {
                T1_status.Text = "BRN";
                T1_status.BorderBrush = Brushes.Black;
                T1_status.Background = Brushes.OrangeRed;
            }
            else if (s.frozen)
            {
                T1_status.Text = "FRZ";
                T1_status.BorderBrush = Brushes.Black;
                T1_status.Background = Brushes.Aqua;
            }
            else if (s.paralyzed)
            {
                T1_status.Text = "PSN";
                T1_status.BorderBrush = Brushes.Black;
                T1_status.Background = Brushes.Yellow;
            }
            else if (s.sleep)
            {
                T1_status.Text = "SLP";
                T1_status.BorderBrush = Brushes.Black;
                T1_status.Background = Brushes.Gray;
            }

            s = stage.blue.main.getStatus();

            if (s.poisoned || s.bad_poisoned)
            {
                T2_status.Text = "PSN";
                T2_status.BorderBrush = Brushes.Black;
                T2_status.Background = Brushes.MediumPurple;
            }
            else if (s.burn)
            {
                T2_status.Text = "BRN";
                T2_status.BorderBrush = Brushes.Black;
                T2_status.Background = Brushes.OrangeRed;
            }
            else if (s.frozen)
            {
                T2_status.Text = "FRZ";
                T2_status.BorderBrush = Brushes.Black;
                T2_status.Background = Brushes.Aqua;
            }
            else if (s.paralyzed)
            {
                T2_status.Text = "PSN";
                T2_status.BorderBrush = Brushes.Black;
                T2_status.Background = Brushes.Yellow;
            }
            else if (s.sleep)
            {
                T2_status.Text = "SLP";
                T2_status.BorderBrush = Brushes.Black;
                T2_status.Background = Brushes.Gray;
            }
        }
        static void setBarColor(ProgressBar pb)
        {
            if ((pb.Value / pb.Maximum) >= 0.5d)
                pb.Foreground = Brushes.YellowGreen;
            else if ((pb.Value / pb.Maximum) >= 0.25d)
                pb.Foreground = Brushes.Yellow;
            else
                pb.Foreground = Brushes.Brown;
        }
        public void shareInfo(Stage s, Moves m1, Moves m2, bool red = false, bool blue = false)
        {
            stage = s;
            this.m1  = m1;
            this.m2 = m2;
            redDefeated = red;
            blueDefeated = blue;
            load();
        }
    }
}