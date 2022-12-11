using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed
{
    public class Nabor
    {
        public static void VvodImeni()
        {
            Console.Write("Привет. Это тест на скоропечатание. Введи свое имя: ");
            polzovateli.User = Console.ReadLine();
            Console.Clear();
            Nabor.VvodTeksta();
        }
        public static void VvodTeksta()
        {
            string a = ("Леопард является кошкой больших размеров, но уступает своей величиной тигру и льву. ");
            char[] c = a.ToCharArray();
            Console.WriteLine(c);
            int i = 0;
            Console.WriteLine("Когда будете готовы, нажмите Enter");
            ConsoleKeyInfo key1 = Console.ReadKey(intercept: true);
            if (key1.Key == ConsoleKey.Enter)
            {
                Stopwatch stopWatch = new Stopwatch(); // секундомер
                stopWatch.Start(); // запустить секундомер
                Console.SetCursorPosition(0, 0);
                while (i < c.Length)
                {
                    TimeSpan ts = stopWatch.Elapsed;
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                    if (key.KeyChar.Equals(c[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(c[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                        i++;
                        polzovateli.kol++;
                    }
                    else if ((ts.TotalSeconds == 60) || (key1.Key == ConsoleKey.Enter))
                    {
                        stopWatch.Stop(); // остановить секундомер
                        Console.SetCursorPosition(0, 6);
                        Console.WriteLine($"{ts.Seconds:00}:{ts.Milliseconds:00}"); // вывод секунд и милисекунд
                        polzovateli.RezMin = polzovateli.kol;
                        polzovateli.RezSec = polzovateli.kol / 60;
                        Save.Save1();
                    }
                }
            }
        }
    }
}
