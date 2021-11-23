using System;
using System.Collections.Generic;
using System.Linq;

namespace Class
{
    public class Rectangle
	{
        private double sideA;
        private double sideB;

        public Rectangle(double a, double b)
		{
            sideA = a;
            sideB = b;
		}
        public Rectangle(double a) : this(a, 5) { }
        public Rectangle()
		{
            sideA = 4;
            sideB = 3;
		}

        public double GetSideA()
		{
            return sideA;
		}
        public double GetSideB()
		{
            return sideB;
		}
        public double Area()
		{
            return sideA*sideB;
		}
        public double Perimeter()
		{
            return (sideA+sideB)*2;
		}
        public bool IsSquare()
		{
            if (sideA == sideB)
                return true;
            else return false;
		}
        public void ReplaceSides()
		{
            (sideA, sideB) = (sideB, sideA);
		}
	}

    public class ArrayRectangles
	{
        private Rectangle[] rectangle_array;

        public ArrayRectangles(int n)
		{
            rectangle_array = new Rectangle[n];
		}
        public ArrayRectangles(IEnumerable<Rectangle> rectangles)
        {
            rectangle_array = new Rectangle[rectangles.Count()];
            int i = 0;
            foreach (var rectangle in rectangles)
			{
                rectangle_array[i] = rectangle;
                i++;
			}
        }

        public bool AddRectangle(Rectangle rectangle)
		{
            bool result=false;
            for (int i=0; i<rectangle_array.Length; i++)
			{
                if (rectangle_array[i] == null)
                {
                    rectangle_array[i] = rectangle;
                    result = true;
                    break;
                }
			}
            return result;
		}
        public int NumberMaxArea()
		{
            int numberOfRectangle = 0;
            for (int i=1; i<rectangle_array.Length; i++)
			{
                if (rectangle_array[i].Area() > rectangle_array[numberOfRectangle].Area())
				numberOfRectangle = i;
			}
            return numberOfRectangle;
		}
        public int NumberMinPerimeter()
		{
            int numberOfRectangle = 0;
            for (int i=0; i<rectangle_array.Length; i++)
			{
                if (rectangle_array[i].Perimeter() < rectangle_array[numberOfRectangle].Area())
                    numberOfRectangle = i;
			}
            return numberOfRectangle;
		}
        public int NumberSquare()
		{
            int amountOfSquares = 0;
            for (int i=0; i<rectangle_array.Length; i++)
			{
                if (rectangle_array[i].GetSideA() == rectangle_array[i].GetSideB())
                    amountOfSquares++;
			}
            return amountOfSquares;
		}
    }
}
