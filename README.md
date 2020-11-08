# DataStructures_Algorithms

A Deep-dive into data structures and algorithms in C# and Java

## Asymptotic Analysis

This is a method of describing limiting behaviour.

As an illustration, suppose that we are interested in the properties of a function f(n) as n becomes very large. Hence , if f(n) = n^2 + 3n then as 'n' becomes very large, then 3n becomes insignificant and you can state that f(n) asymptotically equivalent to n^2 (other words ignore the constant). Otherwise represented as f(n) ~ n^2 .

Also, in Asymptotic analysis, we always talk about input sizes larger than a constant value. It might be possible that those large inputs are never given to your software and an algorithm which is asymptotically slower, always performs better for your particular situation. So, you may end up choosing an algorithm that is Asymptotically slower but faster for your software.

## Analysis of Loops

1. **O(1)**: Time complexity of a function (or set of statements) is considered as O(1) if it doesn’t contain loop, recursion and call to any other non-constant time function.

```java
 // Here c is a constant
  for (int i = 1; i <= c; i++) {
       // some O(1) expressions
  }
```

2. **O(n)**: Time Complexity of a loop is considered as O(n) if the loop variables is incremented / decremented by a constant amount. For example following functions have O(n) time complexity.

```java
// Here c is a positive integer constant
   for (int i = 1; i <= n; i += c) {
        // some O(1) expressions
   }

   for (int i = n; i > 0; i -= c) {
        // some O(1) expressions
   }
```

3. **O(n^c)**: Time complexity of nested loops is equal to the number of times the innermost statement is executed. For example the following sample loops have O(n^2) time complexity.
   For example Selection sort and Insertion Sort have O(n^2) time complexity.

```java
   for (int i = 1; i <=n; i += c) {
       for (int j = 1; j <=n; j += c) {
          // some O(1) expressions
       }
   }

   for (int i = n; i > 0; i -= c) {
       for (int j = i+1; j <=n; j += c) {
          // some O(1) expressions
   }
```

4. **O(Logn)** Time Complexity of a loop is considered as O(Logn) if the loop variables is divided / multiplied by a constant amount.
   For example Binary Search has O(Logn) time complexity. Let us see mathematically how it is O(Log n). The series that we get in first loop is 1, c, c2, c3, … ck. If we put k equals to Logcn, we get cLogcn which is n.

```java
   for (int i = 1; i <=n; i *= c) {
       // some O(1) expressions
   }
   for (int i = n; i > 0; i /= c) {
       // some O(1) expressions
   }
```

5. **O(LogLogn)** Time Complexity of a loop is considered as O(LogLogn) if the loop variables is reduced / increased exponentially by a constant amount.

```java
// Here c is a constant greater than 1
   for (int i = 2; i <=n; i = pow(i, c)) {
       // some O(1) expressions
   }
   //Here fun is sqrt or cuberoot or any other constant root
   for (int i = n; i > 1; i = fun(i)) {
       // some O(1) expressions
   }
```

How to combine time complexities of consecutive loops?
When there are consecutive loops, we calculate time complexity as sum of time complexities of individual loops.

```java
   for (int i = 1; i <=m; i += c) {
        // some O(1) expressions
   }
   for (int i = 1; i <=n; i += c) {
        // some O(1) expressions
   }
   Time complexity of above code is O(m) + O(n) which is O(m+n)
   If m == n, the time complexity becomes O(2n) which is O(n), since constants are ignored.
```

## C# Runtime Complexity of .NET Generic Collection

Deciding whether to implement the data structures myself or using the build-in classes turned out to be a hard decision, as the runtime complexity information is located at the method itself, if present at all. So I went ahead to consolidate all the information in one table, then looked at the source code in Reflector and verified them. Below is my result.

excerpt from [here](http://c-sharp-snippets.blogspot.com/2010/03/runtime-complexity-of-net-generic.html)

![](https://github.com/anandr781/DSA/blob/master/C%23_Collections.png)

## Sorting Algorithms Time complexities in C

This is a must [read](https://docs.microsoft.com/en-us/dotnet/standard/collections/)
![](https://github.com/anandr781/DSA/blob/master/Sorting%20Algorithm_TimeComplexity.png)
