using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stage stage;
        bool turn;
        public MainWindow()
        {
            InitializeComponent();
            stage = new Stage();
            turn = false;
            load(turn);
        }
        private void load(bool turn)
        {
            if (!turn)
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
                T2_healthbar.Minimum = 0;
                T2_healthbar.Value = stage.blue.main.getHP();
                T2_healthbar.Maximum = stage.blue.main.getMaxHP();
                setBarColor(T2_healthbar);
            } else
            {
                T1_pokemon.Text = stage.blue.main.getName();
                T1_img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + stage.blue.main.getName() + "2.png", UriKind.Absolute));
                T1_health.Text = stage.blue.main.getHP() + "/" + stage.blue.main.getMaxHP();
                T1_healthbar.Minimum = 0;
                T1_healthbar.Value = stage.blue.main.getHP();
                T1_healthbar.Maximum = stage.blue.main.getMaxHP();
                setBarColor(T1_healthbar);

                T2_pokemon.Text = stage.red.main.getName();
                T2_img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + stage.red.main.getName() + "1.png", UriKind.Absolute));
                T2_health.Text = stage.red.main.getHP() + "/" + stage.red.main.getMaxHP();
                T2_healthbar.Minimum = 0;
                T2_healthbar.Value = stage.red.main.getHP();
                T2_healthbar.Maximum = stage.red.main.getMaxHP();
                setBarColor(T2_healthbar);
            }
            setStatus();
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
        private void setStatus()
        {
            Status s;
            if(!turn)
                s = stage.red.main.getStatus();
            else
                s = stage.blue.main.getStatus();

            if (s.poisoned || s.bad_poisoned)
            {
                T1_status.Text = "PSN";
                T1_status.BorderBrush = Brushes.Black;
                T1_status.Background = Brushes.MediumPurple;
            } else if(s.burn)
            {
                T1_status.Text = "BRN";
                T1_status.BorderBrush = Brushes.Black;
                T1_status.Background = Brushes.OrangeRed;
            } else if(s.frozen)
            {
                T1_status.Text = "FRZ";
                T1_status.BorderBrush = Brushes.Black;
                T1_status.Background = Brushes.Aqua;
            } else if(s.paralyzed)
            {
                T1_status.Text = "PLZ";
                T1_status.BorderBrush = Brushes.Black;
                T1_status.Background = Brushes.Yellow;
            } else if(s.sleep)
            {
                T1_status.Text = "SLP";
                T1_status.BorderBrush = Brushes.Black;
                T1_status.Background = Brushes.Gray;
            }

            if (turn)
                s = stage.red.main.getStatus();
            else
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
                T2_status.Text = "PLZ";
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
        public void shareInfo(Stage s, bool turn)
        {
            stage = s;
            this.turn = turn;
            load(this.turn);
        }
        private void A1_Click(object sender, RoutedEventArgs e)
        {
            BattleWindow bw = new BattleWindow();
            bw.shareInfo(stage, turn);
            Window win = bw;
            this.Close();
            win.Show();
        }

        private void A2_Click(object sender, RoutedEventArgs e)
        {
            PokemonWindow pw = new PokemonWindow();
            pw.shareInfo(stage, turn);
            Window win = pw;
            this.Close();
            win.Show();
        }

        private void A3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("YOU CAN'T USE ITEMS");
        }

        private void A4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}