/*

Brute Force Solution: 
The reversed linked list: 
9
8
6
5
2


Optimal Solution (Iterative method): 
The reversed linked list: 
9
8
6
5
2


Optimal Solution (Recursive method): 
The reversed linked list: 
9
8
6
5
2

*/

// Reverse the linked list

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
    public Node ReverseLL1(Node head)
    {
        // No element or only one element in the LL
        if(head == null || head.next == null)
            return head;
        
        Node temp = head;
        Stack<int> myStack = new Stack<int>();
        
        while(temp != null)
        {
            myStack.Push(temp.data);
            temp = temp.next;
        }
        
        Node temp1 = head;
        
        while(temp1 != null)
        {
            temp1.data = myStack.Pop();
            temp1 = temp1.next;
        }
        
        return head;
    }
    
    // Optimal Solution I - Iterative
    public Node ReverseLL2(Node head)
    {
        // No element or only one element in the LL
        if(head == null || head.next == null)
            return head;
        
        Node temp = head;
        Node prev = null, front = null;
        
        while(temp != null)
        {
            front = temp.next;
            temp.next = prev;
            prev = temp;
            temp = front;
        }
        
        return prev;
    }
    
    // Optimal Solution II - Recursice
    public Node ReverseLL3(Node head)
    {
        // No element or only one element in the LL
        if(head == null || head.next == null)
            return head;
        
        Node newHead = ReverseLL3(head.next);
        Node front = head.next;
        front.next = head;
        head.next = null;
        
        return newHead;
    }
    
    public void PrintLinkedList(Node head)
    {
        while(head != null)
        {
            Console.WriteLine(head.data);
            head = head.next;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        LinkedList linkedList = new LinkedList();
        int[] arr = {2, 5, 6, 8, 9};

        Node head1 = linkedList.ConvertArrayToLinkedList(arr);
        Console.WriteLine("Brute Force Solution: ");
        Node newHead1 = linkedList.ReverseLL1(head1);
        Console.WriteLine($"The reversed linked list: ");
        linkedList.PrintLinkedList(newHead1);
        
        Console.WriteLine();
        
        Node head2 = linkedList.ConvertArrayToLinkedList(arr);
        Console.WriteLine("Optimal Solution (Iterative method): ");
        Node newHead2 = linkedList.ReverseLL2(head2);
        Console.WriteLine($"The reversed linked list: ");
        linkedList.PrintLinkedList(newHead2);
        
        Console.WriteLine();
        
        Node head3 = linkedList.ConvertArrayToLinkedList(arr);
        Console.WriteLine("Optimal Solution (Recursive method): ");
        Node newHead3 = linkedList.ReverseLL3(head3);
        Console.WriteLine($"The reversed linked list: ");
        linkedList.PrintLinkedList(newHead3);
    }
}
