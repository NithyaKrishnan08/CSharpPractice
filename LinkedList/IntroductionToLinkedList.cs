/*

8

*/

// Understanding Linked List

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

class Program
{
    static void Main()
    {
        int[] arr = {2, 5, 6, 8};

        Node y = new Node(arr[3]);
        Console.WriteLine(y.data);
    }
}
