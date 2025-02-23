using Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class TextArea : Textbox, IShape
    {
        protected int height;
        protected int width;

        public TextArea(int x, int y, int height, int width) : base(x, y, height, width) { }

        public double GetArea()
        {
            return height * width;
        }
        public string GetShapeType()
        {
            return "TextArea";
        }

        public override string ToString()
        {
            return $"{GetShapeType()} {GetX()}, {GetY()} area={GetArea()} height={GetHeight()} width={GetWidth()} text='{GetText()}'";
        }
    }
}
