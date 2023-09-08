using System;

namespace Blackjack
{
    class Blackjack
    {
        int value, money, bet, Bvalue;
        char input;

        public Blackjack()
        {
            Random r = new Random();
            value = getCard() + getCard();
            Bvalue = getCard();
            money = 100;
            bet = 0;
            input = 'n';
        }

        int getCard()
        {
            Random r = new Random();
            int x = r.Next(1, 13);
            if (x == 1)
                x = 11;
            else if (x > 10)
                x = 10;

            return x;
        }

        void betting()
        {
            Console.WriteLine("¿Cuánto dinero quieres apostar (1 - {0})?", money);
            bet = int.Parse(Console.ReadLine());

            while (bet > money)
            {
                Console.WriteLine("No tienes esa cantidad: ¿Cuánto dinero quieres apostar (1 - {0})?", money);
                bet = int.Parse(Console.ReadLine());
            }

            money -= bet;
        }

        void drawCards()
        {
            Console.WriteLine("Tienes {0}.", value);
            Console.WriteLine("¿Quieres otra carta? (y/n)");
            input = char.Parse(Console.ReadLine());

            while (input != 'y' && input != 'n')
            {
                Console.WriteLine("Opción incorrecta. Introduzca  \"y\" para otra carta o \"n\" para parar.");
                input = char.Parse(Console.ReadLine());
            }

            while (input == 'y')
            {
                value += getCard();

                Console.WriteLine("Tienes {0}.", value);

                if (value < 21)
                {
                    Console.WriteLine("¿Quieres otra carta (y/n)?");
                    input = char.Parse(Console.ReadLine());

                    while (input != 'y' && input != 'n')
                    {
                        Console.WriteLine("Opción incorrecta. Introduzca  \"y\" para otra carta o \"n\" para parar.");
                        input = char.Parse(Console.ReadLine());
                    }
                }
                else
                    input = 'n';
            }
        }

        void sol()
        {
            if (value <= 21 && (Bvalue > 21 || Bvalue < value))
            {
                Console.WriteLine("¡Has ganado!");
                money += bet * 2;
            }
            else if (Bvalue == value)
            {
                Console.WriteLine("¡Has empatado!");
                money += bet;
            }
            else
                Console.WriteLine("!Has perdido!");
        }

        public void play()
        {
            do
            {
                betting();
                // Jugador

                Console.WriteLine("La banca tiene {0}.", Bvalue);
                drawCards();

                // Banca

                while (Bvalue <= 16)
                    Bvalue += getCard();
                if (value <= 21)
                    Console.WriteLine("La banca tiene {0}.", Bvalue);
                sol();

                value = getCard() + getCard();
                Bvalue = getCard();

                if (money > 0)
                {
                    Console.WriteLine("¿Quieres seguir jugando (y/n)?");
                    input = char.Parse(Console.ReadLine());

                    while (input != 'y' && input != 'n')
                    {
                        Console.WriteLine("Opción incorrecta. Introduzca  \"y\" para seguir jugando o \"n\" para parar\n");
                        input = char.Parse(Console.ReadLine());
                    }
                }
            } while (input == 'y' && money > 0);

            if (money == 0)
                Console.WriteLine("Te has quedado en blanca.");
            else
                Console.WriteLine("Has ganado {0}$", money);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Blackjack game = new Blackjack();
            game.play();
            /*
            Console.WriteLine("Vamos a jugar al BlackJack!");

            Random r = new Random();
            int value, money, bet;
            char input = 'n';

            value = r.Next(1, 13) + r.Next(1, 13);
            money = 100;

            do
            {
                // Apuesta
                Console.WriteLine("¿Cuánto dinero quieres apostar (1 - {0})?", money);
                bet = int.Parse(Console.ReadLine());

                while (bet > money)
                {
                    Console.WriteLine("No tienes esa cantidad: ¿Cuánto dinero quieres apostar (1 - {0})?", money);
                    bet = int.Parse(Console.ReadLine());
                }

                money -= bet;
                // Jugador

                Console.WriteLine("Tienes {0}.", value);
                Console.WriteLine("¿Quieres otra carta? (y/n)");
                input = char.Parse(Console.ReadLine());

                while (input != 'y' && input != 'n')
                {
                    Console.WriteLine("Opción incorrecta. Introduzca  \"y\" para otra carta o \"n\" para parar.");
                    input = char.Parse(Console.ReadLine());
                }

                while (input == 'y')
                {
                    value += r.Next(1, 13);

                    Console.WriteLine("Tienes {0}.", value);
                    Console.WriteLine("¿Quieres otra carta (y/n)?");
                    input = char.Parse(Console.ReadLine());

                    while (input != 'y' && input != 'n')
                    {
                        Console.WriteLine("Opción incorrecta. Introduzca  \"y\" para otra carta o \"n\" para parar.");
                        input = char.Parse(Console.ReadLine());
                    }
                }

                if (value > 21)
                    Console.WriteLine("¡Has perdido!");
                else
                { // Banca

                    int Bvalue = r.Next(1, 13);

                    while (Bvalue <= 16)
                        Bvalue += r.Next(1, 13);

                    Console.WriteLine("La banca tiene {0}.", Bvalue);

                    if (Bvalue > 21 || Bvalue < value)
                    {
                        Console.WriteLine("¡Has ganado!");
                        money += bet * 2;
                    }
                    else if(Bvalue == value)
                    {
                        Console.WriteLine("¡Has empatado!");
                        money += bet;
                    }
                    else
                        Console.WriteLine("!Has perdido!");
                }

                Console.WriteLine("¿Quieres seguir jugando (y/n)?");
                input = char.Parse(Console.ReadLine());

                while (input != 'y' && input != 'n')
                {
                    Console.WriteLine("Opción incorrecta. Introduzca  \"y\" para seguir jugando o \"n\" para parar\n");
                    input = char.Parse(Console.ReadLine());
                }
            } while (input == 'y' && money > 0);

            if (money == 0)
                Console.WriteLine("Te has quedado en blanca.");*/
        }
    }
}
