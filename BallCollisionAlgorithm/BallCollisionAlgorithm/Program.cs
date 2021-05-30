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
            Console.WriteLine($"{findTestFiles}. Find all test files in the current directory and solve them using both algorithms");
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
