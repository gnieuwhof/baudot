using nl.gn.BaudotPortable;
using System;

namespace TestBaudot
{
    class Program
    {
        static void Main(string[] args)
        {
            string plain = "The quick brown fox jumped over the lazy dog." + Environment.NewLine +
               "abcdefghijklmnopqrstuvwxyz" + Environment.NewLine +
               "0123456789 - ' ! & $ Ю ( ) + / : = ? , .";

            bool lsbFirst = false;

            var baudot = Baudot.ToCode(plain, lsbFirst);

            int codesPrinted = 0;

            foreach (var b in baudot)
            {
                if(codesPrinted % 10 == 0)
                {
                    Console.WriteLine();
                }

                string binary = "0000" + Convert.ToString(b.Value, 2);

                Console.Write(binary.Substring(binary.Length - 5));
                Console.Write(' ');

                ++codesPrinted;
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.Write(Baudot.FromCode(baudot, lsbFirst));

            Console.ReadKey();
        }
    }
}
