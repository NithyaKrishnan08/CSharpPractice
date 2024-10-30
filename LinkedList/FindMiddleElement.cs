/*

Brute Force Solution: 
The middle node value of the linked list: 8

Optimal Solution (Tortoise and Hare Method): 
The middle node value of the linked list: 8

*/

// Find the middle element of the linked list

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
    public Node FindMiddleElement1(Node head)
    {
        // No element or only one element in the LL
        if(head == null || head.next == null)
            return head;
            
        int count = 0;
        Node temp = head;
        
        while(temp != null)
        {
            count++;
            temp = temp.next;
        }
        
        int middleNodeCount = (count / 2) + 1;
        Node temp1 = head;
        
        while(temp1 != null)
        {
            middleNodeCount = middleNodeCount - 1;
            
            if(middleNodeCount == 0)
                break;
            
            temp1 = temp1.next;
        }
        
        return temp1;
    }
    
    // Optimal Solution - Tortoise & Hare method
    public Node FindMiddleElement2(Node head)
    {
        // No element or only one element in the LL
        if(head == null || head.next == null)
            return head;

        Node slow = head, fast = head;
        
        // When n is even, fast might reach null
        // When n is odd, fast might reach the last node
        while(fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        return slow;
    }
}

class Program
{
    static void Main()
    {
        LinkedList linkedList = new LinkedList();
        int[] arr = {2, 5, 6, 8, 9, 10};

        Node head = linkedList.ConvertArrayToLinkedList(arr);
        
        Console.WriteLine("Brute Force Solution: ");
        Node result1 = linkedList.FindMiddleElement1(head);
        Console.WriteLine($"The middle node value of the linked list: {result1.data}");
        
        Console.WriteLine();
        
        Console.WriteLine("Optimal Solution (Tortoise and Hare Method): ");
        Node result2 = linkedList.FindMiddleElement2(head);
        Console.WriteLine($"The middle node value of the linked list: {result2.data}");
    }
}
