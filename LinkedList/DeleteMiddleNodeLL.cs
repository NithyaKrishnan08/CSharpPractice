/*

Problem Statement: Given the head of a linked list of integers, delete the middle node of the linked list and return the modified head. However, if the linked list has an even number of nodes, delete the second middle node.

Brute Force Solution: 
1
2
3
5
6


Optimal Solution: 
1
2
3
5
6

*/

// Delete the Middle Node of the Linked List

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
    
    // Brute Force Solution
    public Node DeleteMiddleNodeLL1(Node head)
    {
        // If no element or only one element
        if(head == null || head.next == null)
            return null;
        
        int count = 0;
        Node temp = head;

        while(temp != null)
        {
            count++;
            temp = temp.next;
        }
        
        int reqCount = count / 2;

        temp = head;
        
        while(temp != null)
        {
            reqCount--;
            if(reqCount == 0)
            {
                temp.next = temp.next.next;
                break;
            }
            temp = temp.next;
        }
        return head;
    }
    
    // Optimal Solution
    public Node DeleteMiddleNodeLL2(Node head)
    {
        // If no element or only one element
        if(head == null || head.next == null)
            return null;
        
        Node fast = head, slow = head, prev = null;
        
        while(fast != null && fast.next != null)
        {
            prev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
    
        if(prev != null)
            prev.next = slow.next;
        
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
        int[] arr1 = {1, 2, 3, 4, 5, 6};
        int[] arr2 = {1, 2, 3, 4, 5, 6};

        Node head1 = linkedList.ConvertArrayToLinkedList(arr1);
        
        Console.WriteLine("Brute Force Solution: ");
        Node result1 = linkedList.DeleteMiddleNodeLL1(head1);
        if(result1 != null)
            linkedList.PrintLinkedList(result1);
        else
            Console.WriteLine("The linked list node could not be deleted");
            
        Console.WriteLine();
        
        Node head2 = linkedList.ConvertArrayToLinkedList(arr2);
        
        Console.WriteLine("Optimal Solution: ");
        Node result2 = linkedList.DeleteMiddleNodeLL2(head2);
        if(result2 != null)
            linkedList.PrintLinkedList(result2);
        else
            Console.WriteLine("The linked list node could not be deleted");
    }
}



