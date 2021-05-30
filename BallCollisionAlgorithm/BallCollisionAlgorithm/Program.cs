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

        private const int findTestFiles = 4;

        private const int exit = 5;

        private const string bruteforceResultSuffix = "_results_b";

        private const string recursiveResultSuffix = "_results_r";

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
                    case findTestFiles:
                        HandleFindTestFilesOption();
                        break;
                    case exit:
                        return;
                }
            }
            //var numberOfBalls = 100000.0;
            //var numberOfPossibleCollisions = (numberOfBalls * (numberOfBalls - 1)) / 2.0;
            //var results = new List<CollisionResult>();
            //var bruteforceStopwatch = new Stopwatch();
            //var recursiveStopwatch = new Stopwatch();
            ////var bruteforceAverage = 0.0;

            ////for (int i = 0; i < 1; i++)
            ////{
            ////    Console.WriteLine("bt " + i);
            ////    var range = 1000000;
            ////    var balls = BallGenerator.GenerateBalls(range, range, range, (int)numberOfBalls).ToList();
            ////    bruteforceStopwatch.Restart();
            ////    var bruteforcePairs = BruteforceCollisionAlgorithm.Solve(balls);
            ////    bruteforceStopwatch.Stop();
            ////    bruteforceAverage += bruteforceStopwatch.ElapsedMilliseconds;
            ////    Console.WriteLine(bruteforceStopwatch.ElapsedMilliseconds);
            ////}

            ////bruteforceAverage = bruteforceAverage / 1.0;
            ////Console.WriteLine("Average: " + bruteforceAverage);
            //using (var file = new StreamWriter($"results_0_collisions_recursive.csv"))
            //{
            //    file.WriteLine("Number of balls;Recursive ms");
            //    file.Flush();
            //    for (double numberOfBalls = 1; numberOfBalls < 1000000000; numberOfBalls *= 10)
            //    {
            //        var range = 10000000000000000;
            //        Console.WriteLine("numberOfBalls = " + numberOfBalls);
            //        //var dividor = 30.0;
            //        //var range = 1 + Math.Pow(i / dividor, 1.0 / 3.0) + i / 50.0; // dla w miare malych number of balls
            //        //var range = i; // dla duzych number of balls dla i od 50 do 1 
            //        //Console.WriteLine("Range : " + range);
            //        var balls = BallGenerator.GenerateBalls(range, range, range, (int)numberOfBalls).ToList();
            //        //bruteforceStopwatch.Restart();
            //        //var bruteforcePairs = BruteforceCollisionAlgorithm.Solve(balls);
            //        //bruteforceStopwatch.Stop();
            //        //Console.WriteLine("Bruteforce: Found " + pairs.Count + " colliding ball pairs in " + sw.ElapsedMilliseconds + "ms");
            //        recursiveStopwatch.Restart();
            //        var recursivePairs = RecursiveCollisionAlgorithm.Solve(balls);
            //        recursiveStopwatch.Stop();
            //        Console.WriteLine("Recursive:  Found " + recursivePairs.Count + " colliding ball pairs in " + recursiveStopwatch.ElapsedMilliseconds + "ms");
            //        //Console.WriteLine("Percentage of possible collisions = " + 100.0 * (double)pairs2.Count / numberOfPossibleCollisions + "%");
            //        //Console.WriteLine("Difference: " + Math.Abs(pairs2.Count - pairs.Count) + "\n\n");
            //        //var percentage = 100.0 * (double)recursivePairs.Count / numberOfPossibleCollisions;
            //        file.WriteLine($"{numberOfBalls};{recursiveStopwatch.ElapsedMilliseconds}");
            //        file.Flush();
            //    }
            //}





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

        private static void HandleFindTestFilesOption()
        {
            Console.WriteLine();
            var txtFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            foreach (var filePath in txtFiles)
            {
                try
                {
                    Console.WriteLine($"Processing {filePath}\n");
                    var balls = FileReader.ReadFile(filePath).ToList();

                    var brutefoceStopwatch = new Stopwatch();
                    Console.WriteLine("Starting brutefoce algorithm...");
                    brutefoceStopwatch.Start();
                    var bruteforcePairs = BruteforceCollisionAlgorithm.Solve(balls);
                    brutefoceStopwatch.Stop();
                    Console.WriteLine("Brutefoce: Found " + bruteforcePairs.Count + " colliding ball pairs in " + brutefoceStopwatch.ElapsedMilliseconds + "ms");
                    WriteResults(bruteforcePairs, filePath, brutefoceStopwatch.ElapsedMilliseconds, balls.Count, bruteforceResultSuffix);

                    var recursiveStopwatch = new Stopwatch();
                    Console.WriteLine("\nStarting recursive algorithm...");
                    recursiveStopwatch.Start();
                    var recursivePairs = RecursiveCollisionAlgorithm.Solve(balls);
                    recursiveStopwatch.Stop();
                    Console.WriteLine("Recursive: Found " + recursivePairs.Count + " colliding ball pairs in " + recursiveStopwatch.ElapsedMilliseconds + "ms");
                    WriteResults(recursivePairs, filePath, recursiveStopwatch.ElapsedMilliseconds, balls.Count, recursiveResultSuffix);

                }
                catch (Exception e)
                {
                    Console.WriteLine($"There was an error while processing {Path.GetFileName(filePath)} file:\n{e.Message}");
                }

                Console.WriteLine("\n***********************************\n");
            }
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

            try
            {
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
                WriteResults(pairs, filePath, sw.ElapsedMilliseconds, balls.Count, bruteforceResultSuffix);
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was an error while processing {Path.GetFileName(filePath)} file:\n{e.Message}");
            }
        }

        private static void HandleRecursiveOption()
        {
            Console.WriteLine("Enter file path");
            var filePath = Console.ReadLine();
            if (!filePath.EndsWith(".txt"))
            {
                filePath += ".txt";
            }

            try
            {
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
                WriteResults(pairs, filePath, sw.ElapsedMilliseconds, balls.Count, recursiveResultSuffix);
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was an error while processing {Path.GetFileName(filePath)} file:\n{e.Message}");
            }
        }

        private static int GetOption()
        {
            Console.WriteLine("\nChoose option:");
            Console.WriteLine($"{generateTestFile}. Generate new test file");
            Console.WriteLine($"{solveBruteforce}. Solve using brutefoce algorithm");
            Console.WriteLine($"{solveRecursive}. Solve using recursive algorithm");
            Console.WriteLine($"{findTestFiles}. Find all .txt files in the current directory and solve them using both algorithms");
            Console.WriteLine($"{exit}. Exit the program");
            var options = new List<int>() { generateTestFile, solveBruteforce, solveRecursive, findTestFiles, exit };
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out int option) && options.Contains(option))
                {
                    return option;
                }

                Console.WriteLine("Wrong option value. Try again.");
            }
        }

        private static void WriteResults(List<(Ball, Ball)> results, string testFilePath, long runtime, int numberOfBalls, string suffix)
        {
            try
            {
                if (!testFilePath.EndsWith(".txt"))
                {
                    return;
                }

                var resultAllLines = results
                    .Select(pair => $"({pair.Item1}) - ({pair.Item2}) [{pair.Item1.DistanceTo(pair.Item2)}]");

                var resultFilePath = testFilePath.Insert(testFilePath.Length - 4, suffix);
                File.WriteAllLines(resultFilePath, new string[] { $"Ball count: {numberOfBalls}, collision count: {results.Count}, runtime: {runtime}ms" });
                File.AppendAllLines(resultFilePath, resultAllLines);
                Console.WriteLine($"Results written to {resultFilePath}.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was an error while trying to write results for {testFilePath}:\n{e.Message}");
            }
        }
    }
}
