using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class ShapeInventory
    {
        private readonly List<IShape> shapes = new List<IShape>();

        public void Add(IShape shape)
        {
            shapes.Add(shape);
        }

        public void Remove(IShape shape)
        {
            shapes.Remove(shape);
        }

        public void Print()
        {
            foreach(IShape shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }
        }
    }
}
