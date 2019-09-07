using PrimeNumbersCounter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace KillMyCPU.App
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync();
        }

        public static async Task MainAsync()
        {
            new PrimeNumberCounter().Run();
        }
    }
}