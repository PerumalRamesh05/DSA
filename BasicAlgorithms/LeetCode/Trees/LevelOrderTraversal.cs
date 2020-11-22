/*
https://leetcode.com/explore/interview/card/linkedin/341/trees-and-graphs/1981/
Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

For example:
Given binary tree [3,9,20,null,null,15,7],
    3
   / \
  9  20
    /  \
   15   7
return its level order traversal as:
[
  [3],
  [9,20],
  [15,7]
]
*/
using System;
using System.Collections.Generic;

 public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }
 
public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> final = new List<IList<int>>();
        
        if(root!=null)
        {
            final.Add(new List<int> {root.val});
            
            List<int> results=new List<int>();
             
            if(root.left !=null)
              results.Add(root.left.val);
             
            if(root.right !=null)
                results.Add(root.right.val);
            
            final.Add(results);
          
            
            if (root.left !=null)
            {
              results=  GetLevel(root.left);
              if(results.Count>0)
              final.Add(results);
            }
            
            if(root.right !=null)
            {
                results = GetLevel(root.right);
                if(results.Count>0)
                final.Add(results);
                
            }

        }  
                 
        return final;
    }
    
    private List<int> GetLevel(TreeNode root) 
    {
         List<int> level = new List<int>();
         if(root.left !=null)
         {
           level.AddRange(new int[] {root.left.val});
           GetLevel(root.left);
         }
         if(root.right !=null) 
         {
             level.AddRange(new int[] {root.right.val});
             GetLevel(root.right);
         }
          
         return level;
    }
    
}