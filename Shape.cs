using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    //Date = 8/31/2022.
    public abstract class Shape
    {
        public Shape()
        {
            UoM = "inches";
        }
        public Shape(string uom)
        {
            UoM = uom;
        }
        public string UoM { get; set; }
        public abstract double Area { get; }
        public abstract double Perimeter { get; }
    }
    public class Rectangle : Shape
    {
        public Rectangle(Double l, double w, string u): base(u)
        {
            Length = l;
            Width = w;

        }
        public Rectangle(Double length, Double width): base()
        {
            Length = length;
            Width = width;
        }
        public Rectangle():this(1,1)
        {
            
        }
        
        public double Length { get; set; }
        public double Width { get; set; }
        public override double Area
        {
            get { return Length * Width; }
        }
        public override double Perimeter
        {
            get { return (Length + Width) * 2; }
        }
    }
    public class Square : Shape
    {
        public Square(Double length): base()
        {
            Length = length;
        }
        public Square():this(1)
        {
        }
        public double Length { get; set; }
        public override double Area
        {
            get { return Length * Length; }
        }
        public override double Perimeter
        {
            get { return Length * 4; }
        }
    }
    public class Circle : Shape
    {
        public Circle(double radius): base()
        {
            Radius = radius;
        }
        public Circle():this(1)
        {
        }
        public double Radius { get; set; }
        public override double Area
        {
            get { return Math.PI * Radius * Radius; }
        }
        public override double Perimeter
        {
            get { return 2 * Math.PI * Radius; }
        }
    }
}
