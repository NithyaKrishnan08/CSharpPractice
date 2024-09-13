/*

mono /tmp/pzDk4lHQBF.exe
Enter no. of elements in the input array: 
5
Enter no for the input array: 
1
Enter no for the input array: 
3
Enter no for the input array: 
2
Enter no for the input array: 
1
Enter no for the input array: 
3
Enter no. of elements to search: 
5
Enter no. to search: 
1
No. of times: 2

Enter no. to search: 
4
No. of times: 0

Enter no. to search: 
2
No. of times: 1

Enter no. to search: 
3
No. of times: 2

Enter no. to search: 
12
No. of times: 0


=== Code Execution Successful ===

*/

// To understand hashing - to find no. of a times a number occurs in an array

using System;

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
        
        // precompute
        int max = 13;
        int[] hashArray = new int[max];
        for(int i = 0; i < n; i++)
        {
            hashArray[inputArray[i]] += 1;
        }
        
        
        Console.WriteLine("Enter no. of elements to search: ");
        int noOfElementsToSearch = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        
        while(noOfElementsToSearch > 0)
        {
            Console.WriteLine("Enter no. to search: ");
            int noToSearch = Convert.ToInt32(Console.ReadLine());
            
            // fetch
            Console.WriteLine("No. of times: " + hashArray[noToSearch]);
            
            Console.WriteLine();
            noOfElementsToSearch--;
        }
    }
}
