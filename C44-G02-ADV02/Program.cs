using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C44_G02_ADV02
{
    #region Question 1: Given an array consists of numbers with size N and number of queries
    public static class ArrayQueries
    {
        public static int CountGreaterThan(int[] numbers, int x)
        {
            int count = 0;
            foreach (int number in numbers)
            {
                if (number > x)
                {
                    count++;
                }
            }
            return count;
        }

        // Alternative modern approach using LINQ
        public static int CountGreaterThanLinq(int[] numbers, int x)
        {
            return numbers.Count(n => n > x);
        }
    }
    #endregion

    #region Question 2: Given a number N and an array of N numbers. Determine if it's palindrome or not.
    public static class PalindromeChecker
    {
        public static bool IsPalindrome(int[] numbers)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right)
            {
                if (numbers[left] != numbers[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
    }
    #endregion

    #region Question 3: Given a Queue, implement a function to reverse the elements of a queue using a stack.
    public static class QueueReverser
    {
        public static void Reverse<T>(Queue<T> queue)
        {
            Stack<T> stack = new Stack<T>();
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
        }
    }
    #endregion

    #region Question 4: Given a Stack, implement a function to check if a string of parentheses is balanced using a stack.
    public static class ParenthesesBalancer
    {
        public static bool IsBalanced(string expression)
        {
            var bracketPairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' }
            };

            var stack = new Stack<char>();

            foreach (char c in expression)
            {
                if (bracketPairs.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else if (bracketPairs.ContainsValue(c))
                {
                    if (stack.Count == 0 || bracketPairs[stack.Pop()] != c)
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
    }
    #endregion

    #region Question 5: Given an array, implement a function to remove duplicate elements from an array.
    public static class ArrayDuplicateRemover
    {
        public static T[] RemoveDuplicates<T>(T[] array)
        {
            return array.Distinct().ToArray();
        }
    }
    #endregion

    #region Question 6: Given an array list, implement a function to remove all odd numbers from it.
    public static class ArrayListOddRemover
    {
        public static void RemoveOddNumbers(ArrayList list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] is int number && number % 2 != 0)
                {
                    list.RemoveAt(i);
                }
            }
        }
    }
    #endregion

    #region Question 8: Create a function that pushes a series of integers onto a stack.
    public static class StackSearcher
    {
        public static string SearchForTarget(Stack<int> stack, int target)
        {
            var tempStack = new Stack<int>();
            int count = 0;
            bool found = false;

            while (stack.Count > 0)
            {
                int item = stack.Pop();
                tempStack.Push(item);
                count++;
                if (item == target)
                {
                    found = true;
                    break;
                }
            }

            // Restore the original stack
            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            if (found)
            {
                return $"Target was found successfully and the count = {count}";
            }
            else
            {
                return "Target was not found";
            }
        }
    }
    #endregion

    #region Question 9: Given two arrays, find their intersection. 
    public static class ArrayIntersection
    {
        public static int[] FindIntersection(int[] arr1, int[] arr2)
        {
            var frequencyMap = new Dictionary<int, int>();
            foreach (var num in arr1)
            {
                if (frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num]++;
                }
                else
                {
                    frequencyMap[num] = 1;
                }
            }

            var intersection = new List<int>();
            foreach (var num in arr2)
            {
                if (frequencyMap.ContainsKey(num) && frequencyMap[num] > 0)
                {
                    intersection.Add(num);
                    frequencyMap[num]--;
                }
            }
            return intersection.ToArray();
        }
    }
    #endregion

    #region Question 10: Given an ArrayList of integers and a target sum, find if there is a contiguous sub list that sums up to the target.
    public static class ContiguousSublistSum
    {
        // Using List<int> for type safety is a modern C# best practice over ArrayList
        public static List<int> FindSublist(List<int> numbers, int targetSum)
        {
            int currentSum = 0;
            int start = 0;
            for (int end = 0; end < numbers.Count; end++)
            {
                currentSum += numbers[end];

                while (currentSum > targetSum && start <= end)
                {
                    currentSum -= numbers[start];
                    start++;
                }

                if (currentSum == targetSum)
                {
                    return numbers.GetRange(start, end - start + 1);
                }
            }
            return new List<int>(); // Return empty list if not found
        }
    }
    #endregion

    #region Question 11: Given a queue reverse first K elements of a queue, keeping the remaining elements in the same order
    public static class QueuePartialReverser
    {
        public static void ReverseFirstK<T>(Queue<T> queue, int k)
        {
            if (queue == null || k <= 0 || k > queue.Count)
            {
                return; // Invalid input, do nothing
            }

            Stack<T> stack = new Stack<T>();

            // 1. Dequeue first k elements and push to stack
            for (int i = 0; i < k; i++)
            {
                stack.Push(queue.Dequeue());
            }

            // 2. Enqueue elements from stack back to queue
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            // 3. Move the remaining (Count - k) elements to the back
            int remaining = queue.Count - k;
            for (int i = 0; i < remaining; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question 1
            /*
            Console.WriteLine("--- Question 1: Count Numbers Greater Than X ---");
            int[] numbersQ1 = { 11, 5, 3 };
            int[] queries = { 1, 5, 13 };
            for (int i = 0; i < queries.Length; i++)
            {
                int result = ArrayQueries.CountGreaterThanLinq(numbersQ1, queries[i]);
                Console.WriteLine($"Query 0{i + 1} ({queries[i]}): {result}");
            }
            Console.WriteLine("\n-------------------------------------------------\n");
            */
            #endregion

            #region Question 2
            /*
            Console.WriteLine("--- Question 2: Palindrome Array ---");
            int[] numbersQ2 = { 1, 3, 2, 3, 1 };
            bool isPalindrome = PalindromeChecker.IsPalindrome(numbersQ2);
            Console.WriteLine($"Array [{string.Join(", ", numbersQ2)}] is palindrome: {(isPalindrome ? "YES" : "NO")}");
            Console.WriteLine("\n-------------------------------------------------\n");
            */
            #endregion

            #region Question 3
            /*
            Console.WriteLine("--- Question 3: Reverse Queue using Stack ---");
            var queueQ3 = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Original Queue: {string.Join(", ", queueQ3)}");
            QueueReverser.Reverse(queueQ3);
            Console.WriteLine($"Reversed Queue: {string.Join(", ", queueQ3)}");
            Console.WriteLine("\n-------------------------------------------------\n");
            */
            #endregion

            #region Question 4
            /*
            Console.WriteLine("--- Question 4: Balanced Parentheses ---");
            string expression = "[()]{}";
            bool isBalanced = ParenthesesBalancer.IsBalanced(expression);
            Console.WriteLine($"Expression '{expression}' is: {(isBalanced ? "Balanced" : "Not Balanced")}");
            Console.WriteLine("\n-------------------------------------------------\n");
            */
            #endregion

            #region Question 5
            /*
            Console.WriteLine("--- Question 5: Remove Duplicates from Array ---");
            int[] numbersQ5 = { 1, 2, 2, 3, 4, 4, 5, 1 };
            Console.WriteLine($"Original Array: {string.Join(", ", numbersQ5)}");
            int[] uniqueNumbers = ArrayDuplicateRemover.RemoveDuplicates(numbersQ5);
            Console.WriteLine($"Array with Duplicates Removed: {string.Join(", ", uniqueNumbers)}");
            Console.WriteLine("\n-------------------------------------------------\n");
            */
            #endregion

            #region Question 6
            /*
            Console.WriteLine("--- Question 6: Remove Odd Numbers from ArrayList ---");
            ArrayList arrayListQ6 = new ArrayList { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine($"Original ArrayList: {string.Join(", ", arrayListQ6.ToArray())}");
            ArrayListOddRemover.RemoveOddNumbers(arrayListQ6);
            Console.WriteLine($"ArrayList with Odds Removed: {string.Join(", ", arrayListQ6.ToArray())}");
            Console.WriteLine("\n-------------------------------------------------\n");
            */
            #endregion

            #region Question 7
            /*
            Console.WriteLine("--- Question 7: Queue with Different Data Types ---");
            Queue queueQ7 = new Queue();
            queueQ7.Enqueue(1);
            queueQ7.Enqueue("Apple");
            queueQ7.Enqueue(5.28);
            Console.WriteLine("Contents of the multi-type queue:");
            foreach (var item in queueQ7)
            {
                Console.WriteLine($"- {item} (Type: {item.GetType().Name})");
            }
            Console.WriteLine("\n-------------------------------------------------\n");
            */
            #endregion Question 7

            #region Question 8
            /*
            Console.WriteLine("--- Question 8: Search in Stack ---");
            var stackQ8 = new Stack<int>(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine("Stack contains: 10, 20, 30, 40, 50");
            Console.Write("Enter target integer to search for: ");
            int target = Convert.ToInt32(Console.ReadLine());
            string searchResult = StackSearcher.SearchForTarget(stackQ8, target);
            Console.WriteLine(searchResult);
            Console.WriteLine("\n-------------------------------------------------\n");
            */
            #endregion

            #region Question 9
            /*
            Console.WriteLine("--- Question 9: Array Intersection ---");
            int[] arr1 = { 1, 2, 3, 4, 4 };
            int[] arr2 = { 10, 4, 4 };
            int[] intersection = ArrayIntersection.FindIntersection(arr1, arr2);
            Console.WriteLine($"Array 01: [{string.Join(",", arr1)}]");
            Console.WriteLine($"Array 02: [{string.Join(",", arr2)}]");
            Console.WriteLine($"Intersection: [{string.Join(",", intersection)}]");
            Console.WriteLine("\n-------------------------------------------------\n");
            */
            #endregion

            #region Question 10
            /*
            Console.WriteLine("--- Question 10: Contiguous Sublist Sum ---");
            var listQ10 = new List<int> { 1, 2, 3, 7, 5 };
            int targetSum = 12;
            Console.WriteLine($"ArrayList: [{string.Join(", ", listQ10)}]");
            Console.WriteLine($"Target Sum: {targetSum}");
            List<int> sublist = ContiguousSublistSum.FindSublist(listQ10, targetSum);
            if (sublist.Count > 0)
            {
                Console.WriteLine($"Contiguous sub list: [{string.Join(", ", sublist)}]");
            }
            else
            {
                Console.WriteLine("No contiguous sub list found.");
            }
            Console.WriteLine("\n-------------------------------------------------\n");
            */
            #endregion

            #region Question 11
            /*
            Console.WriteLine("--- Question 11: Reverse First K Elements of a Queue ---");
            var queueQ11 = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            int k = 3;
            Console.WriteLine($"Original Queue: [{string.Join(",", queueQ11)}], K = {k}");
            QueuePartialReverser.ReverseFirstK(queueQ11, k);
            Console.WriteLine($"Result: [{string.Join(",", queueQ11)}]");
            Console.WriteLine("\n-------------------------------------------------\n");
            */
            #endregion
        }
    }
}