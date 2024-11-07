/*

Problem Statement: Given a linked list and an integer N, the task is to delete the Nth node from the end of the linked list and print the updated linked list.

Brute Force Solution: 
1
2
3
4
6


Optimal Solution: 
1
2
3
4
6

*/

// Remove N-th node from the end of a Linked List

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
    public Node DeleteNthNodefromEndLL1(Node head, int n)
    {
        // If no element
        if(head == null)
            return null;
        
        int count = 0;
        Node temp = head;

        while(temp != null)
        {
            count++;
            temp = temp.next;
        }
        
        // Head will be deleted
        if(count == n)
        {
            Node newHead = head.next;
            head = null;
            return newHead;
        }
        
        int reqCount = count - n;
        temp = head;
        
        while(temp != null)
        {
            reqCount--;
            if(reqCount == 0)
                break;
            temp = temp.next;
        }
        
        Node delNode = temp.next;
        temp.next = temp.next.next;
        delNode = null;
        
        return head;
    }
    
    // Optimal Solution
    public Node DeleteNthNodefromEndLL2(Node head, int n)
    {
        // If no element
        if(head == null)
            return null;
        
        Node fast = head, slow = head;
        for(int i = 0;i < n; i++)
        {
            fast = fast.next;
        }
        
        // If head has to be deleted
        if(fast == null)
        {
            return head.next;
        }
        
        while(fast.next != null)
        {
            slow = slow.next;
            fast = fast.next;
        }
        
        Node delNode = slow.next;
        slow.next = slow.next.next;
        delNode = null;
        
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
        int n = 2;

        Node head1 = linkedList.ConvertArrayToLinkedList(arr1);
        
        Console.WriteLine("Brute Force Solution: ");
        Node result1 = linkedList.DeleteNthNodefromEndLL1(head1, n);
        if(result1 != null)
            linkedList.PrintLinkedList(result1);
        else
            Console.WriteLine("The linked list node could not be deleted");
            
        Console.WriteLine();
        
        Node head2 = linkedList.ConvertArrayToLinkedList(arr2);
        
        Console.WriteLine("Optimal Solution: ");
        Node result2 = linkedList.DeleteNthNodefromEndLL2(head2, n);
        if(result2 != null)
            linkedList.PrintLinkedList(result2);
        else
            Console.WriteLine("The linked list node could not be deleted");
            
        Console.WriteLine();
    }
}



