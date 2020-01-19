//
// BubbleSort - Makes the lowest value float to the left and the highest value float to the right , Float here indicates number of iterations to complete
// As you can see it will be slowest of sorting algorithms and will be proportional to the BigO notation of O(n) slow to the total 
//
public class BubbleSort : ISort
{
    //    int[] numbers = new int[] { 45, 24, 17, 69, 12, 98, 2, 56 };  //12,17,24,45,69
    int[] numbers = new int[] { 72, 54, 59, 30, 31, 78, 2, 77, 82, 72 };

    public void DoSort()
    {
        int temp;
        int innerIterationCnt = 0, outerIterationCnt = 0;

        System.Console.WriteLine("Before Starting Sort");
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            innerIterationCnt++;
            for (int j = i - 1; j >= 0; j--)
            {
                ConsoleHelper.PrintArray(numbers);

                outerIterationCnt++;
                if (numbers[i] < numbers[j])
                {
                    temp = numbers[j];
                    numbers[j] = numbers[i];
                    numbers[i] = temp;
                }

            }
        }
        System.Console.WriteLine("After Sorting is complete....");
        ConsoleHelper.PrintArray(numbers);
        System.Console.WriteLine(innerIterationCnt.ToString() + " , " + outerIterationCnt.ToString() + " , " + numbers.Length.ToString());
    }



}