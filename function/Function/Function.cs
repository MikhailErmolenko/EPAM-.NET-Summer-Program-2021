using System;

namespace Function
{
    public enum SortOrder { Ascending, Descending }
    public static class Function
    {
        public static bool IsSorted (int []array, SortOrder order)
		{
            bool isSorted = true;
            for(int i=0;i<array.Length-1;i++)
			{
                isSorted = isSorted && (order==SortOrder.Ascending? array[i]<=array[i+1]: array[i]>=array[i+1]);
			}
            return isSorted;
		}

       public static void Transform (int []array, SortOrder order)
		{
            if (IsSorted(array, order))
            {
                for (int i=0; i <array.Length; i++)
				{
                    array[i] += i;
				}
            }
		}

        public static double  MultArithmeticElements(double a, double t, int n)
		{
            double result = a;
            for (int i = 0; i<n-1; i++)
			{
                a += t;
                result *= a;
			}
            return result;
		}

        public static double SumGeometricElements (double a, double t, double alim)
		{
            double result = 0;
            for (double i=a; i >= alim; i*=t)
			{
                result += i;
			}
            return result;
		}
    }
}
