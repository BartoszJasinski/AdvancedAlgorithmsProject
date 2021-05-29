using System;
using System.Collections.Generic;
using System.Linq;

namespace BallCollisionAlgorithm
{
    public static class RecursiveCollisionAlgorithm
    {
        public static List<(Ball, Ball)> Solve(List<Ball> balls, bool axisCheck = true)
        {
            if (balls.Count <= 3)
            {
                return BruteforceCollisionAlgorithm.Solve(balls);
            }

            var collisions = new List<(Ball, Ball)>();
            var usedAxises = new List<string>(2);
            var widestAxis = GetWidestRangeAxis(balls, usedAxises, axisCheck);
            usedAxises.Add(widestAxis);

            var orderedBalls = balls.OrderBy(b => b.GetByAxis(widestAxis)).ToList();
            var L = orderedBalls.GetRange(0, orderedBalls.Count / 2);
            var R = orderedBalls.GetRange(orderedBalls.Count / 2, orderedBalls.Count - L.Count);
            collisions.AddRange(Solve(L));
            collisions.AddRange(Solve(R));

            var ballsPrim = orderedBalls.Where(b => Math.Abs(b.GetByAxis(widestAxis) - L.Last().GetByAxis(widestAxis)) <= 2).ToList();
            if(ballsPrim.Count <= 1)
            {
                return collisions;
            }

            widestAxis = GetWidestRangeAxis(ballsPrim, usedAxises, axisCheck);
            usedAxises.Add(widestAxis);

            var orderedBallsPrim = ballsPrim.OrderBy(b => b.GetByAxis(widestAxis)).ToList();
            var LPrim = orderedBallsPrim.GetRange(0, orderedBallsPrim.Count / 2);
            var RPrim = orderedBallsPrim.GetRange(orderedBallsPrim.Count / 2, orderedBallsPrim.Count - LPrim.Count);
            // The tricky part, if uncommented the duplicates will happen
            //collisions.AddRange(Solve(L));
            //collisions.AddRange(Solve(R));

            var ballsBis = orderedBallsPrim.Where(b => Math.Abs(b.GetByAxis(widestAxis) - LPrim.Last().GetByAxis(widestAxis)) <= 2).ToList();
            if (ballsBis.Count <= 1)
            {
                return collisions;
            }

            string axis;
            if (!usedAxises.Contains("X"))
            {
                axis = "X";
            }
            else if (!usedAxises.Contains("Y"))
            {
                axis = "Y";
            }
            else
            {
                axis = "Z";
            }

            orderedBallsPrim = ballsBis.OrderBy(b => b.GetByAxis(axis)).ToList();
            Ball ball1;
            Ball ball2;

            // Better version if we can distinguish balls from L and balls from R
            //for(int i = 0; i < orderedBalls.Count; i++)
            //{
            //    for(int j = i + 1; j < orderedBalls.Count; j++)
            //    {
            //        ball1 = orderedBalls[i];
            //        ball2 = orderedBalls[j];
            //        if (Math.Abs(ball1.GetByAxis(axis) - ball2.GetByAxis(axis)) > 2)
            //        {
            //            break;
            //        }

            //        if(ball1.DistanceTo(ball2) <= 2)
            //        {
            //            collisions.Add((ball1, ball2));
            //        }
            //    }
            //}

            // Worse but works for now
            for (int i = 0; i < L.Count; i++)
            {
                for(int j = 0; j < R.Count; j++)
                {
                    ball1 = L[i];
                    ball2 = R[j];

                    if (ball1.DistanceTo(ball2) <= 2)
                    {
                        collisions.Add((ball1, ball2));
                    }
                }
            }

            return collisions;
        }

        private static string GetWidestRangeAxis(List<Ball> balls, List<string> exceptAxis, bool axisCheck)
        {
            if (!axisCheck)
            {
                if(exceptAxis.Count == 0)
                {
                    return "X";
                }
                if (exceptAxis.Count == 1)
                {
                    return "Y";
                }
                return "Z";
            }

            double xMin = double.MaxValue, xMax = double.MinValue;
            double yMin = double.MaxValue, yMax = double.MinValue;
            double zMin = double.MaxValue, zMax = double.MinValue;
            foreach(var ball in balls)
            {
                if(ball.X < xMin)
                {
                    xMin = ball.X;
                }

                if (ball.Y < yMin)
                {
                    yMin = ball.Y;
                }

                if (ball.Z < zMin)
                {
                    zMin = ball.Z;
                }

                if (ball.X > xMax)
                {
                    xMax = ball.X;
                }

                if (ball.Y > yMax)
                {
                    yMax = ball.Y;
                }

                if (ball.Z > zMax)
                {
                    zMax = ball.Z;
                }
            }

            var xRange = xMax - xMin;
            var yRange = yMax - yMin;
            var zRange = zMax - zMin;
            var orderedRanges = new List<(double range, string axis)>
            {
                (xRange, "X"),
                (yRange, "Y"),
                (zRange, "Z")
            }
            .OrderByDescending(x => x.range)
            .ToList();

            if (!exceptAxis.Contains(orderedRanges[0].axis))
            {
                return orderedRanges[0].axis;
            }
            else if (!exceptAxis.Contains(orderedRanges[1].axis))
            {
                return orderedRanges[1].axis;
            }
            else
            {
                return orderedRanges[2].axis;
            }
        }

    }
}
