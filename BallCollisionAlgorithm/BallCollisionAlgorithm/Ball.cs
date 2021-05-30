using System;
using System.Globalization;

namespace BallCollisionAlgorithm
{
    public class Ball
    {
        public Ball(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public double DistanceTo(Ball otherBall)
        {
            var x = Math.Pow(otherBall.X - X, 2);
            var y = Math.Pow(otherBall.Y - Y, 2);
            var z = Math.Pow(otherBall.Z - Z, 2);
            return Math.Sqrt(x + y + z);
        }

        /// <summary>
        /// Gets the axisName coordinate of the ball.
        /// </summary>
        /// <param name="axisName">One of X, Y or Z.</param>
        /// <returns></returns>
        public double GetByAxis(string axisName)
        {
            var axisUpper = axisName.ToUpper();
            switch (axisUpper)
            {
                case "X":
                    return X;
                case "Y":
                    return Y;
                case "Z":
                    return Z;
                default:
                    throw new ArgumentException();
            }
        }

        public bool Equals(Ball other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override string ToString() => $"{X.ToString(CultureInfo.InvariantCulture)} {Y.ToString(CultureInfo.InvariantCulture)} {Z.ToString(CultureInfo.InvariantCulture)}";
    }
}
