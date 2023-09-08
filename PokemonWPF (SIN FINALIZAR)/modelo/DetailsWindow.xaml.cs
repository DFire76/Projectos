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
    /// Lógica de interacción para DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        Stage stage;
        Pokemon show;
        bool turn;
        public DetailsWindow()
        {
            InitializeComponent();
            stage = new Stage();
            show = null;
            turn = false;
        }
        public void load()
        {
            name.Text = show.getName();
            pkimg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../files/img/" + show.getName() + "1.png", UriKind.Absolute));
            if (!turn) {
                numID.Text = stage.red.getID().ToString();
                ot.Text = stage.red.getOT();
            } else
            {
                numID.Text = stage.blue.getID().ToString();
                ot.Text = stage.blue.getOT();
            }
            type1.Text = show.getType1().getType();
            setTextColor(type1, show.getType1());

            if (show.getType2().getType() == "NONE")
            {
                type2.Visibility = Visibility.Hidden;
                type1.SetValue(Grid.ColumnSpanProperty, 2);
                type1.SetValue(Grid.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            }
            else
            {
                type2.Text = show.getType2().getType();
                setTextColor(type2, show.getType2());
            }

            hp.Text = show.getHP() + "/" + show.getMaxHP();
            atk.Text = show.getAtk().ToString();
            def.Text = show.getDef().ToString();
            spatk.Text = show.getSAtk().ToString();
            spdef.Text = show.getSDef().ToString();
            spd.Text = show.getSpd().ToString();

            A1_name.Text = show.getMoves()[0].getName();
            A1_pp.Text = show.getMoves()[0].getPPs() + "/" + show.getMoves()[0].getMaxPPs();
            setButtonColor(A1, show.getMoves()[0].getType());

            if (show.getMoves()[1] != null)
            {
                A2_name.Text = show.getMoves()[1].getName();
                A2_pp.Text = show.getMoves()[1].getPPs() + "/" + show.getMoves()[1].getMaxPPs();
                setButtonColor(A2, show.getMoves()[1].getType());
            } else
            {
                A2.IsEnabled = false;
                A2_name.Text = "";
                A2_pp.Text = "";
            }

            if (show.getMoves()[2] != null)
            {
                A3_name.Text = show.getMoves()[2].getName();
                A3_pp.Text = show.getMoves()[2].getPPs() + "/" + show.getMoves()[2].getMaxPPs();
                setButtonColor(A3, show.getMoves()[2].getType());
            } else
            {
                A3.IsEnabled = false;
                A3_name.Text = "";
                A3_pp.Text = "";
            }

            if (show.getMoves()[3] != null)
            {
                A4_name.Text = show.getMoves()[3].getName();
                A4_pp.Text = show.getMoves()[3].getPPs() + "/" + show.getMoves()[3].getMaxPPs();
                setButtonColor(A4, show.getMoves()[3].getType());
            } else
            {
                A4.IsEnabled = false;
                A4_name.Text = "";
                A4_pp.Text = "";
            }

            desc.Text = show.getMoves()[0].getDescription();
            type.Text = show.getMoves()[0].getType().getType();
            power.Text = show.getMoves()[0].getPower().ToString();
            if (power.Text == "0")
                power.Text = "-";
            accuracy.Text = show.getMoves()[0].getAccuracy().ToString();
            if (accuracy.Text == "0")
                accuracy.Text = "-";
            setTextColor(type, show.getMoves()[0].getType());
        }
        public void shareInfo(Stage s, Pokemon p, bool turn)
        {
            stage = s;
            show = p;
            this.turn = turn;
            load();
        }
        private static void setButtonColor(Button b, Type t)
        {
            b.FontWeight = FontWeight.FromOpenTypeWeight(999);
            b.Foreground = Brushes.Black;
            switch (t.getType())
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
        public static void setTextColor(TextBox b, Type t)
        {
            b.FontWeight = FontWeight.FromOpenTypeWeight(999);
            b.Foreground = Brushes.Black;
            switch (t.getType())
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
        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            PokemonWindow pw = new PokemonWindow();
            pw.shareInfo(stage, turn);
            Window win = pw;
            this.Close();
            win.Show();
        }
        private void A1_MouseEnter(object sender, MouseEventArgs e)
        {
            desc.Text = show.getMoves()[0].getDescription();
            type.Text = show.getMoves()[0].getType().getType();

            power.Text = show.getMoves()[0].getPower().ToString();
            if (power.Text == "0")
                power.Text = "-";

            accuracy.Text = show.getMoves()[0].getAccuracy().ToString();
            if (accuracy.Text == "0")
                accuracy.Text = "-";

            setTextColor(type, show.getMoves()[0].getType());
        }
        private void A2_MouseEnter(object sender, MouseEventArgs e)
        {
            desc.Text = show.getMoves()[1].getDescription();
            type.Text = show.getMoves()[1].getType().getType();

            power.Text = show.getMoves()[1].getPower().ToString();
            if (power.Text == "0")
                power.Text = "-";

            accuracy.Text = show.getMoves()[1].getAccuracy().ToString();
            if (accuracy.Text == "0")
                accuracy.Text = "-";

            setTextColor(type, show.getMoves()[1].getType());
        }
        private void A3_MouseEnter(object sender, MouseEventArgs e)
        {
            desc.Text = show.getMoves()[2].getDescription();
            type.Text = show.getMoves()[2].getType().getType();
            power.Text = show.getMoves()[2].getPower().ToString();
            if (power.Text == "0")
                power.Text = "-";
            accuracy.Text = show.getMoves()[2].getAccuracy().ToString();
            if (accuracy.Text == "0")
                accuracy.Text = "-";
            setTextColor(type, show.getMoves()[2].getType());
        }
        private void A4_MouseEnter(object sender, MouseEventArgs e)
        {
            desc.Text = show.getMoves()[3].getDescription();
            type.Text = show.getMoves()[3].getType().getType();
            power.Text = show.getMoves()[3].getPower().ToString();
            if (power.Text == "0")
                power.Text = "-";
            accuracy.Text = show.getMoves()[3].getAccuracy().ToString();
            if (accuracy.Text == "0")
                accuracy.Text = "-";
            setTextColor(type, show.getMoves()[3].getType());
        }
    }
}
