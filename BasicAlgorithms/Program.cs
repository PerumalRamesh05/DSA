using System;
using System.Collections.Generic;

namespace BasicAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0 && args[0] == "basic")
                RunBasicAlgorithmTest();
            if (args != null && args.Length > 0 && args[0] == "sort")
                RunSortTest();
            if (args != null && args.Length > 0 && args[0] == "binarySearch")
                RunSearchTest();
        }

        private static void RunSearchTest()
        {
            RecursiveBinary rb = new RecursiveBinary();
            Console.WriteLine("Final Result :" + rb.DoSearch(99).ToString());
        }

        private static void RunSortTest()
        {
            ISort bs = new SelectionSort();   // new BubbleSort();  //Uncomment and switch the objects if you want to run the other one.
            bs.DoSort();
        }

        public static void RunBasicAlgorithmTest()
        {
            List<Student> Students = new List<Student> { new Student { Name = "A", Number = 10 }, new Student { Name = "B", Number = 20 }, new Student { Name = "C", Number = 30 } };
            TestManager testManager = new TestManager(Students);

            testManager.GetStudentsFromDesk();

            Student student = testManager.GetStudentByName("A");
            Console.WriteLine("This is Student Object (A) - " + student.ToString());

        }


    }
}
