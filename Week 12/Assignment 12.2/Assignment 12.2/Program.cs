using System;
using System.Collections.Generic;

namespace RemoveLinkedListElements
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
        // Function to remove elements with a given value from linked list
        static ListNode RemoveElements(ListNode head, int val)
        {
            // Use a dummy node to handle head removals easily
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode curr = dummy;

            while (curr.next != null)
            {
                if (curr.next.val == val)
                {
                    curr.next = curr.next.next;
                }
                else
                {
                    curr = curr.next;
                }
            }
            return dummy.next;
        }

        // Helper to create a linked list from array
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

        // Helper to print linked list
        static void PrintList(ListNode head)
        {
            List<int> values = new List<int>();
            while (head != null)
            {
                values.Add(head.val);
                head = head.next;
            }
            Console.WriteLine("[" + string.Join(",", values) + "]");
        }

        static void Main(string[] args)
        {
            // Example 1
            Console.WriteLine("Example 1:");
            int[] arr1 = { 1, 2, 6, 3, 4, 5, 6 };
            ListNode head1 = ArrayToList(arr1);
            Console.Write("Input: head = [1,2,6,3,4,5,6], val = 6\nOutput: ");
            ListNode result1 = RemoveElements(head1, 6);
            PrintList(result1);

            // Example 2
            Console.WriteLine("\nExample 2:");
            int[] arr2 = { };
            ListNode head2 = ArrayToList(arr2);
            Console.Write("Input: head = [], val = 1\nOutput: ");
            ListNode result2 = RemoveElements(head2, 1);
            PrintList(result2);

            // Example 3
            Console.WriteLine("\nExample 3:");
            int[] arr3 = { 7, 7, 7, 7 };
            ListNode head3 = ArrayToList(arr3);
            Console.Write("Input: head = [7,7,7,7], val = 7\nOutput: ");
            ListNode result3 = RemoveElements(head3, 7);
            PrintList(result3);

            Console.WriteLine("\nDone. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
