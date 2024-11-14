/*

Brute Force Solution: 
0
0
0
1
1
1
2
2


Optimal Solution: 
0
0
0
1
1
1
2
2

*/

// Sort a Linked List of 0s, 1s and 2s by changing links

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
    public Node Sort012LL1(Node head)
    {
        // If no element or only one element
        if(head == null || head.next == null)
            return head;
        
        int count0 = 0, count1 = 0, count2 = 0;
        
        // Finding the count of 0s, 1s and 2s
        Node temp = head;
        while(temp != null)
        {
            if(temp.data == 0)
                count0++;
            else if(temp.data == 1)
                count1++;
            else
                count2++;
            temp = temp.next;
        }
        
        // Replacing 0s, 1s and 2s
        temp = head;
        while(temp != null)
        {
            if(count0 > 0)
            {
                temp.data = 0;
                count0--;
            }
            else if(count1 > 0)
            {
                temp.data = 1;
                count1--;
            }
            else
            {
                temp.data = 2;
                count2--;
            }
            temp = temp.next;
        }
        return head;
    }
    
    // Optimal Solution
    public Node Sort012LL2(Node head)
    {
        // If no element or only one element
        if(head == null || head.next == null)
            return head;
        
        Node zeroHead = new Node(-1), oneHead = new Node(-1), twoHead = new Node(-1);
        Node zero = zeroHead, one = oneHead, two = twoHead;
        
        Node temp = head;
        while(temp != null)
        {
            if(temp.data == 0)
            {
                zero.next = temp;
                zero = temp;
            }
            else if(temp.data == 1)
            {
                one.next = temp;
                one = temp;
            }
            else
            {
                two.next = temp;
                two = temp;
            }
            temp = temp.next;
        }
        
        if(oneHead.next != null)
            zero.next = oneHead.next;
        else
            zero.next = twoHead.next;
        
        one.next = twoHead.next;
        two.next = null;
        
        Node newHead = zeroHead.next;
        return newHead;
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
        int[] arr1 = {1, 2, 0, 0, 2, 1, 0, 1};
        int[] arr2 = {1, 2, 0, 0, 2, 1, 0, 1};

        Node head1 = linkedList.ConvertArrayToLinkedList(arr1);
        
        Console.WriteLine("Brute Force Solution: ");
        Node result1 = linkedList.Sort012LL1(head1);
        if(result1 != null)
            linkedList.PrintLinkedList(result1);
        else
            Console.WriteLine("The linked list node could not be sorted");
            
        Console.WriteLine();
        
        Node head2 = linkedList.ConvertArrayToLinkedList(arr2);
        
        Console.WriteLine("Optimal Solution: ");
        Node result2 = linkedList.Sort012LL2(head2);
        if(result2 != null)
            linkedList.PrintLinkedList(result2);
        else
            Console.WriteLine("The linked list node could not be sorted");
    }
}


