
using static System.Console;

namespace Shapes
{
    public static class TestShapes
    {
        public static void Test()
        {

            var circle = new Circle(3);
            ShowShape(circle);
            var rectangle = new Rectangle(20, 25);
            ShowShape(rectangle);
            var square = new Square(18);
            ShowShape(square);
            square.Length = 55;
            ShowShape(square);
            rectangle = new Rectangle();
            ShowShape(rectangle);

            var rec1 = new Rectangle(5, 6, "cm");
            ShowShape(rec1);

            double length, width;
            string uom;

            WriteLine("Please enter length: ");
            length = System.Convert.ToDouble(ReadLine());

            WriteLine("Please enter width: ");
            width = System.Convert.ToDouble(ReadLine());

            WriteLine("Please enter Unit of Measure: ");
            uom = ReadLine();

            var rec2 = new Rectangle(length, width, uom);
            ShowShape(rec2);


        }

        static void ShowShape(Shape shape)
        {
            WriteLine($"{shape.GetType().Name}\tArea = {shape.Area}\t\tPerimeter = {shape.Perimeter}\t\tUom = {shape.UoM}");
        }

    }
}