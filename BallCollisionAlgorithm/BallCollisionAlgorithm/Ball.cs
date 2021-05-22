using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallCollisionAlgorithm
{
    public class Ball
    {
        public Ball(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public double DistanceTo(Ball otherBall)
        {
            var x = Math.Pow(otherBall.X - this.X, 2);
            var y = Math.Pow(otherBall.Y - this.Y, 2);
            var z = Math.Pow(otherBall.Z - this.Z, 2);
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
            switch(axisUpper)
            {
                case "X":
                    return this.X;
                case "Y":
                    return this.Y;
                case "Z":
                    return this.Z;
                default:
                    throw new ArgumentException();
            }
        }

        public bool Equals(Ball other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return this.X.Equals(other.X) && this.Y.Equals(other.Y) && this.Z.Equals(other.Z);
        }

        public override string ToString() => $"({this.X}, {this.Y}, {this.Z})";
    }
}
