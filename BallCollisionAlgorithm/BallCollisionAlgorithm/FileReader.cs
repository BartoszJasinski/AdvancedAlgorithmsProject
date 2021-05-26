using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    public class FileReader
    {
        public static List<Ball> ReadFile(string fileName)
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

        private static List<Ball> ParseFile(string filePath)
        {
            var balls = new List<Ball>();
            var fileLines = File.ReadAllLines(filePath + ".bls");
            foreach (var fileLine in fileLines)
            {
                var splittedLine = fileLine.Split();
                balls.Add(new Ball(Double.Parse(splittedLine[0]), Double.Parse(splittedLine[1]), Double.Parse(splittedLine[2])));
            }

            return balls;
        }
    }
}