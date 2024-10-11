using System.Collections;
using System.Collections.Generic;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e., the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        
        Node newNode = new(value);
       
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
       
        else
        {
            newNode.Next = _head; 
            _head.Prev = newNode; 
            _head = newNode; 
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e., the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // Problem 1: Implement InsertTail
        Node newNode = new(value);

        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail; 
            _tail.Next = newNode; 
            _tail = newNode; 
        }
    }

    /// <summary>
    /// Remove the first node (i.e., the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail
        // to null resulting in an empty list. This condition will also
        // cover an empty list. It's okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; 
            _head = _head.Next; 
        }
    }

    /// <summary>
    /// Remove the last node (i.e., the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // Problem 2: Implement RemoveTail
        if (_tail is null)
        {
            return;
        }

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Prev; 
            if (_tail != null)
            {
                _tail.Next = null; 
            }
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the
        
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'newValue'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; 
                    newNode.Next = curr.Next; 
                    curr.Next!.Prev = newNode; 
                    curr.Next = newNode; 
                }

                return; 
            }

            curr = curr.Next; 
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // Problem 3: Implement Remove
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _head)
                {
                   
                    RemoveHead();
                }
                else if (curr == _tail)
                {
                    
                    RemoveTail();
                }
                else
                {
                    
                    curr.Prev!.Next = curr.Next; 
                    curr.Next.Prev = curr.Prev; 
                }

                return; 
            }

            curr = curr.Next; 
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // Problem 4: Implement Replace
        Node? curr = _head; 

        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue; 
            }

            curr = curr.Next; 
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // Call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; 
        while (curr is not null)
        {
            yield return curr.Data; 
            curr = curr.Next; 
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        // Problem 5: Implement Reverse
        var curr = _tail; 
        while (curr is not null)
        {
            yield return curr.Data; 
            curr = curr.Prev; 
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public bool HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public bool HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }

    /// <summary>
    /// Inner class to represent a node in the linked list.
    /// </summary>
    private class Node
    {
        public int Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
