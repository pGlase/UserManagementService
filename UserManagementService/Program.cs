using System;
using System.Collections.Generic;

namespace UserManagementService
{
    class Program
    {
        /*
        static void PrintArray(List<int> toSort)
        {
            foreach(int x in toSort){
                Console.Write("{0},",x);
            }
            Console.WriteLine();
        }

        static void InsertionSort(ref List<int> toSort)
        {
            int elementCount = toSort.Count - 1;
            for (int i = 0; i < elementCount; i++)
            {
                int maxPos = 0;
                for (int j = 0; j < (toSort.Count - i); j++)
                {
                    if (toSort[j] > toSort[maxPos])
                    {
                        maxPos = j;
                    }
                }
                int holder = toSort[elementCount - i];
                toSort[elementCount - i] = toSort[maxPos];
                toSort[maxPos] = holder;
                PrintArray(toSort);
            }
        }

        static List<int> MergeSort(List<int> toSort)
        {
            if(toSort.Count <= 1)
            {
                return toSort;
            }
            List<int> lower = new List<int>();
            List<int> upper = new List<int>();
            decimal x = toSort.Count;
            
            int pivot = (int)Math.Floor(x / 2);
            int pivotSize = toSort.Count - pivot;
            if (toSort[0] < toSort[pivot])
            {
                lower.AddRange(toSort.GetRange(0, pivot));
                upper.AddRange(toSort.GetRange(pivot, pivotSize));
            }
            else
            {
                upper.AddRange(toSort.GetRange(0, pivot));
                lower.AddRange(toSort.GetRange(pivot, pivotSize));
            }
            lower = MergeSort(lower);
            upper = MergeSort(upper);
            return Merge(lower, upper);
        }

        static List<int> Merge(List<int> A,List<int> B)
        {
            List<int> result = new List<int>();
            while(A.Count > 0 && B.Count > 0)
            {
                if(A[0] <= B[0])
                {
                    result.Add(A[0]);
                    A.RemoveAt(0);
                }
                else
                {
                    result.Add(B[0]);
                    B.RemoveAt(0);
                }
            }
            result.AddRange(A);
            result.AddRange(B);
            return result;
        }
        */
        static void Main(string[] args)
        {
            /*
            List<int> toSort = new List<int> { 1, 5, 3, 7, 9, 10, 2,11 };
            PrintArray(toSort);
            List<int> res = MergeSort(toSort);
            PrintArray(res);
            */
        }
    }
}