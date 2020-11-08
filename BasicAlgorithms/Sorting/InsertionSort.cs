using System;

public class InsertionSort : ISort
{
    public void DoSort()
    {
        int[] array = { 4, 3, 2, 10, 12, 1, 5, 6 };

        int temp, j;

        for (int i = 1; i < array.Length; i++)
        {
            temp = array[i];
            j = i - 1;

            /** Move the value by one position if its greater than the current key 'temp **/
            while (j >= 0 && array[j] > temp)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = temp;
        }

        Console.WriteLine("After Insertion sort :");
        ConsoleHelper.PrintArray(array);
    }
}