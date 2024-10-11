/// <summary>
/// A priority queue implementation
/// </summary>
public class PriorityQueue
{
    private readonly List<PriorityItem> _queue = new();
   /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public int Length => _queue.Count;

    //// <summary>
    //// Add an item to the queue with a given priority
    /// </summary>
    /// <param name="value">The value to add</param>
    /// <param name="priority">The priority of the item</param>
    public void Enqueue(string value, int priority)
    {
        var item = new PriorityItem(value, priority);
        _queue.Add(item);
    }

    /// <summary>
    /// Remove and return the highest priority item from the queue
    /// </summary>
    /// <returns>The value of the highest priority item</returns>
    public string Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        int highestPriorityIndex = 0;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[highestPriorityIndex].Priority)
            {
                highestPriorityIndex = i;
            }
        }

        var highestPriorityItem = _queue[highestPriorityIndex];
        _queue.RemoveAt(highestPriorityIndex);
        return highestPriorityItem.Value;
    }

    /// <summary>
    /// Check if the queue is empty
    /// </summary>
    /// <returns>True if the queue is empty, false otherwise</returns>
    public bool IsEmpty()
    {
        return Length == 0;
    }

    /// <summary>
    /// Get a string representation of the queue
    /// </summary>
    /// <returns>A string representing the queue</returns>
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

/// <summary>
/// Represents an item in the priority queue
/// </summary>
public class PriorityItem
{
    public string Value { get; }
    public int Priority { get; }

    public PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"({Value}, {Priority})";
    }
}






