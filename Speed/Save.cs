using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Speed
{
    internal class Save
    {
        public static string fail = "C:\\Users\\vipal\\Desktop\\rekordi.json";
        public static List<polzovateli> polzovatelis = new();
        public static void Save1()
        {
            polzovateli User1 = new();
            User1.User1 = polzovateli.User;
            User1.RezMin1 = polzovateli.RezMin;
            User1.RezSec1 = polzovateli.RezSec;
            polzovatelis.Add(User1);
            string Json = JsonConvert.SerializeObject(polzovatelis);
            File.AppendAllText(fail, Json);
            Console.Clear();
            VivodTable();
        }
        public static void VivodTable()
        {
            List<polzovateli> vivod = JsonConvert.DeserializeObject<List<polzovateli>>(File.ReadAllText(fail));
            foreach (var i in vivod)
            {
                Console.WriteLine(i.User1 + " Имя пользователя");
                Console.WriteLine(i.RezMin1 + " Кол-во символов в минуту");
                Console.WriteLine(i.RezSec1 + " Кол-во символов в секунду");
                Console.WriteLine("Хотите пройти еще раз? Тогда нажмите Enter. Для выхода нажмите Escape.");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Nabor.VvodImeni();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}