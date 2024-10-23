/*

Added 4 at the tail of the linked list: 
2
5
6
8
4

*/

// Added element in the tail of the linked list

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
    
    public Node InsertHeadLL(Node head, int value)
    {
        Node temp = new Node(value, head);
        return temp;
    }
    
    public Node InsertTailLL(Node head, int value)
    {
        if(head == null)
            return new Node(value);
            
        Node temp = head;
        while(temp.next != null)
        {
            temp = temp.next;
        }
            
        Node newNode = new Node(value);
        temp.next = newNode;
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
        int value = 4;

        Node head = linkedList.ConvertArrayToLinkedList(arr);
        Node addedHead = linkedList.InsertTailLL(head, value);
        
        Console.WriteLine($"Added {value} at the tail of the linked list: ");
        linkedList.PrintLinkedList(addedHead);
    }
}
