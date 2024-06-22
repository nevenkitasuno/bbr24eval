using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmsDataStructures
{
    public static class RecursionFunctions
    {
        // Ex1
        public static int Pow(int number, int power)
        {
            if (power == 0) return 1;
            return number * Pow(number, power - 1);
        }

        // Ex2
        public static int SumOfDigits(int number)
        {
            if (number == 0) return 0;
            return number % 10 + SumOfDigits(number / 10);
        }

        // Ex4
        public static bool IsPalindrome(string str) => InternalIsPalindrome(str, 0);
        public static bool InternalIsPalindrome(string str, int index)
        {
            if (index == str.Length / 2) return true;
            if (str[index] != str[str.Length - index - 1]) return false;
            return InternalIsPalindrome(str, index + 1);
        }

        // Ex5
        public static void PrintEven(List<int> numbers) => InternalPrintEven(numbers, 0);
        private static void InternalPrintEven(List<int> numbers, int index)
        {
            if (index == numbers.Count) return;
            if (numbers[index] % 2 == 0) Console.Write(numbers[index] + " ");
            InternalPrintEven(numbers, index + 1);
        }

        // Ex7
        public static int SecondMax(List<int> lst) => SecondMaxRecursion(lst, 0, 0, 0);
        private static int SecondMaxRecursion(List<int> lst, int max, int max2, int idx)
        {
            if (idx == lst.Count) return max2;
            if (lst[idx] >= max)
            {
                max2 = max;
                max = lst[idx];
            }
            return SecondMaxRecursion(lst, max, max2, idx + 1);
        }

        // Ex8
        public static List<string> SearchFilesRecursively(string directory, string query)
        {
            List<string> foundFiles = new List<string>();
            SearchFilesRecursivelyRecursion(directory, query, foundFiles);
            return foundFiles;
        }
        private static void SearchFilesRecursivelyRecursion(string directory, string query, List<string> foundFiles)
        {
            if (Directory.Exists(directory))
            {
                foundFiles.AddRange(from string file in Directory.GetFiles(directory)
                                    where file.Contains(query)
                                    select Path.GetFileName(file));
                foreach (string subDirectory in Directory.GetDirectories(directory)) SearchFilesRecursivelyRecursion(subDirectory, query, foundFiles);
            }
        }

        // Ex9
        public static List<string> AllBalancedParenthesis(int n)
        {
            List<string> balancedParentheses = new List<string>();
            // initialize with empty string and adding opening parenthesis
            ParenthesisRecursion(n, balancedParentheses, 1, 1, "", '(');
            return balancedParentheses;
        }
        private static void ParenthesisRecursion(int n,
                                                 List<string> balancedParentheses,
                                                 int open,
                                                 int unClosed,
                                                 string possiblyBalanced,
                                                 char toAppend)
        {
            if (n <= 0) return;
            if (open > n || unClosed < 0) return; // dead end
            possiblyBalanced += toAppend;
            if (open == n && unClosed == 0)
            {
                balancedParentheses.Add(possiblyBalanced.ToString());
                return;
            }
            // Try add opening
            ParenthesisRecursion(n, balancedParentheses, open + 1, unClosed + 1, possiblyBalanced, '(');
            // Try add closing
            ParenthesisRecursion(n, balancedParentheses, open, unClosed - 1, possiblyBalanced, ')');
        }
    }

    public class PopList<T>
    {
        private LinkedList<T> Elements;
        private PopList() { }
        public static PopList<T> FromLinkedList(LinkedList<T> list) => new PopList<T> { Elements = list };

        // Ex3
        // Attention: will delete all list elements! Memory: O(1)
        //      To avoid list deletion, we need method to add elements to the list
        //      for the purpose of making a copy. But assignment allows only Put()
        //      and Length() operations.
        public int Length() => Pop() ? 1 + Length() : 0;

        private const bool NOT_DELETED = false, DELETED = true;
        public bool Pop()
        {
            if (Elements.Last == null) return NOT_DELETED;
            Elements.RemoveLast();
            return DELETED;
        }
    }

    public static class RecursionFunctionsGeneric<T>
    {
        // Ex6
        public static void PrintEvenIndexes(List<T> lst) => InternalPrintEvenIndexes(lst, 0);
        public static void InternalPrintEvenIndexes(List<T> lst, int index)
        {
            if (index == lst.Count) return;
            if (index % 2 == 0) Console.Write(lst[index].ToString() + " ");
            InternalPrintEvenIndexes(lst, index + 1);
        }
    }
}
