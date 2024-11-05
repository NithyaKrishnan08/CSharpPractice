/*

Brute Force Solution: 
The starting point of the loop in the given linked list: 2

Optimal Solution: 
The starting point of the loop in the given linked list: 2

*/

// Find the starting point of the loop or cycle in the linked list

using System;
using System.Collections.Generic;
using System.Linq;

public class Node
{
    public int data;
    public Node next;
    
    public Node(int data1)
    {
        data = data1;
        next = null;
    }
    
    public Node(int data1, Node next1)
    {
        data = data1;
        next = next1;
    }
}

public class LinkedList
{
    public Node ConvertArrayToLinkedList(int[] arr)
    {
        Node head = new Node(arr[0]);
        Node mover = head;
        for(int i = 1; i < arr.Length; i++)
        {
            Node temp = new Node(arr[i]);
            mover.next = temp;
            mover = temp;
        }
        return head;
    }
    
    // Brute Force Solution
    public Node FindStartingLoop1(Node head)
    {
        var nodeMap = new Dictionary<Node, int>();
        
        Node temp = head;
        
        while(temp != null)
        {
            if(nodeMap.ContainsKey(temp))
                return temp;
                
            nodeMap[temp] = 1;
            temp = temp.next;
        }
        return null;
    }
    
    // Optimal solution
    public Node FindStartingLoop2(Node head)
    {
        Node slow = head, fast = head;
        
        // When n is even, fast might reach null
        // When n is odd, fast might reach the last node
        while(fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            // There is a loop
            if(slow == fast)
            {
                slow = head;
                while(slow != fast)
                {
                    slow = slow.next;
                    fast = fast.next;
                }
                return slow; // starting point
            }
        }
        return null;
    }
}

class Program
{
    static void Main()
    {
        LinkedList linkedList = new LinkedList();
        
        Node head = new Node(1);
        Node second = new Node(2);
        Node third = new Node(3);
        Node fourth = new Node(4);
        Node fifth = new Node(5);

        head.next = second;
        second.next = third;
        third.next = fourth;
        fourth.next = fifth;
        // Create a loop
        fifth.next = second;
        
        Console.WriteLine("Brute Force Solution: ");
        Node result1 = linkedList.FindStartingLoop1(head);
        if(result1 != null)
            Console.WriteLine($"The starting point of the loop in the given linked list: {result1.data}");
        else
            Console.WriteLine("No loop is detected in the given linked list");
        
        Console.WriteLine();
        
        Console.WriteLine("Optimal Solution: ");
        Node result2 = linkedList.FindStartingLoop2(head);
        if(result2 != null)
            Console.WriteLine($"The starting point of the loop in the given linked list: {result2.data}");
        else
            Console.WriteLine("No loop is detected in the given linked list");
    }
}
