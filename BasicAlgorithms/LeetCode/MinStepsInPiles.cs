using System;
/*
https://leetcode.com/discuss/interview-question/364618/Microsoft-or-OA-2019-or-Min-Steps-to-Make-Piles-Equal-Height
*/
class HelloWorld {
    static void Start() {
        Console.WriteLine(minimumSteps(new int[] {5,2,1}).ToString());
        Console.WriteLine(minimumSteps(new int[] {4,5,5,4,2}).ToString());
    }
    
    static int minimumSteps(int[] piles) 
    {
        if (piles ==null || piles.Length ==0)
            return 0;
        int count=1,total=0;
        
        Array.Sort(piles);
         
       for (int i=piles.Length-2; i>=0; i--) {
            if (piles[i] != piles[i+1]) {
                total += count;
            }
            count++;
        }
        return total;
        
    }
}