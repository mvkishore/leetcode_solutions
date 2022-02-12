public class MovingAverage {
    LinkedList<int> window;
    double total;
    int len;
    int capacity;
    public MovingAverage(int size) {
        window = new LinkedList<int>();
        capacity = size;
    }
    
    public double Next(int val) {
        total += val;
        window.AddLast(new LinkedListNode<int>(val));
        len++;
        if(len > capacity)
        {
            total -= window.First.Value;
            window.RemoveFirst();
            len--;
        }
        return total / len;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */