public class MinStack {
    Stack<int> values;
    Stack<int> mins;
        
    public MinStack() {
        values = new Stack<int>();
        mins = new Stack<int>();
    }
    
    public void Push(int val) {
        if(mins.Count == 0 || mins.Peek() >= val){
            mins.Push(val);
        }
        values.Push(val);
    }
    
    public void Pop() {
        var val = values.Pop();
        if(val == mins.Peek())
            mins.Pop();
    }
    
    public int Top() {
        return values.Peek();
    }
    
    public int GetMin() {
        return mins.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */