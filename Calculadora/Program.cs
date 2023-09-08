using System;

namespace Ejercicios
{
    class Calc
    {
        public Calc()
        {
        }
        public int check(string input)
        {
            if (input.Contains('+') || input.Contains('-')
                       || input.Contains('/') || input.Contains('*')
                       || input.Contains('%') || input.Contains('^')
                       || input.Contains("root"))
                return calculate(input);
            else
                return int.Parse(input);
        }
        public int calculate(string input)
        {
            int x = 0, y = 0, z = 0;
            string[] aux;
            if (input.Contains('+'))
            {
                try
                {
                    aux = input.Split('+', 2);

                    y = check(aux[1]);
                    x = check(aux[0]);
                }
                catch (Exception errorEncontrado)
                {
                    Console.WriteLine("Ha habido un error: {0}",
                    errorEncontrado.Message);
                }
                z = x + y;
            }
            else if (input.Contains('-'))
            {
                try
                {
                    aux = input.Split('-', 2);

                    y = check(aux[1]);
                    x = check(aux[0]);
                }
                catch (Exception errorEncontrado)
                {
                    Console.WriteLine("Ha habido un error: {0}",
                    errorEncontrado.Message);
                }

                z = x - y;
            }
            else if (input.Contains('*'))
            {
                try
                {
                    aux = input.Split('*', 2);

                    y = check(aux[1]);
                    x = check(aux[0]);
                }
                catch (Exception errorEncontrado)
                {
                    Console.WriteLine("Ha habido un error: {0}",
                    errorEncontrado.Message);
                }

                z = x * y;
            }
            else if (input.Contains('/'))
            {
                try
                {
                    aux = input.Split('/', 2);
                    y = check(aux[1]);
                    x = check(aux[0]);
                }
                catch (Exception errorEncontrado)
                {
                    Console.WriteLine("Ha habido un error: {0}",
                    errorEncontrado.Message);
                }

                z = x / y;
            }
            else if (input.Contains('%'))
            {
                try
                {
                    aux = input.Split('%', 2);
                    y = check(aux[1]);
                    x = check(aux[0]);
                }
                catch (Exception errorEncontrado)
                {
                    Console.WriteLine("Ha habido un error: {0}",
                    errorEncontrado.Message);
                }

                z = x % y;
            }
            else if (input.Contains('^'))
            {
                try
                {
                    aux = input.Split('^', 2);

                    y = check(aux[1]);
                    x = check(aux[0]);
                }
                catch (Exception errorEncontrado)
                {
                    Console.WriteLine("Ha habido un error: {0}",
                    errorEncontrado.Message);
                }

                z = (int)Math.Pow(x, y);
            }
            else if (input.Contains("root"))
            {
                try
                {
                    aux = input.Split("root", 2);

                    y = check(aux[1]);
                    x = check(aux[0]);
                }
                catch (Exception errorEncontrado)
                {
                    Console.WriteLine("Ha habido un error: {0}",
                    errorEncontrado.Message);
                }

                z = (int)Math.Pow((double)x, (double)1 / y);
            }

            return z;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            string[] aux;
            Calc c = new Calc();

            aux = input.Split('+', 2);
            do
            {
                Console.WriteLine("Introduzca la operación (\"n/N\" para finalizar):");
                input = Console.ReadLine();

                if (input.ToUpper() != "N")
                    Console.WriteLine("{0} = {1}", input, c.calculate(input.Trim()));
            } while (input.ToUpper() != "N");
            //int num = 2;
            //for(int i = 0; i <= 10; i++)
            //    Console.WriteLine("{0} x {1} = {2}", num, i, num * i);
        }
    }
}
