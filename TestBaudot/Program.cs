using nl.gn.Baudot;
using System;

namespace TestBaudot
{
    class Program
    {
        static void Main(string[] args)
        {
            string plain = "The quick brown fox jumped over the lazy dog." + Environment.NewLine +
               "abcdefghijklmnopqrstuvwxyz" + Environment.NewLine +
               "0123456789 - ' Э Ш Щ Ю ( ) + / : = ? , .";

            var baudot = Baudot.ToCode(plain, false);

            foreach (var b in baudot)
            {
                Console.Write(Convert.ToInt16(b.Value));
                Console.Write(' ');
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.Write(Baudot.FromCode(baudot, false));

            Console.ReadKey();
        }
    }
}
