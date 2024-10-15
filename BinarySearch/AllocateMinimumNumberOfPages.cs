/*

Brute Force solution: 
The answer: 71

Optimal solution: 
The answer: 71

Problem Statement: Given an array ‘arr of integer numbers, ‘ar[i]’ represents the number of pages in the ‘i-th’ book. There are a ‘m’ number of students, and the task is to allocate all the books to the students.
Allocate books in such a way that:

Each student gets at least one book.
Each book should be allocated to only one student.
Book allocation should be in a contiguous manner.
You have to allocate the book to ‘m’ students such that the maximum number of pages assigned to a student is minimum. If the allocation of books is not possible. return -1

*/

// Allocate Minimum Number of Pages

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int CountStudents(int[] arr, int pages)
    {
        int n = arr.Length;
        int students = 1;
        long pagesStudents = 0;
        
        for(int i = 0; i < n; i++)
        {
            if(pagesStudents + arr[i] <= pages)
            {
                pagesStudents += arr[i];
            }
            else
            {
                students++;
                pagesStudents = arr[i];
            }
        }
        return students;
    }
    
    // Brute Force solution
    public int FindPages1(int[] arr, int m)
    {
        int n = arr.Length;
        
        if(m > n)
            return -1;
            
        int low = arr.Max();
        int high = arr.Sum();
        
        for(int pages = low; pages <= high; pages++)
        {
            if(CountStudents(arr, pages) == m)
                return pages;
        }
        return low;
    }
    
    // Optimal solution
    public int FindPages2(int[] arr, int m)
    {
        int n = arr.Length;
        
        if(m > n)
            return -1;
            
        int low = arr.Max();
        int high = arr.Sum();
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            int students = CountStudents(arr, mid);
            if(students > m)
                low = mid + 1;
            else
                high = mid - 1;
        }
        
        return low;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {25, 46, 28, 49, 24};
        int m = 4;
        
        int result1 = solution.FindPages1(arr, m);
        Console.WriteLine("Brute Force solution: ");
        if (result1 == -1)
            Console.WriteLine($"There is no minimum page allocation");
        else
            Console.WriteLine($"The answer: {result1}");
        Console.WriteLine();
        
        int result2 = solution.FindPages2(arr, m);
        Console.WriteLine("Optimal solution: ");
        if (result2 == -1)
            Console.WriteLine($"There is no minimum page allocation");
        else
            Console.WriteLine($"The answer: {result2}");
        Console.WriteLine();
    }
}
