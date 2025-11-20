using System;

namespace Assignment11_2
{
    // Node class for singly linked list
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Program
    {
        // ----------- PART 1: MAX PROFIT FROM STOCK PRICES -----------
        static int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length < 2) return 0;

            int minPrice = prices[0];
            int maxProfit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                int profit = prices[i] - minPrice;
                if (profit > maxProfit)
                    maxProfit = profit;
                if (prices[i] < minPrice)
                    minPrice = prices[i];
            }
            return maxProfit;
        }

        // ----------- PART 2: REVERSE SINGLY LINKED LIST -----------
        static ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }
            return prev;
        }

        // Helper: Print Linked List
        static void PrintList(ListNode head)
        {
            ListNode node = head;
            Console.Write("[");
            while (node != null)
            {
                Console.Write(node.val);
                if (node.next != null)
                    Console.Write(",");
                node = node.next;
            }
            Console.WriteLine("]");
        }

        // Helper: Convert Array to Linked List
        static ListNode ArrayToList(int[] arr)
        {
            ListNode dummy = new ListNode(0);
            ListNode curr = dummy;
            foreach (var val in arr)
            {
                curr.next = new ListNode(val);
                curr = curr.next;
            }
            return dummy.next;
        }

        static void Main(string[] args)
        {
            // PART 1: Stock Profits
            Console.WriteLine("Part 1: Maximum Stock Profit Examples");
            int[] prices1 = { 7, 1, 5, 3, 6, 4 };
            int[] prices2 = { 7, 6, 4, 3, 1 };
            Console.WriteLine("Input: [7,1,5,3,6,4] => Output: " + MaxProfit(prices1)); // 5
            Console.WriteLine("Input: [7,6,4,3,1] => Output: " + MaxProfit(prices2)); // 0
            Console.WriteLine();

            // PART 2: Reverse Linked List
            Console.WriteLine("Part 2: Reverse Linked List Examples");

            // Example 1
            int[] arr1 = { 1, 2, 3, 4, 5 };
            ListNode list1 = ArrayToList(arr1);
            Console.Write("Input: ");
            PrintList(list1);
            ListNode reversed1 = ReverseList(list1);
            Console.Write("Output: ");
            PrintList(reversed1);

            // Example 2
            int[] arr2 = { 1, 2 };
            ListNode list2 = ArrayToList(arr2);
            Console.Write("Input: ");
            PrintList(list2);
            ListNode reversed2 = ReverseList(list2);
            Console.Write("Output: ");
            PrintList(reversed2);

            // Example 3 (empty list)
            int[] arr3 = { };
            ListNode list3 = ArrayToList(arr3);
            Console.Write("Input: ");
            PrintList(list3);
            ListNode reversed3 = ReverseList(list3);
            Console.Write("Output: ");
            PrintList(reversed3);

            Console.WriteLine("\nDone. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
