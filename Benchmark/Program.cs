using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Sluggy;

namespace Benchmark
{
    public class Program
    {
        public class TestType
        {
            public string Name { get; set; }

            public Action<string> Run { get; set; }
        }

        public static void Main(string[] args)
        {
            int[] sizes = new int[] { 15, 30, 100, 1000, 10000, int.MaxValue };
            const int sampleSize = 127000;

            var types = new List<TestType>()
            {
                new TestType
                {
                    Name = "Join Eager",
                    Run = (str) => str.ToSlug2()
                },
                new TestType
                {
                    Name = "Join Lazy",
                    Run = (str) => str.ToSlug3()
                }
            };

            var stopWatch = new Stopwatch();
            foreach (var curr in sizes)
            {
                var stringToRun = string.Concat(Enumerable.Repeat('à', curr));

                Console.WriteLine($"SAMPLE SIZE = {curr}");
                foreach (var currType in types)
                {
                    stopWatch.Restart();
                    for (var i = 0; i < sampleSize; i++)
                    {
                        currType.Run(stringToRun);
                    }
                    Console.WriteLine($"Type {currType.Name} ran in {stopWatch.ElapsedMilliseconds} ms");
                }
            }
        }
    }
}