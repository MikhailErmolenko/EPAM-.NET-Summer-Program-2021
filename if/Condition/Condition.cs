using System;

namespace Condition
{
    public static class Condition
    {
        /// <summary>
        /// Implement code according to description of  task 1
        /// </summary>        
        public static int Task1(int n)
        {
            if (n >= 0)
                if (n == 0)
                    return 0;
                else
                    return Convert.ToInt32(Math.Pow(n, 2));
            else
                return Math.Abs(n);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Implement code according to description of  task 2
        /// </summary>  
        public static int Task2(int n)
        {
            int firstDigit = n / 100;
            int secondDigit = (n/10)-10*firstDigit;
            int thirdDigit = n % 10;

            int numberOfMaxDigit = 1;
            int f1 = firstDigit;
            if(f1<secondDigit)
			{
                f1 = secondDigit;
                numberOfMaxDigit = 2;
                if(f1<thirdDigit)
				{
                    f1 = thirdDigit;
                    numberOfMaxDigit = 3;
				}
			}

            int f2 = 0;
            int f3 = 0;
            if(numberOfMaxDigit == 1)
			{
                f2 = Math.Max(secondDigit, thirdDigit);
                f3 = Math.Min(secondDigit, thirdDigit);
			}

            if (numberOfMaxDigit == 2)
            {
                f2 = Math.Max(firstDigit, thirdDigit);
                f3 = Math.Min(firstDigit, thirdDigit);
            }

            if (numberOfMaxDigit == 3)
            {
                f2 = Math.Max(firstDigit, secondDigit);
                f3 = Math.Min(firstDigit, secondDigit);
            }

            return f1 * 100 + f2 * 10 + f3;

            throw new NotImplementedException();
        }
    }
}
