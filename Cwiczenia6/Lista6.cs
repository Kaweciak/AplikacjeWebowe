using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjeWebowe.Cwiczenia6
{
    internal class Lista6
    {
        static void Zad1()
        {
            (string imie, string nazwisko, int wiek, int placa) t1 = ("Jan", "Kowalski", 25, 5000);
            Console.WriteLine($"imie: {t1.imie}, nazwisko: {t1.nazwisko}, wiek: {t1.wiek}, placa: {t1.placa}");
            Console.WriteLine($"imie: {t1.Item1}, nazwisko: {t1.Item2}, wiek: {t1.Item3}, placa: {t1.Item4}");
            var (imie, nazwisko, wiek, placa) = t1;
            Console.WriteLine($"imie: {imie}, nazwisko: {nazwisko}, wiek: {wiek}, placa: {placa}");
        }

        static void Zad2()
        {
            string @class = "string nazwany class po co nam ta wiedza czemu mielibysmy nazwac zmienna class";
            Console.WriteLine(@class);
        }

        static void Zad3()
        {
            int[] numbers = { 3, 6, 2, 5, 4, 1 };

            Array.Sort(numbers);
            Console.WriteLine(string.Join(" ", numbers));

            Array.Reverse(numbers);
            Console.WriteLine(string.Join(" ", numbers));

            Console.WriteLine(Array.IndexOf(numbers, 5));

            int[] copy = new int[3];
            Array.Copy(numbers, 1, copy, 0, 3);
            Console.WriteLine(string.Join(" ", copy));

            Array.Clear(numbers, 2, 2);
            Console.WriteLine(string.Join(" ", numbers));
        }

        static void Zad4()
        {
            var t1 = new { imie = "Jan", nazwisko = "Kowalski", wiek = 25, placa = 5000 };
            Console.WriteLine($"imie: {t1.imie}, nazwisko: {t1.nazwisko}, wiek: {t1.wiek}, placa: {t1.placa}");
        }

        static void DrawCard(string line1, string line2 = "", char frameChar = 'X', int frameWidth = 1, int minWidth = 10, int minHeight = 5)
        {
            int width = Math.Max(Math.Max(line1.Length, line2.Length) + frameWidth * 2, minWidth);
            int height = Math.Max(2 + 2 * frameWidth, minHeight);

            for (int i = 0; i < frameWidth; i++)
            {
                Console.WriteLine(new string(frameChar, width));
            }

            int heightPaddingBottom = (height - 2 - 2 * frameWidth) / 2;
            int heightPaddingTop = height % 2 == 1 ? heightPaddingBottom + 1 : heightPaddingBottom;

            for (int i = 0; i < heightPaddingTop; i++)
            {
                Console.WriteLine(new string(frameChar, frameWidth) + new string(' ', width - 2 * frameWidth) + new string(frameChar, frameWidth));
            }

            int widthPaddingLeft = (width - line1.Length) / 2 - frameWidth;
            int widthPaddingRight = (line1.Length + 2*widthPaddingLeft + 2*frameWidth) < width ? widthPaddingLeft + 1 : widthPaddingLeft;
            Console.WriteLine(new string(frameChar, frameWidth) + new string(' ', widthPaddingLeft) + line1 + new string(' ', widthPaddingRight) + new string(frameChar, frameWidth));
            widthPaddingLeft = (width - line2.Length) / 2 - frameWidth;
            widthPaddingRight = (line2.Length + 2 * widthPaddingLeft + 2 * frameWidth) < width ? widthPaddingLeft + 1 : widthPaddingLeft;
            Console.WriteLine(new string(frameChar, frameWidth) + new string(' ', widthPaddingLeft) + line2 + new string(' ', widthPaddingRight) + new string(frameChar, frameWidth));

            for (int i = 0; i < heightPaddingBottom; i++)
            {
                Console.WriteLine(new string(frameChar, frameWidth) + new string(' ', width - 2 * frameWidth) + new string(frameChar, frameWidth));
            }

            for (int i = 0; i < frameWidth; i++)
            {
                Console.WriteLine(new string(frameChar, width));
            }
        }

        static void Zad5()
        {
            DrawCard("Kawecki", "Kacper", frameWidth: 2, minWidth: 1);
            Console.WriteLine("\n\n");
            DrawCard("Grzegorz", "Brzęczyszczykiewicz", frameWidth: 8, minWidth: 80, frameChar: '0', minHeight: 25);
            Console.WriteLine("\n\n");
            DrawCard("nic");
        }

        static (int evenIntegers, int positiveDoubles, int longStrings, int otherTypes) CountMyTypes(params object[] elements)
        {
            int evenIntegers = 0;
            int positiveDoubles = 0;
            int longStrings = 0;
            int otherTypes = 0;
            foreach (var element in elements)
            {
                switch (element)
                {
                    case int i when i % 2 == 0:
                        evenIntegers++;
                        break;
                    case double d when d > 0:
                        positiveDoubles++;
                        break;
                    case string s when s.Length >= 5:
                        longStrings++;
                        break;
                    default:
                        otherTypes++;
                        break;
                }
            }
            return (evenIntegers, positiveDoubles, longStrings, otherTypes);
        }

        static void Zad6()
        {
            var result = CountMyTypes(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -1.1, 2.2, -3.3, 4.4, 5.5, -6.6, 7.7, 8.8, -9.9, 10.10, "a", "bb", "ccc", "dddd", "eeeee", "ffffff", "ggggggg", "hhhhhhhh", "iiiiiiiii", "jjjjjjjjj", 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j');
            Console.WriteLine($"evenIntegers: {result.evenIntegers}, positiveDoubles: {result.positiveDoubles}, longStrings: {result.longStrings}, otherTypes: {result.otherTypes}");
            result = CountMyTypes("aaaaaaaaaaaa", "bbbbbbbbbb", 123, 124, "abc", -21.0, 37.0);
            Console.WriteLine($"evenIntegers: {result.evenIntegers}, positiveDoubles: {result.positiveDoubles}, longStrings: {result.longStrings}, otherTypes: {result.otherTypes}");
        }

        static void zadania(string[] args)
        {
            Console.WriteLine("Które zadanie uruchomić?");
            int zadanie = int.Parse(Console.ReadLine());
            switch (zadanie)
            {
                case 1:
                    Zad1();
                    break;
                case 2:
                    Zad2();
                    break;
                case 3:
                    Zad3();
                    break;
                case 4:
                    Zad4();
                    break;
                case 5:
                    Zad5();
                    break;
                case 6:
                    Zad6();
                    break;
                default:
                    Console.WriteLine("Nie ma takiego zadania");
                    break;
            }
        }
    }
}
