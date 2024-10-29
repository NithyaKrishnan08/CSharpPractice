/*

Reverse the doubly linked list
Brute force solution: 
7
8
5
12

Optimal solution: 
7
8
5
12

*/

// Reverse the doubly linked list

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
    
    // Brute force solution
    public Node ReverseDLL1(Node head)
    {
        // No element or only one element
        if(head == null || head.next == null)
            return head;
            
        Node temp = head;
        Stack<int> myStack = new Stack<int>();
        
        while(temp != null)
        {
            myStack.Push(temp.data);
            temp = temp.next;
        }
        
        Node temp1 = head;
        while(temp1 != null)
        {
            temp1.data = myStack.Pop();
            temp1 = temp1.next;
        }
        
        return head;
    }
    
    // Optimal solution
    public Node ReverseDLL2(Node head)
    {
        // No element or only one element
        if(head == null || head.next == null)
            return head;
            
        Node prev = null, current = head;
        
        while(current != null)
        {
            prev = current.back;
            current.back = current.next;
            current.next = prev;
            
            current = current.back;
        }
        
        return prev.back;
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

        Node head1 = doublyLinkedList.ConvertArrayToDoublyLinkedList(arr);
        Console.WriteLine("Reverse the doubly linked list");

        Node newHead1 = doublyLinkedList.ReverseDLL1(head1);
        Console.WriteLine($"Brute force solution: ");
        doublyLinkedList.PrintDoublyLinkedList(newHead1);
        
        Node head2 = doublyLinkedList.ConvertArrayToDoublyLinkedList(arr);
        Node newHead2 = doublyLinkedList.ReverseDLL2(head2);
        Console.WriteLine($"Optimal solution: ");
        doublyLinkedList.PrintDoublyLinkedList(newHead2);
    }
}
