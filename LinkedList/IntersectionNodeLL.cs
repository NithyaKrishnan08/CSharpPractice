/*

Problem Statement: Given the heads of two singly linked-lists headA and headB, return the node at which the two lists intersect. If the two linked lists have no intersection at all, return null.

Brute Force Solution: 
The intersection point: 2

Better Solution: 
The intersection point: 2

Optimal Solution: 
The intersection point: 2
*/

// Find intersection of Two Linked Lists

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
    public Node IntersectionNodeLL1(Node head1, Node head2)
    {
        if (head1 == null || head2 == null) return null;
        
        var visitedNodes = new HashSet<Node>();
        
        // First traversal
        Node temp = head1;
        while(temp != null)
        {
            visitedNodes.Add(temp);
            temp = temp.next;
        }
        
        // Second traversal
        temp = head2;
        while(temp != null)
        {
            if (visitedNodes.Contains(temp))
                return temp;
            temp = temp.next;
        }
        
        return null;
    }
    
    // Better Solution - Differnce in the length
    public Node IntersectionNodeLL2(Node head1, Node head2)
    {
        if (head1 == null || head2 == null) return null;
        
        Node temp1 = head1, temp2 = head2;
        int len1 = 0, len2 = 0;
        
        // Find the length of the two linked list
        while(temp1 != null) // O(N1)
        {
            len1++;
            temp1 = temp1.next;
        }
        
        while(temp2 != null) // O(N2)
        {
            len2++;
            temp2 = temp2.next;
        }
        
        // Difference in the length of LL
        if(len1 > len2)
            return FindIntersectionAfterAlignment(head2, head1, len1 - len2);
        else
            return FindIntersectionAfterAlignment(head1, head2, len2 - len1);
    }
    
    public Node FindIntersectionAfterAlignment(Node shorter, Node longer, int diff)
    {
        while(diff > 0) // O(N2-N1)
        {
            longer = longer.next;
            diff--;
        }
        
        while(shorter != null && longer != null) // O(N1)
        {
            if(shorter == longer)
                return shorter;
            shorter = shorter.next;
            longer = longer.next;
        }
        
        return null;
    }
    
    // Optimal solution
    public Node IntersectionNodeLL3(Node head1, Node head2)
    {
        if (head1 == null || head2 == null) return null;
        
        Node temp1 = head1, temp2 = head2;
        
        while(temp1 != temp2)
        {
            temp1 = temp1.next;
            temp2 = temp2.next;
            
            if(temp1 == temp2)
                return temp1;
            
            if(temp1 == null)
                temp1 = head2;
            
            if(temp2 == null)
                temp2 = head1;
        }
        
        return temp1;
    }
    
    public void PrintLinkedList(Node head)
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
        LinkedList linkedList = new LinkedList();
        
        // Creating two linked lists that intersect
        Node head1 = linkedList.ConvertArrayToLinkedList(new int[] { 1, 3, 1, 2, 4 });
        Node head2 = linkedList.ConvertArrayToLinkedList(new int[] { 3, 2 });
        
        // Creating an intersection at node with value 2
        Node intersection = head1;
        while (intersection != null && intersection.data != 2)
        {
            intersection = intersection.next;
        }
        
        // Attach the intersection node to the second list
        Node temp = head2;
        while (temp.next != null)
        {
            temp = temp.next;
        }
        temp.next = intersection;

        // Testing brute force solution
        Node answerNode1 = linkedList.IntersectionNodeLL1(head1, head2);
        
        Console.WriteLine("Brute Force Solution: ");
        if(answerNode1 != null)
            Console.WriteLine($"The intersection point: {answerNode1.data}");
        else
            Console.WriteLine("There is no intersection point");
            
        Console.WriteLine();
        
        // Testing better solution
        Node answerNode2 = linkedList.IntersectionNodeLL2(head1, head2);
        
        Console.WriteLine("Better Solution: ");
        if(answerNode2 != null)
            Console.WriteLine($"The intersection point: {answerNode2.data}");
        else
            Console.WriteLine("There is no intersection point");
            
        Console.WriteLine();
        
        // Testing optimal solution
        Node answerNode3 = linkedList.IntersectionNodeLL3(head1, head2);
        
        Console.WriteLine("Optimal Solution: ");
        if(answerNode3 != null)
            Console.WriteLine($"The intersection point: {answerNode3.data}");
        else
            Console.WriteLine("There is no intersection point");
            
        Console.WriteLine();
    }
}


