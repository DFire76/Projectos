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
    public partial class BattleWindow : Window
    {
        Stage stage;
        bool turn;
        public BattleWindow()
        {
            InitializeComponent();
            stage = new Stage();
            turn = false;
            load(turn);
        }
        private void load(bool turn)
        {
            Moves[] m = new Moves[4];
            if (!turn)
            {
                T1_pokemon.Text = stage.red.main.getName();
                T1_img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + stage.red.main.getName() + "2.png", UriKind.Absolute));
                T1_health.Text = stage.red.main.getHP() + "/" + stage.red.main.getMaxHP();
                T1_healthbar.Minimum = 0;
                T1_healthbar.Value = stage.red.main.getHP();
                T1_healthbar.Maximum = stage.red.main.getMaxHP();
                m = stage.red.main.getMoves();
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
                m = stage.blue.main.getMoves();
                setBarColor(T1_healthbar);

                T2_pokemon.Text = stage.red.main.getName();
                T2_img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + stage.red.main.getName() + "1.png", UriKind.Absolute)); ;
                T2_health.Text = stage.red.main.getHP() + "/" + stage.red.main.getMaxHP(); 
                T2_healthbar.Minimum = 0;
                T2_healthbar.Value = stage.red.main.getHP();
                T2_healthbar.Maximum = stage.red.main.getMaxHP();
                setBarColor(T2_healthbar);
            }
            setStatus();

            A1.Content = m[0].getName();
            setButtonColor(A1, m[0].getType());
            if (m[1] != null)
            {
                A2.Content = m[1].getName();
                setButtonColor(A2, m[1].getType());
            }
            else
            {
                A2.IsEnabled = false;
                A2.Content = "";
            }
            if (m[2] != null)
            {
                A3.Content = m[2].getName();
                setButtonColor(A3, m[2].getType());
            }
            else
            {
                A3.IsEnabled = false;
                A3.Content = "";
            }
            if (m[3] != null)
            {
                A4.Content = m[3].getName();
                setButtonColor(A4, m[3].getType());
            }
            else
            {
                A4.IsEnabled = false;
                A4.Content = "";
            }
        }
        private void setStatus()
        {
            Status s;
            if (!turn)
                s = stage.red.main.getStatus();
            else
                s = stage.blue.main.getStatus();

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
                T1_status.Text = "PSN";
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
                T2_status.Text = "PSN";
                T2_status.BorderBrush = Brushes.Black;
                T2_status.Background = Brushes.Yellow;
            }
            else if (s.sleep)
            {
                T2_status.Text = "PSN";
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
        private static void setButtonColor(Button b, Type t)
        {
            b.FontWeight = FontWeight.FromOpenTypeWeight(999);
            b.Foreground = Brushes.Black;
            b.Opacity = 0.7d;
            switch(t.getType())
            {
                case "ICE":
                    b.Background = Brushes.Aqua;
                    break;
                case "DARK":
                    b.Background = Brushes.Black;
                    b.Foreground = Brushes.White;
                    break;
                case "NORMAL":
                    b.Background = Brushes.Silver;
                    break;
                case "ROCK":
                    b.Background = Brushes.SaddleBrown;
                    break;
                case "FLYING":
                    b.Background = Brushes.LightBlue;
                    break;
                case "GROUND":
                    b.Background = Brushes.SandyBrown;
                    break;
                case "WATER":
                    b.Background = Brushes.CornflowerBlue;
                    break;
                case "STEEL":
                    b.Background = Brushes.LightSteelBlue;
                    break;
                case "FIGHTING":
                    b.Background = Brushes.Brown;
                    break;
                case "GHOST":
                    b.Background = Brushes.BlueViolet;
                    break;
                case "ELECTRIC":
                    b.Background = Brushes.Yellow;
                    b.Opacity = 0.5d;
                    break;
                case "GRASS":
                    b.Background = Brushes.ForestGreen;
                    break;
                case "POISON":
                    b.Background = Brushes.MediumPurple;
                    break;
                case "FIRE":
                    b.Background = Brushes.OrangeRed;
                    break;
                case "FAIRY":
                    b.Background = Brushes.Violet;
                    break;
                case "DRAGON":
                    b.Background = Brushes.DodgerBlue;
                    break;
                case "PSYCHIC":
                    b.Background = Brushes.DeepPink;
                    break;
                case "BUG":
                    b.Background = Brushes.DarkOliveGreen;
                    break;
            }
        }
        public void shareInfo(Stage s, bool turn)
        {
            stage = s;
            this.turn = turn;
            load(this.turn);
        }
        private void A1_MouseEnter(object sender, MouseEventArgs e)
        {
            attackType.Text = stage.red.main.getMoves()[0].getType().getType();
            attackPP.Text = stage.red.main.getMoves()[0].getPPs() + "/" + stage.red.main.getMoves()[0].getMaxPPs();
        }
        private void A2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (stage.red.main.getMoves()[1] != null)
            {
                attackType.Text = stage.red.main.getMoves()[1].getType().getType();
                attackPP.Text = stage.red.main.getMoves()[1].getPPs() + "/" + stage.red.main.getMoves()[1].getMaxPPs();
            }
        }
        private void A3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (stage.red.main.getMoves()[2] != null)
            {
                attackType.Text = stage.red.main.getMoves()[2].getType().getType();
                attackPP.Text = stage.red.main.getMoves()[2].getPPs() + "/" + stage.red.main.getMoves()[2].getMaxPPs();
            }
        }
        private void A4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (stage.red.main.getMoves()[3] != null)
            {
                attackType.Text = stage.red.main.getMoves()[3].getType().getType();
                attackPP.Text = stage.red.main.getMoves()[3].getPPs() + "/" + stage.red.main.getMoves()[3].getMaxPPs();
            }
        }
        private void A1_Click(object sender, RoutedEventArgs e)
        {
            if (turn)
            {
                stage.blue.main.selectMove(stage.blue.main.getMoves()[0]);

                ActionWindow aw = new ActionWindow();
                aw.shareInfo(stage, stage.red.main.getSelectedMove(), stage.blue.main.getSelectedMove());
                Window win = aw;
                this.Close();
                win.Show();
            }
            else
            {
                stage.red.main.selectMove(stage.red.main.getMoves()[0]);

                MainWindow mw = new MainWindow();
                mw.shareInfo(stage, !turn);
                Window win = mw;
                this.Close();
                win.Show();
            }
        }
        private void A2_Click(object sender, RoutedEventArgs e)
        {
            if (turn)
            {
                stage.blue.main.selectMove(stage.blue.main.getMoves()[1]);

                ActionWindow aw = new ActionWindow();
                aw.shareInfo(stage, stage.red.main.getSelectedMove(), stage.blue.main.getSelectedMove());
                Window win = aw;
                this.Close();
                win.Show();
            }
            else
            {
                stage.red.main.selectMove(stage.red.main.getMoves()[1]);

                MainWindow mw = new MainWindow();
                mw.shareInfo(stage, !turn);
                Window win = mw;
                this.Close();
                win.Show();
            }
        }
        private void A3_Click(object sender, RoutedEventArgs e)
        {
            if (turn)
            {
                stage.blue.main.selectMove(stage.blue.main.getMoves()[2]);

                ActionWindow aw = new ActionWindow();
                aw.shareInfo(stage, stage.red.main.getSelectedMove(), stage.blue.main.getSelectedMove());
                Window win = aw;
                this.Close();
                win.Show();
            }
            else
            {
                stage.red.main.selectMove(stage.red.main.getMoves()[2]);

                MainWindow mw = new MainWindow();
                mw.shareInfo(stage, !turn);
                Window win = mw;
                this.Close();
                win.Show();
            }
        }
        private void A4_Click(object sender, RoutedEventArgs e)
        {
            if (turn)
            {
                stage.blue.main.selectMove(stage.blue.main.getMoves()[3]);

                ActionWindow aw = new ActionWindow();
                aw.shareInfo(stage, stage.red.main.getSelectedMove(), stage.blue.main.getSelectedMove());
                Window win = aw;
                this.Close();
                win.Show();
            }
            else
            {
                stage.red.main.selectMove(stage.red.main.getMoves()[3]);

                MainWindow mw = new MainWindow();
                mw.shareInfo(stage, !turn);
                Window win = mw;
                this.Close();
                win.Show();
            }
        }
        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.shareInfo(stage, turn);
            Window win = mw;
            this.Close();
            win.Show();
        }
    }
}