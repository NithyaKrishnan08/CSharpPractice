/*
Problem Statement: Given a linked list where every node in the linked list contains two pointers:

‘next’ which points to the next node in the list.
‘random’ which points to a random node in the list or ‘null’.
Create a ‘deep copy’ of the given linked list and return it.

Output:

Original Linked List with Random Pointers:
Data: 7, Random: 21
Data: 14, Random: 7
Data: 21, Random: 28
Data: 28, Random: 14

Brute Force Solution: 

Cloned Linked List with Random Pointers:
Data: 7, Random: 21
Data: 14, Random: 7
Data: 21, Random: 28
Data: 28, Random: 14

Optimal Solution: 

Cloned Linked List with Random Pointers:
Data: 7, Random: 21
Data: 14, Random: 7
Data: 21, Random: 28
Data: 28, Random: 14

*/

// Clone Linked List with Random and Next Pointer
using System;
using System.Collections.Generic;

// Node class to represent elements in the linked list
public class Node
{
    // Data stored in the node
    public int data;
    // Pointer to the next node
    public Node next;
    // Pointer to a random node in the list
    public Node random;

    // Constructors for Node class
    public Node() : this(0, null, null) { }
    public Node(int x) : this(x, null, null) { }
    public Node(int x, Node nextNode, Node randomNode)
    {
        data = x;
        next = nextNode;
        random = randomNode;
    }
}

public class LinkedList
{
    // Brute Force Solution - Function to clone the linked list
    public static Node CloneLL1(Node head)
    {
        if (head == null)
        {
            return null;
        }

        Node temp = head;
        // Create a dictionary to map original nodes to their corresponding copied nodes
        Dictionary<Node, Node> map = new Dictionary<Node, Node>();

        // Step 1: Create copies of each node and store them in the map
        while (temp != null)
        {
            // Create a new node with the same data as the original node
            Node newNode = new Node(temp.data);
            // Map the original node to its corresponding copied node in the map
            map[temp] = newNode;
            // Move to the next node in the original list
            temp = temp.next;
        }

        temp = head;
        // Step 2: Connect the next and random pointers of the copied nodes using the map
        while (temp != null)
        {
            // Access the copied node corresponding to the current original node
            Node copyNode = map[temp];
            // Set the next pointer of the copied node to the copied node mapped to the next node in the original list
            copyNode.next = temp.next != null ? map[temp.next] : null;
            // Set the random pointer of the copied node to the copied node mapped to the random node in the original list
            copyNode.random = temp.random != null ? map[temp.random] : null;
            // Move to the next node in the original list
            temp = temp.next;
        }

        // Return the head of the deep copied list from the map
        return map[head];
    }
    
    // Optimal solution
    // Function to insert a copy of each node in between the original nodes
    public static void InsertCopyInBetween(Node head)
    {
        Node temp = head;
        while (temp != null)
        {
            Node nextElement = temp.next;
            // Create a new node with the same data
            Node copy = new Node(temp.data);

            // Point the copy's next to the original node's next
            copy.next = nextElement;

            // Point the original node's next to the copy
            temp.next = copy;

            // Move to the next original node
            temp = nextElement;
        }
    }
    
    // Function to connect random pointers of the copied nodes
    public static void ConnectRandomPointers(Node head)
    {
        Node temp = head;
        while (temp != null)
        {
            // Access the copied node
            Node copyNode = temp.next;

            // If the original node has a random pointer
            if (temp.random != null)
            {
                // Point the copied node's random to the corresponding copied random node
                copyNode.random = temp.random.next;
            }
            else
            {
                // Set the copied node's random to null if the original random is null
                copyNode.random = null;
            }

            // Move to the next original node
            temp = temp.next.next;
        }
    }
    
    // Function to retrieve the deep copy of the linked list
    public static Node GetDeepCopyList(Node head)
    {
        Node temp = head;
        // Create a dummy node
        Node dummyNode = new Node(-1);
        // Initialize a result pointer
        Node res = dummyNode;

        while (temp != null)
        {
            // Creating a new List by pointing to copied nodes
            res.next = temp.next;
            res = res.next;

            // Disconnect and revert back to the initial state of the original linked list
            temp.next = temp.next.next;
            temp = temp.next;
        }

        // Return the deep copy of the list starting from the dummy node
        return dummyNode.next;
    }
    
    // Function to clone the linked list
    public static Node CloneLL2(Node head)
    {
        // If the original list is empty, return null
        if (head == null) return null;

        // Step 1: Insert copy of nodes in between
        InsertCopyInBetween(head);
        // Step 2: Connect random pointers of copied nodes
        ConnectRandomPointers(head);
        // Step 3: Retrieve the deep copy of the linked list
        return GetDeepCopyList(head);
    }

    // Function to print the cloned linked list
    public static void PrintClonedLinkedList(Node head)
    {
        while (head != null)
        {
            Console.Write("Data: " + head.data);
            if (head.random != null)
            {
                Console.Write(", Random: " + head.random.data);
            }
            else
            {
                Console.Write(", Random: null");
            }
            Console.WriteLine();
            // Move to the next node
            head = head.next;
        }
    }

    // Main function
    public static void Main(string[] args)
    {
        // Example linked list: 7 -> 14 -> 21 -> 28
        Node head = new Node(7);
        head.next = new Node(14);
        head.next.next = new Node(21);
        head.next.next.next = new Node(28);

        // Assigning random pointers
        head.random = head.next.next;
        head.next.random = head;
        head.next.next.random = head.next.next.next;
        head.next.next.next.random = head.next;
        
        Console.WriteLine("Original Linked List with Random Pointers:");
        PrintClonedLinkedList(head);
        Console.WriteLine();

        Console.WriteLine("Brute Force Solution: ");
        // Clone the linked list
        Node clonedList1 = CloneLL1(head);

        Console.WriteLine("\nCloned Linked List with Random Pointers:");
        PrintClonedLinkedList(clonedList1);
        Console.WriteLine();
        
        Console.WriteLine("Optimal Solution: ");

        // Clone the linked list
        Node clonedList2 = CloneLL2(head);

        Console.WriteLine("\nCloned Linked List with Random Pointers:");
        PrintClonedLinkedList(clonedList2);
    }
}
