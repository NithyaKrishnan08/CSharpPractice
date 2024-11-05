/*

Brute Force Solution: 
Loop is detected in the given linked list

Optimal Solution: 
Loop is detected in the given linked list

*/

// Detect a loop or cycle in the linked list

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
    public bool FindLoop1(Node head)
    {
        var nodeMap = new Dictionary<Node, int>();
        
        Node temp = head;
        
        while(temp != null)
        {
            if(nodeMap.ContainsKey(temp))
                return true;
                
            nodeMap[temp] = 1;
            temp = temp.next;
        }
        return false;
    }
    
    // Optimal solution
    public bool FindLoop2(Node head)
    {
        Node slow = head, fast = head;
        
        // When n is even, fast might reach null
        // When n is odd, fast might reach the last node
        while(fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if(slow == fast)
                return true;
        }
        
        return false;
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
        fifth.next = third;
        
        Console.WriteLine("Brute Force Solution: ");
        if(linkedList.FindLoop1(head))
            Console.WriteLine("Loop is detected in the given linked list");
        else
            Console.WriteLine("No loop is detected in the given linked list");
        
        Console.WriteLine();
        
        Console.WriteLine("Optimal Solution: ");
        if(linkedList.FindLoop2(head))
            Console.WriteLine("Loop is detected in the given linked list");
        else
            Console.WriteLine("No loop is detected in the given linked list");
    }
}
