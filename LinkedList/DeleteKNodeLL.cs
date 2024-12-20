/*

Linked list after deleting 3th element:
2
5
8

*/

// Delete kth element in the linked list

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
    
    public int LengthOfLL(Node head)
    {
        int count = 0;
        Node temp = head;
        
        while(temp != null)
        {
            temp = temp.next;
            count++;
        }
        
        return count;
    }
    
    public Node DeleteKNodeLL(Node head, int k)
    {
        if(head == null)
            return head;
        
        if(k == 1)
        {
            Node temp = head;
            head = head.next;
            return head;
        }
        
        int count = 0;
        Node temp1 = head, prev = null;
        
        while(temp1 != null)
        {
            count++;
            if(count == k)
            {
                prev.next = prev.next.next;
                break;
            }
            prev = temp1;
            temp1 = temp1.next;
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
        int[] arr = {2, 5, 6, 8};
        int k = 3;

        Node head = linkedList.ConvertArrayToLinkedList(arr);
        Node deletedHead = linkedList.DeleteKNodeLL(head, k);
        
        Console.WriteLine($"Linked list after deleting {k}th element:");
        linkedList.PrintLinkedList(deletedHead);
    }
}
