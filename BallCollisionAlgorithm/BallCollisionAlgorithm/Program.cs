using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BallCollisionAlgorithm
{
    public class Program
    {
        static void Main(string[] args)
        {
            var min = 0;
            var max = 1000000.0;
            var count = 100000;
            var balls = new List<Ball>()
            {
                //new Ball(1, 2, 3),
                //new Ball(0.5, 2.3, 0),
                //new Ball(1, 2, 5),
                //new Ball(1, 2, 4),
                //new Ball(100000, 20, 1),
                //new Ball(300000, 1, 3),
                //new Ball(2, 2, 2),
                //new Ball(5, 5, 5),
            };

            var random = new Random(1);
            var sw = new Stopwatch();
             

            for (int i = 0; i < count; i++)
            {
                //balls.Add(new Ball(1, 1, 1));
                balls.Add(new Ball(random.NextDouble(min, max), random.NextDouble(min, max), random.NextDouble(min, max)));
            }


            Console.WriteLine("Recursive:");
            sw.Start();
            var pairs = RecursiveCollisionAlgorithm.Solve(balls, true);
            sw.Stop();
            Console.WriteLine("Count: " + pairs.Count + ", elapsed time: " + sw.ElapsedMilliseconds + "ms");


            Console.WriteLine("Recursive without axis:");
            sw.Start();
            pairs = RecursiveCollisionAlgorithm.Solve(balls, false);
            sw.Stop();
            Console.WriteLine("Count: " + pairs.Count + ", elapsed time: " + sw.ElapsedMilliseconds + "ms");

            Console.WriteLine("Bruteforce:");
            sw.Reset();
            sw.Start();
             pairs = BruteforceCollisionAlgorithm.Solve(balls).OrderBy(x => x.Item1.X).ToList();
            sw.Stop();
            Console.WriteLine("Count: " + pairs.Count + ", elapsed time: " + sw.ElapsedMilliseconds + "ms");
            //pairs.ForEach(x =>
            //{
            //    Console.WriteLine($"{x.Item1} - {x.Item2}, dist: {x.Item1.DistanceTo(x.Item2)}");
            //});
            //pairs.ForEach(x =>
            //{
            //    Console.WriteLine($"{x.Item1} - {x.Item2}, dist: {x.Item1.DistanceTo(x.Item2)}");
            //});
        }
    }
}
