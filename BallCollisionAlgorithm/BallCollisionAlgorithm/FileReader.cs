using System;
using System.Collections.Generic;
using System.IO;

namespace BallCollisionAlgorithm
{
    public static class FileReader
    {
        public static IEnumerable<Ball> ReadFile(string fileName)
        {
            var envSlashSetting = "\\";
            if(Environment.OSVersion.Platform == PlatformID.Unix)
            {
                envSlashSetting = "/";
            }

            var directory = Directory.GetCurrentDirectory();
            var filePath = directory + envSlashSetting + fileName;

            return ParseFile(filePath);

        }

        private static IEnumerable<Ball> ParseFile(string filePath)
        {
            var fileLines = File.ReadAllLines(filePath + ".bls");

            return fileLines.Select(fileLine => fileLine.Split()).Select(splittedLine => new Ball(ParseNumber(splittedLine[0]), ParseNumber(splittedLine[1]), ParseNumber(splittedLine[2]))).ToList();
        }

        private static double ParseNumber(string number)
        {
            return double.Parse(number, CultureInfo.InvariantCulture);
        }
    }
}