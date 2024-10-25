/*

Deleting 2th element of the doubly linked list
12
8
7

*/

// Deleting kth element of doubly linked list

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
    
    public Node DeleteHeadDLL(Node head)
    {
        if(head == null || head.next == null)
            return null;
            
        Node prev = head;
        head = head.next;
        head.back = null;
        prev.next = null;
        return head;
    }
    
    public Node DeleteTailDLL(Node head)
    {
        if(head == null || head.next == null)
            return null;
          
        Node tail = head; 
        while(tail.next != null)
        {
            tail = tail.next;
        }
        Node newTail = tail.back;
        newTail.next = null;
        tail.back = null;

        return head;
    }
    
    public Node DeleteKthElementDLL(Node head, int k)
    {
        if(head == null)
            return null;
            
        int count = 0;
        
        Node temp = head;
        while(temp != null)
        {
            count++;
            if(count == k)
                break;
            temp = temp.next;
        }
        
        Node prev = temp.back;
        Node front = temp.next;
        
        if(prev == null && front == null) // single element in the DLL
            return null;
        else if (prev == null) // element at head position
            return DeleteHeadDLL(head);
        else if(front == null) // element at tail position
            return DeleteTailDLL(head);
        else
        {
            prev.next = front;
            front.back = prev;
            temp.next = null;
            temp.back = null;
        }

        return head;
    }
    
    public void PrintDoublyLinkedList(Node head)
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
        DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
        int[] arr = {12, 5, 8, 7};
        int k = 2;

        Node head = doublyLinkedList.ConvertArrayToDoublyLinkedList(arr);
        head = doublyLinkedList.DeleteKthElementDLL(head, k);
        
        Console.WriteLine($"Deleting {k}th element of the doubly linked list");
        doublyLinkedList.PrintDoublyLinkedList(head);
    }
}
