using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stylecop
{
    class Rectangle: IShaper<Rectangle>
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }

        public Rectangle() { }
        public Rectangle(Point a, Point c)
        {
            A = a;
            C = c;
            B = new Point(a.X, c.Y);
            D = new Point(c.X, a.Y);
        }

        public Rectangle Move(double x, double y)
        {
            return new Rectangle(new Point(A.X + x, A.Y + y), new Point(C.X + x, C.Y + y));
        }

        public Rectangle ChangeSize(double difference)
        {
            return new Rectangle(new Point(A.X, A.Y), new Point(C.X + difference, C.Y + difference));
        }

        public Rectangle GetCapsuleOfTwoShapes(Rectangle anotherRectangle)
        {
            return new Rectangle(new Point(Math.Min(this.A.X, anotherRectangle.A.X), Math.Min(this.A.Y, anotherRectangle.A.Y)), 
                new Point(Math.Max(this.C.X, anotherRectangle.C.X), Math.Max(this.C.Y, anotherRectangle.C.Y)));
        }

        public Rectangle GetIntersection(Rectangle anotherRectangle)
        {
            double newRectangleAX = Math.Max(this.A.X, anotherRectangle.A.X);
            double newRectangleAY = Math.Max(this.A.Y, anotherRectangle.A.Y);

            double newRectangleCX = Math.Min(this.C.X, anotherRectangle.C.X);
            double newRectangleCY = Math.Min(this.C.Y, anotherRectangle.C.Y);

            if (newRectangleAX > newRectangleCX || newRectangleAY > newRectangleCY)
            {
                throw new ArgumentException();
            }

            return new Rectangle(new Point(newRectangleAX, newRectangleAY), new Point(newRectangleCX, newRectangleCY));
        }

        public override string ToString()
        {
            return $"A = {A.ToString()}, B = {B.ToString()}, C = {C.ToString()}, D = {D.ToString()}";
        }
    }
}
