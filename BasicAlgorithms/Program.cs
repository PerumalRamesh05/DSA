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
            if (args != null && args.Length > 0 && args[0] == "scoreboard")
                RunScoreBoardTest();
        }

        private static void RunScoreBoardTest()
        {
            ScoreBoard sb = new ScoreBoard(6);
            sb.add(new GameEntry { Name = "A", Score = 15 });
            sb.add(new GameEntry { Name = "B", Score = 9 });
            sb.add(new GameEntry { Name = "C", Score = 17 });
            sb.add(new GameEntry { Name = "D", Score = 3 });
            sb.add(new GameEntry { Name = "E", Score = 82 });
            sb.add(new GameEntry { Name = "F", Score = 22 });
            sb.add(new GameEntry { Name = "G", Score = 45 });

            Console.WriteLine("Final List of GameEntries...");
            foreach (var item in sb.ToGameEntryArray())
            {
                Console.WriteLine("Name :" + item.Name + " , " + "Score :" + item.Score);
            }

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
