using System.IO;
using System.Linq;

namespace BallCollisionAlgorithm
{
    public static class FileWriter
    {
        public static void GenerateFile(double x, double y, double z, int numberOfBalls, string filePath)
        {
            if (!filePath.EndsWith(".txt"))
            {
                filePath += ".txt";
            }

            File.WriteAllLines(filePath, GenerateFileText(x, y, z, numberOfBalls));
        }

        private static string[] GenerateFileText(double x, double y, double z, int numberOfBalls)
        {
            return BallGenerator
                .GenerateBalls(x, y, z, numberOfBalls)
                .Select(b => b.ToString())
                .ToArray();
        }
    }
}