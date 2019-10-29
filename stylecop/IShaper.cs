using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stylecop
{
    interface IShaper<T> where T: class
    {
        T Move(double x, double y);

        T ChangeSize(double difference);

        T GetCapsuleOfTwoShapes(T anotherRectangle);

        T GetIntersection(T anotherRectangle);
    }
}
