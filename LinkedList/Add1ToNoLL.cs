/*

Problem statement
You're given a positive integer represented in the form of a singly linked-list of digits. The length of the number is 'n'.

Add 1 to the number, i.e., increment the given number by one.

The digits are stored such that the most significant digit is at the head of the linked list and the least significant digit is at the tail of the linked list.

Example:
Input: Initial Linked List: 1 -> 5 -> 2

Output: Modified Linked List: 1 -> 5 -> 3

Explanation: Initially the number is 152. After incrementing it by 1, the number becomes 153.

Output:
======

Brute Force Solution: 
1 ->0 ->0 ->0 ->null

Optimal Solution: 
1 ->0 ->0 ->0 ->null

*/

// Add one to a number represented as Linked List

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
        if (arr.Length == 0) return null;
        
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
    public Node Add1ToNoLL1(Node head)
    {
        if (head == null || head.next == null)
            return head;
        
        head = ReverseLL(head);
        
        Node temp = head;
        int carryOver = 1;
        
        // Traversing through LL
        while(temp != null)
        {
            temp.data = temp.data + carryOver;
            if(temp.data < 10)
            {
                carryOver = 0;
                break;
            }
            else
            {
                temp.data = 0;
                carryOver = 1;
            }
            temp = temp.next;
        }
        
        // If value left in carryOver
        if(carryOver == 1)
        {
            Node newNode = new Node(1);
            head = ReverseLL(head);
            newNode.next = head;
            return newNode;
        }
        
        head = ReverseLL(head);
        return head;
    }
    
    public Node ReverseLL(Node head)
    {
        // No element or only one element in the LL
        if(head == null || head.next == null)
            return head;
        
        Node temp = head;
        Node prev = null, front = null;
        
        while(temp != null)
        {
            front = temp.next;
            temp.next = prev;
            prev = temp;
            temp = front;
        }
        
        return prev;
    }
    
    // Optimal Solution
    public Node Add1ToNoLL2(Node head)
    {
        if (head == null || head.next == null)
            return head;
            
        int carryOver = Add1ToNode(head);
        
        // If value left in carryOver
        if(carryOver == 1)
        {
            Node newNode = new Node(1);
            newNode.next = head;
            return newNode;
        }
        
        return head;
    }
    
    public int Add1ToNode(Node temp)
    {
        if (temp == null)
            return 1;
            
        int carryOver = Add1ToNode(temp.next);
        temp.data = temp.data + carryOver;
        
        if(temp.data < 10)
            return 0;
            
        temp.data = 0;
        return 1;
    }
    
    public void PrintLinkedList(Node head)
    {
        while(head != null)
        {
            Console.Write($"{head.data} ->");
            head = head.next;
        }
        Console.Write($"null");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        LinkedList linkedList = new LinkedList();
        
        // Creating linked lists that intersect
        Node head1 = linkedList.ConvertArrayToLinkedList(new int[] { 9, 9, 9 });
        Node head2 = linkedList.ConvertArrayToLinkedList(new int[] { 9, 9, 9 });

        // Testing brute force solution
        Node result1 = linkedList.Add1ToNoLL1(head1);
        
        Console.WriteLine("Brute Force Solution: ");
        if(result1 != null)
            linkedList.PrintLinkedList(result1);
        else
            Console.WriteLine("Number cannot be added to the linked list");
            
        Console.WriteLine();
        
        // Testing optimal solution
        Node result2 = linkedList.Add1ToNoLL2(head2);
        
        Console.WriteLine("Optimal Solution: ");
        if(result2 != null)
            linkedList.PrintLinkedList(result2);
        else
            Console.WriteLine("Number cannot be added to the linked list");
            
        Console.WriteLine();
    }
}


