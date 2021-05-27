using System;
using System.Collections.Generic;

namespace BallCollisionAlgorithm
{
    public class BallGenerator
    {
        public static List<Ball> GenerateBalls(double x, double y, double z, double numberOfBalls)
        {
            var balls = new List<Ball>();
            for (var i = 0; i < numberOfBalls; i++)
            {
                balls.Add(GenerateBall(x, y, z));
            }

            return balls;
        }

        public static Ball GenerateBall(double x, double y, double z)
        {
            var random = new Random();
            return new Ball(random.NextDouble(0, x), random.NextDouble(0, y), random.NextDouble(0, z));
        }
    }
}