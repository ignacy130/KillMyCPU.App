using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbersCounter
{
    public class PrimesResult
    {
        public long Result { get; set; }
        public long TimeInMiliseconds { get; set; }

        public PrimesResult(long result, long timeInMiliseconds)
        {
            Result = result;
            TimeInMiliseconds = timeInMiliseconds;
        }
    }

    public class PrimeNumberCounter
    {
        public async Task<PrimesResult> Run(int min = 100000, int max = 2000000)
        {
            var random = new Random();

            return await FindPrimeNumber(random.Next(min, max));
        }

        private static Task<PrimesResult> FindPrimeNumber(int n)
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
            return Task.FromResult(new PrimesResult(--a, stopwatch.ElapsedMilliseconds));
        }
    }
}
