/*

Enter input string: 
abcdabehf
Enter total no. of characters to search: 
5

Enter ch to search: 
a
No. of times: 2

Enter ch to search: 
g
No. of times: 0

Enter ch to search: 
h
No. of times: 1

Enter ch to search: 
b
No. of times: 2

Enter ch to search: 
c
No. of times: 1

*/

// To understand hashing - to find no. of a times a number occurs in an array

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter input string: ");
        string inputString = Console.ReadLine();
        
        // precompute
        int max = 256;
        int[] hashArray = new int[max];
        for(int i = 0; i < inputString.Length; i++)
        {
            hashArray[inputString[i]] += 1;
        }
        
        
        Console.WriteLine("Enter total no. of characters to search: ");
        int noOfElementsToSearch = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        
        while(noOfElementsToSearch > 0)
        {
            Console.WriteLine("Enter ch to search: ");
            char chToSearch = Console.ReadLine()[0];
            
            // fetch
            Console.WriteLine("No. of times: " + hashArray[chToSearch]);
            
            Console.WriteLine();
            noOfElementsToSearch--;
        }
    }
}
