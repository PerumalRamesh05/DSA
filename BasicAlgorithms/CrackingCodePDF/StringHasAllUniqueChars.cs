using System;
using System.Text;
using System.Collections.Generic;

public class StringHasAllUniqueChars 
{
    public bool doesStringAllUniqueCharacters(String s)
    {
        HashSet<char> hashSet = new HashSet<char>(); 
        StringBuilder sb = new StringBuilder(s);
        for (int i = 0; i < sb.Length; i++)
        {
           if(hashSet.Contains(sb[i]))
            return false;
           hashSet.Add(sb[i]);
        }
        return true;   
    }
}