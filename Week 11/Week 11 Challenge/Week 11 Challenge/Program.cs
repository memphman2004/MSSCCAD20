using System;
using System.Collections.Generic;

public class Solutions
{
    // -------------------------------
    // Question 1: Sort Colors (0, 1, 2)
    // -------------------------------
    public void SortColors(int[] nums)
    {
        int low = 0;                
        int mid = 0;                
        int high = nums.Length - 1; 

        while (mid <= high)
        {
            if (nums[mid] == 0)
            {
                (nums[low], nums[mid]) = (nums[mid], nums[low]);
                low++;
                mid++;
            }
            else if (nums[mid] == 1)
            {
                mid++;
            }
            else // nums[mid] == 2
            {
                (nums[mid], nums[high]) = (nums[high], nums[mid]);
                high--;
            }
        }
    }

    // -----------------------------------------
    // Question 2: Maximum number of "balloon"
    // -----------------------------------------
    public int MaxNumberOfBalloons(string text)
    {
        Dictionary<char, int> freq = new();

        foreach (char c in text)
        {
            if (!freq.ContainsKey(c))
                freq[c] = 0;

            freq[c]++;
        }

        int countB = freq.ContainsKey('b') ? freq['b'] : 0;
        int countA = freq.ContainsKey('a') ? freq['a'] : 0;
        int countL = freq.ContainsKey('l') ? freq['l'] : 0;
        int countO = freq.ContainsKey('o') ? freq['o'] : 0;
        int countN = freq.ContainsKey('n') ? freq['n'] : 0;

        // balloon requires:
        // b:1, a:1, n:1, l:2, o:2
        return Math.Min(
            Math.Min(countB, countA),
            Math.Min(countN, Math.Min(countL / 2, countO / 2))
        );
    }
}
