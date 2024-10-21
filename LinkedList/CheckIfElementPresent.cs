/*

The element 1 exists in the linked list.

*/

// Search if an element exists in the linked list

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
    
    public int CheckIfElementPresent(Node head, int value)
    {
        Node temp = head;
        
        while(temp != null)
        {
            if(temp.data == value)
                return 1;
            temp = temp.next;
        }
        
        return 0;
    }
}

class Program
{
    static void Main()
    {
        LinkedList linkedList = new LinkedList();
        int[] arr = {2, 5, 6, 8};

        Node head = linkedList.ConvertArrayToLinkedList(arr);
        
        int result = linkedList.CheckIfElementPresent(head, 5);
        if(result == 1)
            Console.WriteLine($"The element {result} exists in the linked list.");
        else
            Console.WriteLine($"The element {result} does not exist in the linked list.");
    }
}
