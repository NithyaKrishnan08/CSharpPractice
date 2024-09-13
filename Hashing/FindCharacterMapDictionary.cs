/*

Enter input string: 
abcdefgabc
Enter no. of elements to search: 
5

Enter ch to search: 
a
No. of times: 2

Enter ch to search: 
b
No. of times: 2

Enter ch to search: 
c
No. of times: 2

Enter ch to search: 
z
No. of times: 0

Enter ch to search: 
g
No. of times: 1

*/

// To understand map - Dictionary in C for characters#

using System;
using System.Collections.Generic; 

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter input string: ");
        string inputString = Console.ReadLine();
        
        // Precompute: fill the dictionary with the frequency of each number
        Dictionary<char, int> mapping = new Dictionary<char, int>();
        for(int i = 0; i < inputString.Length; i++)
        {
            if (mapping.ContainsKey(inputString[i]))
            {
                mapping[inputString[i]] += 1;  // Increment count if number already exists
            }
            else
            {
                mapping[inputString[i]] = 1;  // Initialize count for new number
            }
        }
        
        Console.WriteLine("Enter no. of elements to search: ");
        int noOfElementsToSearch = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        
        while (noOfElementsToSearch > 0)
        {
            Console.WriteLine("Enter ch to search: ");
            char chToSearch = Console.ReadLine()[0];
            
            // Fetch and print the result
            if (mapping.ContainsKey(chToSearch))
            {
                Console.WriteLine("No. of times: " + mapping[chToSearch]);
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
