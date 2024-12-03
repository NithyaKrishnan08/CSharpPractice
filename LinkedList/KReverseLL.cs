/*

Problem Statement: Given the head of a singly linked list of `n` nodes and an integer `k`, where k is less than or equal to `n`. Your task is to reverse the order of each group of `k` consecutive nodes, if `n` is not divisible by `k`, then the last group of remaining nodes should remain unchanged.

Original Linked List: 
5 4 3 7 9 2 
Reversed Linked List: 
7 3 4 5 9 2

*/

// Reverse Linked List in groups of Size K

using System;

public class Node
{
    public int Data;
    public Node Next;

    public Node(int data, Node next)
    {
        Data = data;
        Next = next;
    }

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    public static Node ReverseLinkedList(Node head)
    {
        Node temp = head;
        Node prev = null;

        while (temp != null)
        {
            Node front = temp.Next;
            temp.Next = prev;
            prev = temp;
            temp = front;
        }

        return prev;
    }

    public static Node GetKthNode(Node temp, int k)
    {
        k -= 1;

        while (temp != null && k > 0)
        {
            k--;
            temp = temp.Next;
        }

        return temp;
    }

    public static Node KReverse(Node head, int k)
    {
        Node temp = head;
        Node prevLast = null;

        while (temp != null)
        {
            Node kThNode = GetKthNode(temp, k);

            if (kThNode == null)
            {
                if (prevLast != null)
                {
                    prevLast.Next = temp;
                }
                break;
            }

            Node nextNode = kThNode.Next;
            kThNode.Next = null;
            ReverseLinkedList(temp);

            if (temp == head)
            {
                head = kThNode;
            }
            else
            {
                prevLast.Next = kThNode;
            }

            prevLast = temp;
            temp = nextNode;
        }

        return head;
    }

    public static void PrintLinkedList(Node head)
    {
        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.Data + " ");
            temp = temp.Next;
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        Node head = new Node(5);
        head.Next = new Node(4);
        head.Next.Next = new Node(3);
        head.Next.Next.Next = new Node(7);
        head.Next.Next.Next.Next = new Node(9);
        head.Next.Next.Next.Next.Next = new Node(2);

        Console.WriteLine("Original Linked List: ");
        PrintLinkedList(head);

        head = KReverse(head, 4);

        Console.WriteLine("Reversed Linked List: ");
        PrintLinkedList(head);
    }
}
