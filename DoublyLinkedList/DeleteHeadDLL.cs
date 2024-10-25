/*

Deleting head of doubly linked list
5
8
7

*/

// Deleting head of doubly linked list

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

        Node head = doublyLinkedList.ConvertArrayToDoublyLinkedList(arr);
        head = doublyLinkedList.DeleteHeadDLL(head);
        
        Console.WriteLine($"Deleting head of doubly linked list");
        doublyLinkedList.PrintDoublyLinkedList(head);
    }
}