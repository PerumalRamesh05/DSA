
//SequentialSearch is the simplest form of search - The most obvious type of search is to begin at the beginning of a set of records and move through each record until you 
//find the record you are looking for or you come to the end of the records. This is called a sequential search.
// This is also known as "Linear Search"
//
public class Sequential
{

    int[] numbers = new int[] { 72, 54, 59, 30, 31, 78, 2, 77, 82, 72 };

    public bool SimpleSequential(int targetValue)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if(numbers[i]==targetValue)
             return true;
        }
        return false;
    }

}