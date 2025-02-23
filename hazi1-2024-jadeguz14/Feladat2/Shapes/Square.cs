using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Square : BaseShape
    {

        private double height;

        public Square(int x, int y, int height) : base(x, y)
        {
            this.height = height;
        }

        public override double GetArea()
        {
            return height * height;
        }

        public override string GetShapeType()
        {
            return "Square";
        }

        public override string ToString()
        {
            return base.ToString() + $"height={height}";
        }
    }
}
