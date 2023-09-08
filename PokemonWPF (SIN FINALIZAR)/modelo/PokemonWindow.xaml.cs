using System;
using System.Collections.Generic;
using System.Text;
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
    /// Lógica de interacción para PokemonWindow.xaml
    /// </summary>
    public partial class PokemonWindow : Window
    {
        Stage stage;
        bool turn, redDefeated, blueDefeated;
        public PokemonWindow()
        {
            InitializeComponent();
            stage = new Stage();
            turn = false;
            redDefeated = false;
            blueDefeated = false;
            load(turn);
        }
        private void load(bool turn)
        {
            Team t;
            if (!turn)
                t = stage.red;
            else
                t = stage.blue;

            mainPoke.Text = t.main.getName();
            main.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + t.main.getName() + "1.png", UriKind.Absolute));
            mainHealth.Text = t.main.getHP() + "/" + t.main.getMaxHP();
            mainHealthBar.Value = t.main.getHP();
            mainHealthBar.Minimum = 0;
            mainHealthBar.Maximum = t.main.getMaxHP();
            setBarColor(mainHealthBar);
            setStatus(mainpk, main_status, t.main);
            if (t.main.isDefeated())
                mainpk.IsEnabled = false;

            p1.Text = t.party[0].getName();
            p1img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + t.party[0].getName() + "1.png", UriKind.Absolute));
            p1Health.Text = t.party[0].getHP() + "/" + t.party[0].getMaxHP();
            p1HealthBar.Value = t.party[0].getHP();
            p1HealthBar.Minimum = 0;
            p1HealthBar.Maximum = t.party[0].getMaxHP();
            setBarColor(mainHealthBar);
            setStatus(p1Menu, p1_status, t.party[0]);
            if (t.party[0].isDefeated())
                p1Menu.IsEnabled = false;

            p2.Text = t.party[1].getName();
            p2img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + t.party[1].getName() + "1.png", UriKind.Absolute));
            p2Health.Text = t.party[1].getHP() + "/" + t.party[1].getMaxHP();
            p2HealthBar.Value = t.party[1].getHP();
            p2HealthBar.Minimum = 0;
            p2HealthBar.Maximum = t.party[1].getMaxHP();
            setBarColor(mainHealthBar);
            setStatus(p2Menu, p2_status, t.party[1]);
            if (t.party[1].isDefeated())
                p2Menu.IsEnabled = false;

            p3.Text = t.party[2].getName();
            p3img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + t.party[2].getName() + "1.png", UriKind.Absolute));
            p3Health.Text = t.party[2].getHP() + "/" + t.party[2].getMaxHP();
            p3HealthBar.Value = t.party[2].getHP();
            p3HealthBar.Minimum = 0;
            p3HealthBar.Maximum = t.party[2].getMaxHP();
            setBarColor(mainHealthBar);
            setStatus(p3Menu, p3_status, t.party[2]);
            if (t.party[2].isDefeated())
                p3Menu.IsEnabled = false;

            p4.Text = t.party[3].getName();
            p4img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + t.party[3].getName() + "1.png", UriKind.Absolute));
            p4Health.Text = t.party[3].getHP() + "/" + t.party[3].getMaxHP();
            p4HealthBar.Value = t.party[3].getHP();
            p4HealthBar.Minimum = 0;
            p4HealthBar.Maximum = t.party[3].getMaxHP();
            setBarColor(mainHealthBar);
            setStatus(p4Menu, p4_status, t.party[3]);
            if (t.party[3].isDefeated())
                p4Menu.IsEnabled = false;

            p5.Text = t.party[4].getName();
            p5img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + t.party[4].getName() + "1.png", UriKind.Absolute));
            p5Health.Text = t.party[4].getHP() + "/" + t.party[4].getMaxHP();
            p5HealthBar.Value = t.party[4].getHP();
            p5HealthBar.Minimum = 0;
            p5HealthBar.Maximum = t.party[4].getMaxHP();
            setBarColor(mainHealthBar);
            setStatus(p5Menu, p5_status, t.party[4]);
            if (t.party[4].isDefeated())
                p5Menu.IsEnabled = false;
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
        public void shareInfo(Stage s, bool turn, bool red = false, bool blue = false)
        {
            stage = s;
            this.turn = turn;
            redDefeated = red;
            blueDefeated = blue;
            load(turn);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.shareInfo(stage, turn);
            Window win = mw;
            this.Close();
            win.Show();
        }
        private void setStatus(Menu m, TextBox tb, Pokemon p)
        {
            Status s = p.getStatus();

            if (p.isDefeated())
            {
                tb.Text = "FNT";
                m.Background = Brushes.Gray;
                tb.BorderBrush = Brushes.Black;
                tb.Foreground = Brushes.White;
                tb.Background = Brushes.SlateGray;
            }
            else if (s.poisoned || s.bad_poisoned)
            {
                tb.Text = "PSN";
                tb.BorderBrush = Brushes.Black;
                tb.Background = Brushes.MediumPurple;
            }
            else if (s.burn)
            {
                tb.Text = "BRN";
                tb.BorderBrush = Brushes.Black;
                tb.Background = Brushes.OrangeRed;
            }
            else if (s.frozen)
            {
                tb.Text = "FRZ";
                tb.BorderBrush = Brushes.Black;
                tb.Background = Brushes.Aqua;
            }
            else if (s.paralyzed)
            {
                tb.Text = "PSN";
                tb.BorderBrush = Brushes.Black;
                tb.Background = Brushes.Yellow;
            }
            else if (s.sleep)
            {
                tb.Text = "PSN";
                tb.BorderBrush = Brushes.Black;
                tb.Background = Brushes.Gray;
            }
        }
        public void swap(int number)
        {
            if (!turn)
            {
                stage.red.swapPoke(true, number);
                if (redDefeated)
                {
                    ActionWindow aw = new ActionWindow();
                    aw.shareInfo(stage, null, null, redDefeated, blueDefeated);
                    Window win = aw;
                    this.Close();
                    win.Show();
                }
                else
                {
                    MainWindow mw = new MainWindow();
                    mw.shareInfo(stage, !turn);
                    Window win = mw;
                    this.Close();
                    win.Show();
                }
            }
            else
            {
                stage.blue.swapPoke(true, number);

                ActionWindow aw = new ActionWindow();
                aw.shareInfo(stage, stage.red.main.getSelectedMove(), stage.blue.main.getSelectedMove(), redDefeated, blueDefeated);
                Window win = aw;
                this.Close();
                win.Show();
            }
        }
        private void p1swap_Click(object sender, RoutedEventArgs e)
        {
            swap(0);
        }
        private void p2swap_Click(object sender, RoutedEventArgs e)
        {
            swap(1);
        }
        private void p3swap_Click(object sender, RoutedEventArgs e)
        {
            swap(2);
        }
        private void p4swap_Click(object sender, RoutedEventArgs e)
        {
            swap(3);
        }
        private void p5swap_Click(object sender, RoutedEventArgs e)
        {
            swap(4);
        }
        private void showDetails(Pokemon show)
        {
            DetailsWindow dw = new DetailsWindow();
            dw.shareInfo(stage, show, turn);
            Window win = dw;
            this.Close();
            win.Show();
        }
        private void maindetails_Click(object sender, RoutedEventArgs e)
        {
            Pokemon show;
            if (!turn)
                show = stage.red.main;
            else
                show = stage.blue.main;

            showDetails(show);
        }
        private void p1details_Click(object sender, RoutedEventArgs e)
        {
            Pokemon show;
            if (!turn)
                show = stage.red.party[0];
            else
                show = stage.blue.party[0];

            showDetails(show);
        }
        private void p2details_Click(object sender, RoutedEventArgs e)
        {
            Pokemon show;
            if (!turn)
                show = stage.red.party[1];
            else
                show = stage.blue.party[1];

            showDetails(show);
        }
        private void p3details_Click(object sender, RoutedEventArgs e)
        {
            Pokemon show;
            if (!turn)
                show = stage.red.party[2];
            else
                show = stage.blue.party[2];

            showDetails(show);
        }
        private void p4details_Click(object sender, RoutedEventArgs e)
        {
            Pokemon show;
            if (!turn)
                show = stage.red.party[3];
            else
                show = stage.blue.party[3];

            showDetails(show);
        }
        private void p5details_Click(object sender, RoutedEventArgs e)
        {
            Pokemon show;
            if (!turn)
                show = stage.red.party[4];
            else
                show = stage.blue.party[4];

            showDetails(show);
        }
    }
}