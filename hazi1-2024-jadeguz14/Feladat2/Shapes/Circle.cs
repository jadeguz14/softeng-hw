using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Circle : BaseShape
    {

        protected int r;

        public Circle(int x, int y, int r) : base(x, y)
        {
            this.r = r;
        }

        public override double GetArea()
        {
            return r * r * Math.PI;
        }

        public override string GetShapeType()
        {
            return "Circle";
        }

        public override string ToString()
        {
            return base.ToString() + $" radius={r}";
        }
    }
}
