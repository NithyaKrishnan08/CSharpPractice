/*

The rearranged array: 
1 -4 2 -5 
The rearranged array: 
1 -4 2 -5 3 4 

*/

// To rearrange elements in an array by sign

using System;
using System.Collections.Generic;

public class Solution
{
    // To rearrange elements in an array by sign with equal number of positive and negative numbers
    public int[] RearrangeArray(int[] arr)
    {
        int n = arr.Length;
        int[] ans = new int[n];
        int posIndex = 0, negIndex = 1;

        for(int i = 0; i < n; i++)
        {
            if(arr[i] < 0)
            {
                ans[negIndex] = arr[i];
                negIndex += 2;
            }
            else
            {
                ans[posIndex] = arr[i];
                posIndex += 2;
            }
        }
        return ans;
    }
    
    // To rearrange elements in an array by sign with unequal positive and negative numbers
    public int[] RearrangeArrayBySign(int[] arr)
    {
        int n = arr.Length;
        List<int> posArray = new List<int>();
        List<int> negArray = new List<int>();

        //Segregate the array into positive and negative numbers
        for(int i = 0; i < n; i++)
        {
            if(arr[i] > 0)
            {
                posArray.Add(arr[i]);
            }
            else
            {
                negArray.Add(arr[i]);
            }
        }
        
        // If positive numbers are lesser than negative numbers
        if(posArray.Count < negArray.Count)
        {
            // First, fill array alternatively till the point where positive and negative are equal in number
            for(int i = 0; i < posArray.Count; i++)
            {
                arr[2*i] = posArray[i];
                arr[2*i + 1] = negArray[i];
            }
            
            // Fill the remaining negatives at the end of the array
            int index = posArray.Count * 2;
            for(int i = posArray.Count; i < negArray.Count; i++)
            {
                arr[index] = negArray[i];
                index++;
            }
        }
        // If negative numbers are lesser than positive numbers
        else
        {
            // First, fill array alternatively till the point where positive and negative are equal in number
            for(int i = 0; i < negArray.Count; i++)
            {
                arr[2*i] = posArray[i];
                arr[2*i + 1] = negArray[i];
            }
            
            // Fill the remaining positives at the end of the array
            int index = negArray.Count * 2;
            for(int i = negArray.Count; i < posArray.Count; i++)
            {
                arr[index] = posArray[i];
                index++;
            }
        }
        return arr;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = new int[] {1,2,-4,-5};
        
        int[] result = solution.RearrangeArray(arr);
        
        Console.WriteLine("The rearranged array: ");
        for(int i = 0; i < arr.Length; i++)
        {
            Console.Write(result[i] + " ");
        }
        Console.WriteLine();
        
        // Unequal positive and negative numbers
        int[] arr1 = new int[] {1,2,-4,-5,3,4};
        
        int[] result1 = solution.RearrangeArrayBySign(arr1);
        
        Console.WriteLine("The rearranged array: ");
        for(int i = 0; i < arr1.Length; i++)
        {
            Console.Write(result1[i] + " ");
        }
        Console.WriteLine();
    }
}
