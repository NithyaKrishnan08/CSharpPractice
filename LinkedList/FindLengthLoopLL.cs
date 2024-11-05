/*

Brute Force Solution: 
The length of the loop in the given linked list: 4

Optimal Solution: 
The length of the loop in the given linked list: 4

*/

// Find the length of the loop or cycle in the linked list

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
    public int FindLengthLoop1(Node head)
    {
        var vistedNodes = new Dictionary<Node, int>();
        
        Node temp = head;
        int timer = 0;
        
        while(temp != null)
        {
            if(vistedNodes.ContainsKey(temp))
            {
                int loopLength = timer - vistedNodes[temp];
                return loopLength;
            }
                
            vistedNodes[temp] = 1;
            temp = temp.next;
            timer++;
        }
        return 0;
    }
    
    // Optimal solution (tortoise & Hare Algorithm)
    public int FindLengthLoop2(Node head)
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
                return FindLength(slow, fast);
            }
        }
        return 0;
    }
    
    public int FindLength(Node slow, Node fast)
    {
        int count = 1;
        fast = fast.next;
        
        while(slow != fast)
        {
            count++;
            fast = fast.next;
        }
        
        return count;
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
        int result1 = linkedList.FindLengthLoop1(head);
        if(result1 != 0)
            Console.WriteLine($"The length of the loop in the given linked list: {result1}");
        else
            Console.WriteLine("No loop is detected in the given linked list");
        
        Console.WriteLine();
        
        Console.WriteLine("Optimal Solution: ");
        int result2 = linkedList.FindLengthLoop2(head);
        if(result2 != 0)
            Console.WriteLine($"The length of the loop in the given linked list: {result2}");
        else
            Console.WriteLine("No loop is detected in the given linked list");
    }
}
