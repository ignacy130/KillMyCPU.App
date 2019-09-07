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

        static private async Task MainAsync()
        {
            var random = new Random();
            while (true)
            {
                var actions = new List<Action>();
                for (int i = 0; i < 3; i++)
                {
                    var min = 100000;
                    var max = 2000000;
                    actions.Add(async () => await FindPrimeNumber(random.Next(min, max)));
                }
                Parallel.Invoke(actions.ToArray());
            }
        }

        public static Task<long> FindPrimeNumber(int n)
        {
            Console.WriteLine($"Started computing prime number for: {n}");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;// to check if found a prime
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            return Task.FromResult(--a);
        }
    }
}
