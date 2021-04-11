using System;

namespace AIAS_Lab2
{
    public static class Qsort
    {
        private static int Partition<T>( T[] array, int startIndex, int endIndex, ref int operationsCount)
            where T : IComparable<T>
        {
            int i = startIndex;
            for (int j = startIndex; j <= endIndex; j++)         
            {
                if (array[j].CompareTo( array[endIndex]) <= 0) 
                {
                    T t = array[i];                
                    array[i] = array[j];                
                    array[j] = t;                    
                    i++;
                    operationsCount++; 
                }

                operationsCount++;
            }
            return i - 1;             
        }

        public static void QuickSort<T>( T[] array, int startIndex, int endIndex, ref int operationsCount) where T : IComparable<T>
        {
            if (startIndex >= endIndex) return;
            int separator = Partition( array, startIndex, endIndex, ref operationsCount);
            QuickSort( array, startIndex, separator - 1, ref operationsCount);
            QuickSort( array, separator + 1, endIndex, ref operationsCount);
        }

    }
}