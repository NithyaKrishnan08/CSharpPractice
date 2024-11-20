/*

Problem Statement: Given the heads of two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

Examples:

Input Format: 
(Pointer/Access to the head of the two linked lists)

num1  = 243, num2 = 564

l1 = [2,4,3]
l2 = [5,6,4]

Result: sum = 807; L = [7,0,8]

Explanation: Since the digits are stored in reverse order, reverse the numbers first to get the or                                                original number and then add them as → 342 + 465 = 807.

Output:
======

Optimal Solution: 
7 ->0 ->0 ->0 ->1 ->null

*/

// Add two numbers represented as Linked Lists

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
    
    // Optimal Solution
    public Node Add2NosAsLL(Node head1, Node head2)
    {
        Node temp1 = head1, temp2 = head2;
        Node dummyNode = new Node(-1);
        Node currentNode = dummyNode;
            
        int carryOver = 0;
        
        while(temp1 != null || temp2 != null || carryOver > 0)
        {
            int sum = carryOver;
            
            if(temp1 != null)
            {
                sum = sum + temp1.data;
                temp1 = temp1.next;
            }
                
            if(temp2 != null)
            {
                sum = sum + temp2.data;
                temp2 = temp2.next;
            }
                
            Node newNode = new Node(sum % 10);
            carryOver = sum / 10;
            
            currentNode.next = newNode;
            currentNode = currentNode.next;
        }
        
        return dummyNode.next;
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
        Node head1 = linkedList.ConvertArrayToLinkedList(new int[] { 3, 5 });
        Node head2 = linkedList.ConvertArrayToLinkedList(new int[] { 4, 5, 9, 9 });

        // Testing optimal solution
        Node result = linkedList.Add2NosAsLL(head1, head2);
        
        Console.WriteLine("Optimal Solution: ");
        if(result != null)
            linkedList.PrintLinkedList(result);
        else
            Console.WriteLine("Number cannot be added to the linked list");
            
        Console.WriteLine();
    }
}

