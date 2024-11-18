using System;

namespace AplikacjeWebowe.Cwiczenia5
{
    internal class Zadanie1
    {
        static float[] Solve(float a, float b, float c)
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    return new float[] { };
                }
                else
                {
                    return new float[] { -b / c };
                }
            }
            else
            {
                float delta = b * b - 4 * a * c;
                if(delta < 0)
                {
                    return new float[] { };
                }
                else if(delta == 0)
                {
                    return new float[] { -b / 2*a };
                }
                else
                {
                    return new float[] { (-b - (float)Math.Sqrt(delta)) / (2*a), (-b + (float)Math.Sqrt(delta)) / (2*a) };
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Dla równania ax2+bx+c = 0");
            float a, b, c;
            Console.WriteLine("Podaj a");
            a = float.Parse(Console.ReadLine());
            Console.WriteLine("Podaj b");
            b = float.Parse(Console.ReadLine());
            Console.WriteLine("Podaj c");
            c = float.Parse(Console.ReadLine());

            float[] solutions = Solve(a, b, c);
            if(solutions.Length == 0)
            {
                Console.WriteLine("Brak rozwiązań");
            }
            else if(solutions.Length == 1)
            {
                Console.WriteLine("Rozwiązanie: {0}", solutions[0]);
            }
            else
            {
                Console.WriteLine($"x1: {solutions[0]} x2: {solutions[1]}");
            }
        }
    }
}
