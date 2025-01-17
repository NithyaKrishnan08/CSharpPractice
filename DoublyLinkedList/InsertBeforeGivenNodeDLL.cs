/*

Inserting 10 before the given node of the doubly linked list
12
5
10
8
7

*/

// Insertion of the given value before the given node of the doubly linked list

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
    
    public Node InsertBeforeHeadDLL(Node head, int value)
    {
        Node newHead = new Node(value, head, null);
        head.back = newHead;
        
        return newHead;
    }
    
    public Node InsertBeforeTailDLL(Node head, int value)
    {
        if(head.next == null)
            return InsertBeforeHeadDLL(head, value);
            
        Node temp = head;
        while(temp.next != null)
        {
            temp = temp.next;
        }
        
        Node prev = temp.back;
        
        Node newNode = new Node(value, temp, prev);
        prev.next = newNode;
        temp.back = newNode;
        
        return head;
    }
    
    public Node InsertBeforeKthElementDLL(Node head, int k, int value)
    {
        if (head == null)
            return null;
            
        if(k == 1)
            return InsertBeforeHeadDLL(head, value);
            
        Node temp = head;
        int count = 0;
        while(temp != null)
        {
            count++;
            if(count == k)
                break;
            temp = temp.next;
        }
        
        Node prev = temp.back;
        
        Node newNode = new Node(value, temp, prev);
        prev.next = newNode;
        temp.back = newNode;
        
        return head;
    }
    
    public void InsertBeforeGivenNodeDLL(Node node, int value)
    {
        Node prev = node.back;
        
        Node newNode = new Node(value, node, prev);
        prev.next = newNode;
        node.back = newNode;
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
        int value = 10;

        Node head = doublyLinkedList.ConvertArrayToDoublyLinkedList(arr);
        doublyLinkedList.InsertBeforeGivenNodeDLL(head.next.next, value);
        
        Console.WriteLine($"Inserting {value} before the given node of the doubly linked list");
        doublyLinkedList.PrintDoublyLinkedList(head);
    }
}
