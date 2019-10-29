using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stylecop
{
    class Circle: IShaper<Circle>
    {
        public Point O { get; set; }
        public double Radius { get; set; }

        public Circle() { }
        public Circle(Point o, double radius)
        {
            O = o;
            Radius = radius;
        }

        public Circle Move(double x, double y)
        {
            return new Circle(new Point(O.X + x, O.Y + y), Radius);
        }

        public Circle ChangeSize(double difference)
        {
            return new Circle(new Point(O.X, O.Y), Radius + difference);
        }

        public Circle GetCapsuleOfTwoShapes(Circle anotherCircle)
        {
            return new Circle(new Point((this.O.X + anotherCircle.O.X) / 2, (this.O.Y + anotherCircle.O.Y) / 2),
                Math.Max(this.Radius, anotherCircle.Radius) + Math.Sqrt(Math.Pow((this.O.X - anotherCircle.O.X), 2) + Math.Pow((this.O.X - anotherCircle.O.X), 2)));
        }

        public Circle GetIntersection(Circle anotherCircle)
        {
            double distance = Math.Sqrt(Math.Pow((this.O.X - anotherCircle.O.X), 2) + Math.Pow((this.O.X - anotherCircle.O.X), 2));

            if (distance + Math.Min(this.Radius, anotherCircle.Radius) <= Math.Max(this.Radius, anotherCircle.Radius))
            {
                if (this.Radius == Math.Min(this.Radius, anotherCircle.Radius))
                    return this;
                else
                    return anotherCircle;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return $"A = {O.ToString()}, Radius = {Radius.ToString()}";
        }
    }
}
