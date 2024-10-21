/*

Traversing through linked list

2
5
6
8

*/

// Traversing through linked list

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
}

class Program
{
    static void Main()
    {
        LinkedList linkedList = new LinkedList();
        int[] arr = {2, 5, 6, 8};

        Node head = linkedList.ConvertArrayToLinkedList(arr);
        
        Node temp = head;
        
        while(temp != null)
        {
            Console.WriteLine(temp.data);
            temp = temp.next;
        }
    }
}
