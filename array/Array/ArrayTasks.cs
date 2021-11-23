using System;

namespace ArrayObject
{
    public static class ArrayTasks
    {
        /// <summary>
        /// Task 1
        /// </summary>
        public static void ChangeElementsInArray(int[] nums)
        {
            for (int i = 0; i < nums.Length / 2; i++)
            {
                int oppositeElement = nums.Length - 1 - i;
                if ((nums[i] % 2 == 0) && (nums[oppositeElement] % 2 == 0))
                {
                    (nums[i], nums[oppositeElement]) = (nums[oppositeElement], nums[i]);
                }
            }
            return;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Task 2
        /// </summary>
        public static int DistanceBetweenFirstAndLastOccurrenceOfMaxValue(int[] nums)
        {
            int maxValue = int.MinValue;
            int index = 0;
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
			{
                if (nums[i] > maxValue)
                {
                    maxValue = nums[i];
                    index = i;
                }
            }
            
            for (int i = nums.Length-1; i >= index; i--)
			{
                if (nums[i] == maxValue)
				{
                    result = i - index;
                    break;
				}
			}
            return result;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Task 3 
        /// </summary>
        public static void ChangeMatrixDiagonally(int[,] matrix)
        {
            int sideLength = (int)Math.Sqrt(matrix.Length);
            for (int i = 0; i < sideLength; i++)
                for (int j = i+1; j < sideLength; j++)
                {
                    matrix[i, j] = 1;
                    matrix[j, i] = 0;
                }
            return;
            throw new NotImplementedException();
        }
    }
}
