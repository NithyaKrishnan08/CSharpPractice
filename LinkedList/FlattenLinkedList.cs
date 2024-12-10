/*

Problem Statement: Given a linked list containing ‘N’ head nodes where every node in the linked list contains two pointers:

‘Next’ points to the next node in the list
‘Child’ pointer to a linked list where the current node is the head
Each of these child linked lists is in sorted order and connected by a 'child' pointer. Your task is to flatten this linked list such that all nodes appear in a single layer or level in a 'sorted order'.

Original linked list:
5 -> 14
10 -> 4
12 -> 20 -> 13
7 -> 17
Brute Force Solution
Flattened linked list: 
4 5 7 10 12 13 14 17 20 

Optimal Solution
Flattened linked list: 
5 7 10 4 12 14 17 20 13

*/

// Flattening a Linked List

using System;
using System.Collections.Generic;

public class Node
{
    public int data;
    public Node next;
    public Node child;
    
    public Node() : this(0, null, null) { }
    public Node(int x) : this(x, null, null) { }
    public Node(int x, Node nextNode, Node childNode)
    {
        data = x;
        next = nextNode;
        child = childNode;
    }
}

public class LinkedList
{
    public Node ConvertArrToLinkedList(List<int> arr)
    {
        if (arr.Count == 0)
            return null;
            
        Node dummyNode = new Node(-1);
        Node temp = dummyNode;
        
        for(int i = 0; i < arr.Count; i++)
        {
            temp.child = new Node(arr[i]);
            temp = temp.child;
        }
        return dummyNode.child;
    }
    
    // Brute Force Solution
    public Node FlattenLinkedListLL1(Node head)
    {
        // No element or only one element in the LL
        if(head == null)
            return head;
        
        List<int> arr = new List<int>();
        Node temp = head;
        
        while (temp != null)
        {
            Node t2 = temp;
            while (t2 != null)
            {
                // Store each node's data in the list
                arr.Add(t2.data);
                // Move to the next child node
                t2 = t2.child;
            }
            temp = temp.next;
        }
        
        arr.Sort();
        
        return ConvertArrToLinkedList(arr);
    }
    
    public Node Merge(Node list1, Node list2)
    {
        // Create a dummy node as a placeholder for the result
        Node dummyNode = new Node(-1);
        Node res = dummyNode;

        // Merge the lists based on data values
        while (list1 != null && list2 != null)
        {
            if (list1.data < list2.data)
            {
                res.child = list1;
                res = list1;
                list1 = list1.child;
            }
            else
            {
                res.child = list2;
                res = list2;
                list2 = list2.child;
            }
            res.next = null;
        }

        // Connect the remaining elements if any
        if (list1 != null)
        {
            res.child = list1;
        }
        else
        {
            res.child = list2;
        }

        // Break the last node's link to prevent cycles
        if (dummyNode.child != null)
        {
            dummyNode.child.next = null;
        }

        return dummyNode.child;
    }
    
    // Optimal Solution
    public Node FlattenLinkedList2(Node head)
    {
        // If head is null or there is no next node, return head
        if (head == null || head.next == null)
        {
            return head;
        }

        // Recursively flatten the rest of the linked list
        Node mergedHead = FlattenLinkedList2(head.next);
        head = Merge(head, mergedHead);
        return head;
    }
    
    public void PrintLinkedList(Node head)
    {
        while(head != null)
        {
            Console.Write(head.data + " ");
            head = head.child;
        }
        Console.WriteLine();
    }
    
    public void PrintOriginalLinkedList(Node head, int depth)
    {
        while (head != null)
        {
            Console.Write(head.data);

            // If child exists, recursively print it with indentation
            if (head.child != null)
            {
                Console.Write(" -> ");
                PrintOriginalLinkedList(head.child, depth + 1);
            }

            // Add vertical bars for each level in the grid
            if (head.next != null)
            {
                Console.WriteLine();
                for (int i = 0; i < depth; ++i)
                {
                    Console.Write("| ");
                }
            }
            head = head.next;
        }
    }
}

class Program
{
    static void Main()
    {
        LinkedList linkedList = new LinkedList();
        
        Node head = new Node(5);
        head.child = new Node(14);

        head.next = new Node(10);
        head.next.child = new Node(4);

        head.next.next = new Node(12);
        head.next.next.child = new Node(20);
        head.next.next.child.child = new Node(13);

        head.next.next.next = new Node(7);
        head.next.next.next.child = new Node(17);
        
        Console.WriteLine("Original linked list:");
        linkedList.PrintOriginalLinkedList(head, 0);
        
        Console.WriteLine();
        
        Console.WriteLine("Brute Force Solution");
        Node flattened1 = linkedList.FlattenLinkedListLL1(head);
        Console.WriteLine("Flattened linked list: ");
        linkedList.PrintLinkedList(flattened1);
        
        Console.WriteLine();
        
        Console.WriteLine("Optimal Solution");
        Node flattened2 = linkedList.FlattenLinkedList2(head);
        Console.WriteLine("Flattened linked list: ");
        linkedList.PrintLinkedList(flattened2);
    }
}
