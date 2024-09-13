/*

Enter no. of elements in the input array: 
7
Enter no for the input array: 
1
Enter no for the input array: 
2
Enter no for the input array: 
3
Enter no for the input array: 
1
Enter no for the input array: 
3
Enter no for the input array: 
2
Enter no for the input array: 
12
Enter no. of elements to search: 
5

Enter no. to search: 
1
No. of times: 2

Enter no. to search: 
2
No. of times: 2

Enter no. to search: 
3
No. of times: 2

Enter no. to search: 
4
No. of times: 0

Enter no. to search: 
12
No. of times: 1

*/

// To understand map - Dictionary in C#

using System;
using System.Collections.Generic; 

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter no. of elements in the input array: ");
        int n = Convert.ToInt32(Console.ReadLine());
        
        int[] inputArray = new int[n];
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter no for the input array: ");
            inputArray[i] = Convert.ToInt32(Console.ReadLine());
        }
        
        // Precompute: fill the dictionary with the frequency of each number
        Dictionary<int, int> mapping = new Dictionary<int, int>();
        for(int i = 0; i < n; i++)
        {
            if (mapping.ContainsKey(inputArray[i]))
            {
                mapping[inputArray[i]] += 1;  // Increment count if number already exists
            }
            else
            {
                mapping[inputArray[i]] = 1;  // Initialize count for new number
            }
        }
        
        Console.WriteLine("Enter no. of elements to search: ");
        int noOfElementsToSearch = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        
        while (noOfElementsToSearch > 0)
        {
            Console.WriteLine("Enter no. to search: ");
            int noToSearch = Convert.ToInt32(Console.ReadLine());
            
            // Fetch and print the result
            if (mapping.ContainsKey(noToSearch))
            {
                Console.WriteLine("No. of times: " + mapping[noToSearch]);
            }
            else
            {
                Console.WriteLine("No. of times: 0");  // If the number wasn't in the input array
            }
            
            Console.WriteLine();
            noOfElementsToSearch--;
        }
    }
}
