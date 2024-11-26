/*

Optimal Solution: 
Pairs with the given sum:
(1, 4)
(2, 3)

*/

// Find all pairs with given sum in sorted DLL

using System;
using System.Collections.Generic;
using System.Linq;

public class Node
{
    public int data;
    public Node next;
    public Node back;
    
    public Node(int data1)
    {
        data = data1;
        next = null;
        back = null;
    }
    
    public Node(int data1, Node next1, Node back1)
    {
        data = data1;
        next = next1;
        back = back1;
    }
}

public class DoublyLinkedList
{
    public Node ConvertArrayToDoublyLinkedList(int[] arr)
    {
        if (arr.Length == 0) return null;
        
        Node head = new Node(arr[0]);
        Node prev = head;
        for(int i = 1; i < arr.Length; i++)
        {
            Node temp = new Node(arr[i], null, prev);
            prev.next = temp;
            prev = temp;
        }
        return head;
    }
    
    // Optimal solution
    public List<Tuple<int, int>> FindAllPairsSortedDLL(Node head, int sum)
    {
        List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();
        Node first = head;
        Node last = head;

        // Move 'last' to the end of the list
        while (last.next != null)
        {
            last = last.next;
        }

        // Use two pointers to find pairs
        while (first != null && last != null && first != last && first.back != last)
        {
            int currentSum = first.data + last.data;

            if (currentSum == sum)
            {
                pairs.Add(new Tuple<int, int>(first.data, last.data));
                first = first.next;
                last = last.back;
            }
            else if (currentSum < sum)
            {
                first = first.next;
            }
            else
            {
                last = last.back;
            }
        }
        return pairs;
    }
    
    public void PrintPairs(List<Tuple<int, int>> pairs)
    {
        if (pairs.Count == 0)
        {
            Console.WriteLine("No pairs found with the given sum.");
        }
        else
        {
            Console.WriteLine("Pairs with the given sum:");
            foreach (var pair in pairs)
            {
                Console.WriteLine($"({pair.Item1}, {pair.Item2})");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
        int[] arr = {1, 2, 3, 4, 9};
        int sum = 5;

        Node head = doublyLinkedList.ConvertArrayToDoublyLinkedList(arr);
        
        List<Tuple<int, int>> sumPairs = doublyLinkedList.FindAllPairsSortedDLL(head, sum);
        
        Console.WriteLine($"Optimal Solution: ");
        doublyLinkedList.PrintPairs(sumPairs);
    }
}

