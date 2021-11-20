using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileFinder fileFinder = new FileFinder();
            fileFinder.GetFiles("media");
            fileFinder.ShowFiles();
            Console.ReadKey();
        }
    }
}
