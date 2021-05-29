using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BallCollisionAlgorithm
{
    public class Program
    {
        private const int generateTestFile = 1;

        private const int solveBruteforce = 2;

        private const int solveRecursive = 3;

        private const int exit = 4;

        public static void Main(string[] args)
        {
            while (true)
            {
                var option = GetOption();
                switch (option)
                {
                    case generateTestFile:
                        HandleGenerateTestFileOption();
                        break;
                    case solveBruteforce:
                        HandleBruteforceOption();
                        break;
                    case solveRecursive:
                        HandleRecursiveOption();
                        break;
                    case exit:
                        return;
                }
            }

			//			********BELOW LINES ARE FOR TESTS OF FILE WRITER, DELETE AFTER TESTS********
 //           FileWriter.GenerateFile(10, 10, 10, 10, "ballsWriter");

            //			********BELOW LINES ARE FOR TESTS OF FILE READER, DELETE AFTER TESTS********
   //         var bals = FileReader.ReadFile("ballsWriter");

     //       foreach (var bal in bals)
       //     {
         //       Console.WriteLine(bal.X + " " + bal.Y + " " + bal.Z);
           // }


   //         var x = 5;
   //         var y = 12;
			//var z = 42;
   //         var count = 10000;

   //         var balls = new List<Ball>()
   //         {
   //             //new Ball(1, 2, 3),
   //             //new Ball(0.5, 2.3, 0),
   //             //new Ball(1, 2, 5),
   //             //new Ball(1, 2, 4),
   //             //new Ball(100000, 20, 1),
   //             //new Ball(300000, 1, 3),
   //             //new Ball(2, 2, 2),
   //             //new Ball(5, 5, 5),
   //         };

   //         var random = new Random();
   //         var sw = new Stopwatch();


   //         balls = BallGenerator.GenerateBalls(x, y, z, count);


   //         Console.WriteLine("Recursive:");
   //         sw.Start();
   //         var pairs = RecursiveCollisionAlgorithm.Solve(balls, true);
   //         sw.Stop();
   //         Console.WriteLine("Count: " + pairs.Count + ", elapsed time: " + sw.ElapsedMilliseconds + "ms");


   //         Console.WriteLine("Recursive without axis:");
   //         sw.Start();
   //         pairs = RecursiveCollisionAlgorithm.Solve(balls, false);
   //         sw.Stop();
   //         Console.WriteLine("Count: " + pairs.Count + ", elapsed time: " + sw.ElapsedMilliseconds + "ms");

   //         Console.WriteLine("Bruteforce:");
   //         sw.Reset();
   //         sw.Start();
   //          pairs = BruteforceCollisionAlgorithm.Solve(balls).OrderBy(x => x.Item1.X).ToList();
   //         sw.Stop();
   //         Console.WriteLine("Count: " + pairs.Count + ", elapsed time: " + sw.ElapsedMilliseconds + "ms");
            //pairs.ForEach(x =>
            //{
            //    Console.WriteLine($"{x.Item1} - {x.Item2}, dist: {x.Item1.DistanceTo(x.Item2)}");
            //});
            //pairs.ForEach(x =>
            //{
            //    Console.WriteLine($"{x.Item1} - {x.Item2}, dist: {x.Item1.DistanceTo(x.Item2)}");
            //});
        }

        private static void HandleGenerateTestFileOption()
        {
            Console.WriteLine("Enter file path");
            var filePath = Console.ReadLine();

            double xMax, yMax, zMax;
            int ballCount;

            Console.WriteLine("Enter number of balls");
            while (!int.TryParse(Console.ReadLine(), out ballCount))
            {
                Console.WriteLine("Wrong format. Try again.");
            }

            Console.WriteLine("Enter maximum value for x coordinate");
            while (!double.TryParse(Console.ReadLine(), out xMax))
            {
                Console.WriteLine("Wrong format. Try again.");
            }

            Console.WriteLine("Enter maximum value for y coordinate");
            while (!double.TryParse(Console.ReadLine(), out yMax))
            {
                Console.WriteLine("Wrong format. Try again.");
            }

            Console.WriteLine("Enter maximum value for z coordinate");
            while (!double.TryParse(Console.ReadLine(), out zMax))
            {
                Console.WriteLine("Wrong format. Try again.");
            }

            FileWriter.GenerateFile(xMax, yMax, zMax, ballCount, filePath);
        }

        private static void HandleBruteforceOption()
        {
            Console.WriteLine("Enter file path");
            var filePath = Console.ReadLine();
            if (!filePath.EndsWith(".txt"))
            {
                filePath += ".txt";
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("This file doesn't exist.");
                return;
            }

            var balls = FileReader.ReadFile(filePath).ToList();

            var sw = new Stopwatch();

            Console.WriteLine("Starting brutefoce algorithm...");
            sw.Start();
            var pairs = BruteforceCollisionAlgorithm.Solve(balls);
            sw.Stop();

            Console.WriteLine("Found " + pairs.Count + " colliding ball pairs in " + sw.ElapsedMilliseconds + "ms");
        }

        private static void HandleRecursiveOption()
        {
            Console.WriteLine("Enter file path");
            var filePath = Console.ReadLine();
            if (!filePath.EndsWith(".txt"))
            {
                filePath += ".txt";
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("This file doesn't exist.");
                return;
            }

            var balls = FileReader.ReadFile(filePath).ToList();

            var sw = new Stopwatch();

            Console.WriteLine("Starting recursive algorithm...");
            sw.Start();
            var pairs = RecursiveCollisionAlgorithm.Solve(balls, true);
            sw.Stop();

            Console.WriteLine("Found " + pairs.Count + " colliding ball pairs in " + sw.ElapsedMilliseconds + "ms");
        }

        private static int GetOption()
        {
            Console.WriteLine("\nChoose option:");
            Console.WriteLine($"{generateTestFile}. Generate new test file");
            Console.WriteLine($"{solveBruteforce}. Solve using brutefoce algorithm");
            Console.WriteLine($"{solveRecursive}. Solve using recursive algorithm");
            Console.WriteLine($"{exit}. Exit the program");
            var options = new List<int>() { generateTestFile, solveBruteforce, solveRecursive, exit };
            while (true)
            {
                var input = Console.ReadLine();
                if(int.TryParse(input, out int option) && options.Contains(option))
                {
                    return option;
                }

                Console.WriteLine("Wrong option value. Try again.");
            }
        }
    }
}
