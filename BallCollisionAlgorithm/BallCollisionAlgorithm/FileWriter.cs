namespace BallCollisionAlgorithm
{
    public static class FileWriter
    {
        public static void GenerateFile(double x, double y, double z, int numberOfBalls, string fileName)
        {
            var envSlashSetting = "\\";
            if(Environment.OSVersion.Platform == PlatformID.Unix)
            {
                envSlashSetting = "/";
            }

            var directory = Directory.GetCurrentDirectory();
            var filePath = directory + envSlashSetting + fileName + ".bls";
            
            File.WriteAllLines(filePath, GenerateFileText(x, y, z, numberOfBalls));
        }

        private static string[] GenerateFileText(double x, double y, double z, int numberOfBalls)
        {
            var balls = BallGenerator.GenerateBalls(x, y, z, numberOfBalls);
            var fileText = new string[numberOfBalls];
            var i = 0;
            foreach (var ball in balls)
            {
                fileText[i] += ball.ToString();
                i++;
            }

            return fileText;
        }

    }
}