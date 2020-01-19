using System.Collections;

public static class ConsoleHelper
{
    public static void PrintArray<T>(T collection) where T : IEnumerable
    {
        //Just Printing the Array - Start

        foreach (var item in collection)
        {
            System.Console.Write(item + " , ");
        }
        System.Console.WriteLine();
        //Just Printing the Array - End
    }
}