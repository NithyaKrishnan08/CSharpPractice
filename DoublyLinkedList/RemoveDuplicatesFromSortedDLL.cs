/*

Optimal Solution: 
1 ->2 ->3 ->4 ->5 ->6 ->

*/

// Remove duplicates from sorted DLL

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
        if (arr.Length == 0) return null;
        
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
    
    // Optimal solution
    public Node RemoveDuplicatesFromSortedDLL(Node head)
    {
        Node temp = head;

        while (temp != null && temp.next != null)
        {
            Node nextNode = temp.next;
            while(nextNode != null && nextNode.data == temp.data)
            {
                nextNode = nextNode.next;
            }
            
            temp.next = nextNode;
            
            if(nextNode != null)
            {
                nextNode.back = temp;
            }
            
            temp = temp.next;
        }
        
        return head;
    }
    
    public void PrintDoublyLinkedList(Node head)
    {
        while(head != null)
        {
            Console.Write($"{head.data} ->");
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
        int[] arr = {1, 1, 2, 3, 3, 4, 5, 5, 6};

        Node head = doublyLinkedList.ConvertArrayToDoublyLinkedList(arr);
        
        Node newHead = doublyLinkedList.RemoveDuplicatesFromSortedDLL(head);
        
        Console.WriteLine($"Optimal Solution: ");
        doublyLinkedList.PrintDoublyLinkedList(newHead);
    }
}

