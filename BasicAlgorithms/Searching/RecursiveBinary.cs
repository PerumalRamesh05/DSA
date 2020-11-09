// This is a close relative of merge sort algorithm where we recursively sort first before merge .
public class RecursiveBinary
{
    int[] numbers = new int[] { 2, 7, 11, 24, 35, 46, 59, 72, 89, 90, 95, 98, 99 }; //For BinarySearch to work the collection needs to be sorted that is a pre-req.

    public int DoSearch(int targetValue, int? lowerBound = null, int? upperBound = null)
    {
        if (lowerBound == null) lowerBound = 0;
        if (upperBound == null) upperBound = numbers.Length;

        System.Console.WriteLine("lower :" + lowerBound.ToString() + " , " + "upper :" + upperBound.ToString());
        int mid;
        if (lowerBound > upperBound)
            return -1;

        mid = (int)(lowerBound + upperBound) / 2;
        if (targetValue == numbers[mid]) return mid;

        if (targetValue < numbers[mid])
            return DoSearch(targetValue, lowerBound, (mid - 1));

        if (targetValue > numbers[mid])
            return DoSearch(targetValue, (mid + 1), upperBound);

        return -1;
    }

}
