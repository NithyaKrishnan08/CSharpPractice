/*

Problem Statement : Segregate even and odd nodes in LinkedList

Given a LinkedList of integers. Modify the LinkedList in such a way that in Modified LinkedList all the even numbers appear before all the odd numbers in LinkedList.

Also, note that the order of even and odd numbers should remain the same. 


Optimal Solution: 
1
3
5
2
4
6

*/

// Segregate even and odd nodes in LinkedList

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
    
    // Optimal Solution
    public Node SegregateOddEvenNodesLL(Node head)
    {
        // If no element or single element node
        if(head == null || head.next == null)
            return head;
            
        Node odd = head, even = head.next, evenHead = head.next;

        while(even != null && even.next != null)
        {
            odd.next = odd.next.next;
            even.next = even.next.next;
            odd = odd.next;
            even = even.next;
        }
        
        odd.next = evenHead;
        return head;
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
        int[] arr = {1, 2, 3, 4, 5, 6};

        Node head = linkedList.ConvertArrayToLinkedList(arr);
        
        Console.WriteLine("Optimal Solution: ");
        Node result = linkedList.SegregateOddEvenNodesLL(head);
        if(result != null)
            linkedList.PrintLinkedList(result);
        else
            Console.WriteLine("The linked list could not be segregated");
            
        Console.WriteLine();
    }
}



