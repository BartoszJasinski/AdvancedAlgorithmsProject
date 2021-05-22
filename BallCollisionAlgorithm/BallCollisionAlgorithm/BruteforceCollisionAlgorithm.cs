using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallCollisionAlgorithm
{
    public static class BruteforceCollisionAlgorithm
    {
        public static List<(Ball, Ball)> Solve(List<Ball> balls)
        {
            var collidingBalls = new List<(Ball, Ball)>();

            for(int i = 0; i < balls.Count; i++)
            {
                for(int j = i + 1; j < balls.Count; j++)
                {
                    if(balls[i].DistanceTo(balls[j]) <= 2.0)
                    {
                        collidingBalls.Add((balls[i], balls[j]));
                    }
                }
            }

            return collidingBalls;
        }
    }
}
