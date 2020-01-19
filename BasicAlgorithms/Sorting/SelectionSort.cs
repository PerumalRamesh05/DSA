// SelectionSort - Is much better than BubbleSort which makes the values float (compare only with adjacent nodes) . Eventually perfoming more iterations
//  This sorting mechanism is much faster and selects the least element at any given iteration and hence the name. 

public class SelectionSort : ISort
{

    int[] numbers = new int[] { 72, 54, 59, 30, 31, 78, 2, 77, 82, 72 };


    public void DoSort()
    {
        int min, temp;
        for (int i = 0; i < numbers.Length; i++)
        {
            min = i; //start the iteration 

            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < numbers[min])
                {
                    temp = numbers[min];
                    numbers[min] = numbers[j];
                    numbers[j] = temp;
                }
            }

        }
        ConsoleHelper.PrintArray(numbers);
    }


}