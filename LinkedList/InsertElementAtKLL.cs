/*

Added 10 at position 2 of the linked list: 
12
10
5
8
7

*/

// Added element in the k position of the linked list

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
    
    public Node InsertElementAtKLL(Node head, int element, int k)
    {
        if(head == null)
        {
            if(k == 1)
                return new Node(element);
            else
                return null;
        }
        
        // Insertion at head
        if(k == 1)
        {
            Node tempHead = new Node(element, head);
            return tempHead;
        }
        
        int count = 0;
        Node temp = head;
        while(temp != null)
        {
            count++;
            if(count == k - 1)
            {
                Node newNode = new Node(element);
                newNode.next = temp.next;
                temp.next = newNode;
                break;
            }
            temp = temp.next;
        }
            
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
        int[] arr = {12, 5, 8, 7};
        int element = 10, k = 2;

        Node head = linkedList.ConvertArrayToLinkedList(arr);
        Node addedHead = linkedList.InsertElementAtKLL(head, element, k);
        
        Console.WriteLine($"Added {element} at position {k} of the linked list: ");
        linkedList.PrintLinkedList(addedHead);
    }
}
