/*

Problem Statement: Given a linked list, sort its nodes based on the data value in them. Return the head of the sorted linked list.

Brute Force Solution: 
1
2
3
4
5
6
7
8
9


Optimal Solution: 
1
2
3
4
5
6
7
8
9

*/

// Sort a Linked List

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
    public Node SortLL1(Node head)
    {
        // If no element or only one element
        if(head == null || head.next == null)
            return head;
        
        List<int> list = new List<int>();
        
        Node temp = head;
        while(temp != null)
        {
            list.Add(temp.data);
            temp = temp.next;
        }
        
        list.Sort();
        int[] numArray = list.ToArray();

        int i = 0;
        temp = head;
        while(temp != null)
        {
            temp.data = numArray[i];
            i = i + 1;
            temp = temp.next;
        }
        return head;
    }
    
    // Optimal Solution
    public Node MergeSortLL(Node head)
    {
        // If no element or only one element
        if(head == null || head.next == null)
            return head;
        
        Node middle = FindMiddleElementLL(head);
        
        Node leftHead = head;
        Node rightHead = middle.next;
        middle.next = null;
        
        leftHead = MergeSortLL(leftHead);
        rightHead = MergeSortLL(rightHead);
        
        return MergeSortLL(leftHead, rightHead);
    }
    
    public Node FindMiddleElementLL(Node head)
    {
        Node slow = head, fast = head.next;
        while(fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        return slow;
    }
    
    public Node MergeSortLL(Node list1, Node list2)
    {
        Node dummyNode = new Node(-1);
        Node temp = dummyNode;
        
        while(list1 != null && list2 != null)
        {
            if(list1.data < list2.data)
            {
                temp.next = list1;
                list1 = list1.next;
            }
            else
            {
                temp.next = list2;
                list2 = list2.next;
            }
            temp = temp.next;
        }
        
        if(list1 != null)
            temp.next = list1;
        else
            temp.next = list2;

        return dummyNode.next;
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
        int[] arr1 = {9, 4, 2, 6, 7, 1, 8, 5, 3};
        int[] arr2 = {9, 4, 2, 6, 7, 1, 8, 5, 3};

        Node head1 = linkedList.ConvertArrayToLinkedList(arr1);
        
        Console.WriteLine("Brute Force Solution: ");
        Node result1 = linkedList.SortLL1(head1);
        if(result1 != null)
            linkedList.PrintLinkedList(result1);
        else
            Console.WriteLine("The linked list node could not be sorted");
            
        Console.WriteLine();
        
        Node head2 = linkedList.ConvertArrayToLinkedList(arr2);
        
        Console.WriteLine("Optimal Solution: ");
        Node result2 = linkedList.MergeSortLL(head2);
        if(result2 != null)
            linkedList.PrintLinkedList(result2);
        else
            Console.WriteLine("The linked list node could not be sorted");
    }
}


