using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shapes
{
    internal abstract class BaseShape : IShape
    {
        private int x;
        private int y;

        public BaseShape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public abstract double GetArea();

        public virtual string GetShapeType()
        {
            return "BaseShape";
        }

        public override string ToString()
        {
            return $"{GetShapeType()}: {GetX()}, {GetY()} area={GetArea()} ";
        }
    }
}
