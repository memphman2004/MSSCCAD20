using System;
using System.Collections.Generic;

namespace RansomNoteAndPalindromeList
{
    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int value) { val = value; }
    }

    class Program
    {
        // Problem 1: Ransom Note from Magazine
        static bool CanConstruct(string ransomNote, string magazine)
        {
            // Count letters in magazine
            Dictionary<char, int> magazineCount = new Dictionary<char, int>();
            foreach (char c in magazine)
            {
                if (!magazineCount.ContainsKey(c))
                    magazineCount[c] = 0;
                magazineCount[c]++;
            }

            // Check if we can make ransomNote
            foreach (char c in ransomNote)
            {
                if (!magazineCount.ContainsKey(c) || magazineCount[c] == 0)
                    return false;
                magazineCount[c]--;
            }
            return true;
        }

        // Problem 2: Palindrome Linked List
        static bool IsPalindrome(ListNode head)
        {
            // Put values into a list
            List<int> vals = new List<int>();
            ListNode curr = head;
            while (curr != null)
            {
                vals.Add(curr.val);
                curr = curr.next;
            }

            // Check if list is a palindrome
            int left = 0, right = vals.Count - 1;
            while (left < right)
            {
                if (vals[left] != vals[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        // Helper: Convert array to linked list
        static ListNode ArrayToList(int[] arr)
        {
            ListNode dummy = new ListNode(0);
            ListNode curr = dummy;
            foreach (var v in arr)
            {
                curr.next = new ListNode(v);
                curr = curr.next;
            }
            return dummy.next;
        }

        static void Main(string[] args)
        {
            // --- Problem 1: Ransom Note Examples ---
            Console.WriteLine("Problem 1: Ransom Note from Magazine");

            string ransom1 = "a", mag1 = "b";
            Console.WriteLine($"Input: ransomNote = \"{ransom1}\", magazine = \"{mag1}\"");
            Console.WriteLine("Output: " + CanConstruct(ransom1, mag1)); // false

            string ransom2 = "aa", mag2 = "ab";
            Console.WriteLine($"Input: ransomNote = \"{ransom2}\", magazine = \"{mag2}\"");
            Console.WriteLine("Output: " + CanConstruct(ransom2, mag2)); // false

            string ransom3 = "aa", mag3 = "aab";
            Console.WriteLine($"Input: ransomNote = \"{ransom3}\", magazine = \"{mag3}\"");
            Console.WriteLine("Output: " + CanConstruct(ransom3, mag3)); // true

            Console.WriteLine();

            // --- Problem 2: Palindrome Linked List Examples ---
            Console.WriteLine("Problem 2: Palindrome Linked List");

            int[] arr1 = { 1, 2, 2, 1 };
            ListNode list1 = ArrayToList(arr1);
            Console.WriteLine("Input: head = [1,2,2,1]");
            Console.WriteLine("Output: " + IsPalindrome(list1)); // true

            int[] arr2 = { 1, 2 };
            ListNode list2 = ArrayToList(arr2);
            Console.WriteLine("Input: head = [1,2]");
            Console.WriteLine("Output: " + IsPalindrome(list2)); // false

            Console.WriteLine("\nDone. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
