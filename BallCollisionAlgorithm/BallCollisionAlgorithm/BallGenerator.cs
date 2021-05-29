using System;
using System.Collections.Generic;

namespace BallCollisionAlgorithm
{
    public static class BallGenerator
    {
        public static IEnumerable<Ball> GenerateBalls(double x, double y, double z, int numberOfBalls)
        {
            var balls = new List<Ball>();
            var random = new Random();
            for (var i = 0; i < numberOfBalls; i++)
            {
                balls.Add(GenerateBall(x, y, z, random));
            }

            return balls;
        }

        private static Ball GenerateBall(double x, double y, double z, Random random)
        {
            return new Ball(random.NextDouble(0, x), random.NextDouble(0, y), random.NextDouble(0, z));
        }
    }
}