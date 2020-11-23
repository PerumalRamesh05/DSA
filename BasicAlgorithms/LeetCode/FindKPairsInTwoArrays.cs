using System;
using System.Collections.Generic;
using NUnit.Framework;
class KSmallestPair
{
    public static IList<List<int>> kSmallestPair(int[] arr1, int n1,
                  int[] arr2, int n2, int k)
    {
        if (k > n1 * n2)
        {
            Console.Write("k pairs don't exist");
            return null;
        }

        IList<List<int>> results = new List<List<int>>();
        // Stores current index in arr2[] for
        // every element of arr1[]. Initially
        // all values are considered 0. Here
        // current index is the index before
        // which all elements are considered 
        // as part of output.
        int[] index2 = new int[n1];

        while (k > 0)
        {
            // Initialize current pair sum as infinite
            int min_sum = int.MaxValue;
            int min_index = 0;

            // To pick next pair, traverse for all 
            // elements of arr1[], for every element,  
            // find corresponding current element in 
            // arr2[] and pick minimum of all formed pairs.
            for (int i1 = 0; i1 < n1; i1++)
            {
                // Check if current element of arr1[] 
                // plus element of array2 to be used  
                // gives minimum sum
                if (index2[i1] < n2 && arr1[i1] +
                    arr2[index2[i1]] < min_sum)
                {
                    // Update index that gives minimum
                    min_index = i1;

                    // update minimum sum
                    min_sum = arr1[i1] + arr2[index2[i1]];
                }
            }

            results.Add(new List<int> { arr1[min_index],  arr2[index2[min_index]] });
            // Console.Write("(" + arr1[min_index] + ", " +
            // arr2[index2[min_index]] + ") ");

            index2[min_index]++;
            k--;
        }
        return results;
    }
}



[TestFixture]
public class ArrayTest
{
    [Test]
    public void Test1()
    {
        int[] arr1 = { 1, 7, 11 };
        int n1 = arr1.Length;

        int[] arr2 = { 2, 4, 8 };
        int n2 = arr2.Length;

        int k = 9;
        IList<List<int>> results = KSmallestPair.kSmallestPair(arr1, n1, arr2, n2, k);
        foreach (var item in results)
        {
            Console.WriteLine(item[0].ToString() + "," + item[1].ToString());
        }

    }


}

/*
    1 | 3 | 11
    2 | 4 | 8 

    1,2 --> By default
    1,4 -->
    3.2 -->
    3,4 --> 
*/