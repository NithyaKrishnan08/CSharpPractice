/*

Linked List after deleting the head:
5
6
8

*/

// Delete the head of the linked list

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
    
    public Node DeleteHeadLL(Node head)
    {
        if(head == null)
            return head;

        Node temp = head;
        head = head.next;
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
        int[] arr = {2, 5, 6, 8};

        Node head = linkedList.ConvertArrayToLinkedList(arr);
        
        Node deleteHead = linkedList.DeleteHeadLL(head);
        Console.WriteLine("Linked List after deleting the head:");
        linkedList.PrintLinkedList(deleteHead);
    }
}
