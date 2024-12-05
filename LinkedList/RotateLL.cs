/*

Problem Statement: Given the head of a linked list, rotate the list to the right by k places.

The rotated linked list: 
3 -> 4 -> 5 -> 1 -> 2 -> null

*/

// Rotate a Linked List

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
        if (arr.Length == 0)
            return null;
            
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
    public Node RotateLL(Node head, int k)
    {
        // No element or only one element in the LL
        if(head == null || head.next == null || k == 0)
            return head;
        
        int length = 1;
        Node tail = head;
        
        while(tail.next != null)
        {
            length++;
            tail = tail.next;
        }
        
        k = k % length;
        if(k == 0)
            return head;
        
        tail.next = head;
        
        Node newLastNode = head;
        for(int i = 0; i < length - k - 1; i++)
        {
            newLastNode = newLastNode.next;
        }
        
        head = newLastNode.next;
        newLastNode.next = null;
        
        return head;
    }
    
    public void PrintLinkedList(Node head)
    {
        while(head != null)
        {
            Console.Write($"{head.data} -> ");
            head = head.next;
        }
        Console.Write("null");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        LinkedList linkedList = new LinkedList();
        int[] arr = {1, 2, 3, 4, 5};
        int k = 13;

        Node head = linkedList.ConvertArrayToLinkedList(arr);
        Node newHead = linkedList.RotateLL(head, k);
        Console.WriteLine($"The rotated linked list: ");
        linkedList.PrintLinkedList(newHead);
    }
}

