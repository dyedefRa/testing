using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UsingQuartz
{
    class Program
    {
        static void Main(string[] args)
        {
            Helpers.InitializeJobs();
            Console.WriteLine("Zamanlanmış görev başladı");
            Console.ReadLine();

        }
    }
}
