/*

Deleting 10 of the doubly linked list
4 ->6 ->

*/

// Delete all occurences of a key in DLL

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
    
    public Node DeleteAllOccurencesOfKeyDLL(Node head, int key)
    {
        Node temp = head;
        
        while(temp != null)
        {
            if(temp.data == key)
            {
                if(temp == head)
                {
                    head = head.next;
                }
                
                Node nextNode = temp.next;
                Node prevNode = temp.back;
                
                if(nextNode != null)
                    nextNode.back = prevNode;
                    
                if(prevNode != null)
                    prevNode.next = nextNode;
                    
                temp = nextNode;
            }
            else
            {
                temp = temp.next;
            }
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
        int[] arr = {10, 4, 10, 10, 6, 10};
        int key = 10;

        Node head = doublyLinkedList.ConvertArrayToDoublyLinkedList(arr);
        Node newHead = doublyLinkedList.DeleteAllOccurencesOfKeyDLL(head, key);
        
        Console.WriteLine($"Deleting {key} of the doubly linked list");
        doublyLinkedList.PrintDoublyLinkedList(newHead);
    }
}


