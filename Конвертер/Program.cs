using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Security.Cryptography;

namespace Конвертер
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            conv.sozd();
            do
            {
                Console.Clear();
                Console.WriteLine("Введите полный путь до файла, который хотите прочитать. \n----------------------------------------------------------------------------");
                conv.chtenie();
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Console.WriteLine("Введите полный путь до файла, указывая формат, в котором хотите сохранить.\n----------------------------------------------------------------------------");
                    conv.zapis();
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                }
            } while (key.Key != ConsoleKey.Escape);
            
        }
    }
}