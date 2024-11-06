/*

Brute Force Solution: 
The linked list is a palindrome

Optimal Solution: 
The linked list is a palindrome

*/

// To find whether the linked list is a palindrome

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
    public bool CheckPalindromeLL1(Node head)
    {
        if(head == null || head.next == null)
            return true;
            
        Stack<int> myStack = new Stack<int>();
        
        Node temp = head;
        
        // Step 1: To push data into the stack
        while(temp != null)
        {
            myStack.Push(temp.data);
            temp = temp.next;
        }
        
        // Step 2: To compare data from stack to LL
        Node temp1 = head;
        
        while(temp1 != null)
        {
            if(temp1.data != myStack.Pop())
                return false;
            temp1 = temp1.next;
        }
        return true;
    }
    
    // Optimal Solution
    public bool CheckPalindromeLL2(Node head)
    {
        if(head == null || head.next == null)
            return true;

        Node slow = head, fast = head;
        
        // Step 1: To find the first middle element - O(N/2)
        while(fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        // Step 2: Reverse the second half of the LL - O(N/2)
        Node newHead = ReverseLL(slow.next);
        
        // Step 3: To compare data from two parts of the LL - O(N/2)
        Node first = head;
        Node second = newHead;
        
        while(second != null)
        {
            if(first.data != second.data)
            {
                second = ReverseLL(newHead);
                return false;
            }
                
            first = first.next;
            second = second.next;
        }
        
        // Step 4: To reverse the second half again - O(N/2)
        second = ReverseLL(newHead);
        return true;
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
        int[] arr = {1, 2, 3, 2, 1};

        Node head = linkedList.ConvertArrayToLinkedList(arr);
        
        Console.WriteLine("Brute Force Solution: ");
        bool result1 = linkedList.CheckPalindromeLL1(head);
        if(result1 == true)
            Console.WriteLine($"The linked list is a palindrome");
        else
            Console.WriteLine("The linked list is not a palindrome");
            
        Console.WriteLine();
        
        Console.WriteLine("Optimal Solution: ");
        bool result2 = linkedList.CheckPalindromeLL2(head);
        if(result2 == true)
            Console.WriteLine($"The linked list is a palindrome");
        else
            Console.WriteLine("The linked list is not a palindrome");
    }
}
