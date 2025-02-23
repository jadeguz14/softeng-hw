using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Extensibility
{
    static class AllProgresses
    {
        public static void PercentReport(int count, int index)
        {
            int percentage = (int)((double)(index + 1) / count * 100);

            var pos = Console.GetCursorPosition();
            Console.SetCursorPosition(0, pos.Top);

            Console.Write($"Processing: {percentage} %");

            if (index == count - 1)
                Console.WriteLine();
        }

        public static void SimpleReport(int count, int index)
        {
            Console.WriteLine($"{index + 1}. person processed");
        }

    }
}
