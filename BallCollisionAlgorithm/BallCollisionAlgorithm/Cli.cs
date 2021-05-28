namespace BallCollisionAlgorithm
{
    public class Cli
    {
        [Command(Description = "Runs algorithm with balls from given file")]
        public void RunAlgorithm(string fileName)
        {
            var sw = new Stopwatch();
            sw.Start();
            var balls = FileReader.ReadFile(fileName);
            var pairs = RecursiveCollisionAlgorithm.Solve(balls, true);
            sw.Stop();
            
            Console.WriteLine("Count: " + pairs.Count + ", elapsed time: " + sw.ElapsedMilliseconds + "ms");
        }

        [Command(Description = "Generate file with balls coordinates")]
        public void GenerateFile(double xAxisRange, double yAxisRange, double zAxisRange, int numberOfBalls, string fileName)
        {
            FileWriter.GenerateFile(xAxisRange, yAxisRange, zAxisRange, numberOfBalls, fileName);
        }
    }
}