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

___Microsoft's explanation of its Generic data structures - [link](https://docs.microsoft.com/en-us/dotnet/standard/collections/)__

![](https://github.com/anandr781/DSA/blob/master/C%23_Collections.png)

## Sorting Algorithms Time complexities in C

![](https://github.com/anandr781/DSA/blob/master/Sorting%20Algorithm_TimeComplexity.png)


=============================================================================

## Time Complexity 

What is Time Complexity?
Time complexity of an algorithm signifies the total time required by the program to run till its completion.

The time complexity of algorithms is most commonly expressed using the big O notation. It's an asymptotic notation to represent the time complexity. We will study about it in detail in the next tutorial.

Time Complexity is most commonly estimated by counting the number of elementary steps performed by any algorithm to finish execution. Like in the example above, for the first code the loop will run n number of times, so the time complexity will be n atleast and as the value of n will increase the time taken will also increase. While for the second code, time complexity is constant, because it will never be dependent on the value of n, it will always give the result in 1 step.

And since the algorithm's performance may vary with different types of input data, hence for an algorithm we usually use the worst-case Time complexity of an algorithm because that is the maximum time taken for any input size.

Calculating Time Complexity
Now lets tap onto the next big topic related to Time complexity, which is How to Calculate Time Complexity. It becomes very confusing some times, but we will try to explain it in the simplest way.

Now the most common metric for calculating time complexity is Big O notation. This removes all constant factors so that the running time can be estimated in relation to N, as N approaches infinity. In general you can think of it like this :

statement;
Above we have a single statement. Its Time Complexity will be Constant. The running time of the statement will not change in relation to N.

```java
for(i=0; i < N; i++)
{
    statement;
}
```
The time complexity for the above algorithm will be __Linear__. The running time of the loop is directly proportional to N. When N doubles, so does the running time.

```java
for(i=0; i < N; i++) 
{
    for(j=0; j < N;j++)
    { 
    statement;
    }
}
```
This time, the time complexity for the above code will be __Quadratic__. The running time of the two loops is proportional to the square of N. When N doubles, the running time increases by N * N.

```java
while(low <= high) 
{
    mid = (low + high) / 2;
    if (target < list[mid])
        high = mid - 1;
    else if (target > list[mid])
        low = mid + 1;
    else break;
}
```
This is an algorithm to break a set of numbers into halves, to search a particular field(we will study this in detail later). Now, this __algorithm will have a Logarithmic Time Complexity__ . The running time of the algorithm is proportional to the number of times N can be divided by 2(N is high-low here). This is because the algorithm divides the working area in half with each iteration.

```java
void quicksort(int list[], int left, int right)
{
    int pivot = partition(list, left, right);
    quicksort(list, left, pivot - 1);
    quicksort(list, pivot + 1, right);
}

``` 
__Taking the previous algorithm forward, above we have a small logic of Quick Sort(we will study this in detail later). Now in Quick Sort, we divide the list into halves every time, but we repeat the iteration N times(where N is the size of list). Hence time complexity will be N*log( N ). The running time consists of N loops (iterative or recursive) that are logarithmic, thus the algorithm is a combination of linear and logarithmic.__

##NOTE**: In general, doing something with every item in __one dimension is linear__, doing something with every item in __two dimensions is quadratic__, and __dividing the working area in half is logarithmic__.
