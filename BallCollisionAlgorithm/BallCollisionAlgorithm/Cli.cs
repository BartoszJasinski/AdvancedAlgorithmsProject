using System;
using System.Diagnostics;
using System.Linq;

namespace BallCollisionAlgorithm
{
    public class Cli
    {
        public void RunAlgorithm(string fileName)
        {
            var sw = new Stopwatch();
            sw.Start();
            var balls = FileReader.ReadFile(fileName).ToList();
            var pairs = RecursiveCollisionAlgorithm.Solve(balls, true);
            sw.Stop();
            
            Console.WriteLine("Count: " + pairs.Count + ", elapsed time: " + sw.ElapsedMilliseconds + "ms");
        }

        public void GenerateFile(double xAxisRange, double yAxisRange, double zAxisRange, int numberOfBalls, string fileName)
        {
            FileWriter.GenerateFile(xAxisRange, yAxisRange, zAxisRange, numberOfBalls, fileName);
        }
    }
}