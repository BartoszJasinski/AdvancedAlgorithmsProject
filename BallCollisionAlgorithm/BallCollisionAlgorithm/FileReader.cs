using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BallCollisionAlgorithm
{
    public static class FileReader
    {
        public static IEnumerable<Ball> ReadFile(string filePath)
        {
            if (!filePath.EndsWith(".txt"))
            {
                filePath += ".txt";
            }

            var fileLines = File.ReadAllLines(filePath);

            return fileLines
                .Select(fileLine => fileLine.Split())
                .Select(splittedLine => new Ball(
                    ParseNumber(splittedLine[0]),
                    ParseNumber(splittedLine[1]),
                    ParseNumber(splittedLine[2])))
                .ToList();
        }

        private static double ParseNumber(string number)
        {
            return double.Parse(number, CultureInfo.InvariantCulture);
        }
    }
}