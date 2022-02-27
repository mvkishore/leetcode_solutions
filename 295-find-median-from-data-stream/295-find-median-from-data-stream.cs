public class MedianFinder {
    PriorityQueue<int, int> maxHeap;
    PriorityQueue<int, int> minHeap;
    public MedianFinder() {
        maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b)=> b.CompareTo(a)));
        minHeap = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        if(maxHeap.Count == 0){
            maxHeap.Enqueue(num, num);
            return;
        }
        
        if(minHeap.Count > 0 && minHeap.Peek() < num)
            minHeap.Enqueue(num,num);
        else
            maxHeap.Enqueue(num, num);
        
        BalanceHeaps();
    }
    
    private void BalanceHeaps(){
        if(Math.Abs(maxHeap.Count - minHeap.Count) > 1){
            if(maxHeap.Count > minHeap.Count){
                var num = maxHeap.Dequeue();
                minHeap.Enqueue(num, num);
            } else {
                var num = minHeap.Dequeue();
                maxHeap.Enqueue(num, num);
            }
        }
        
        if(minHeap.Count > maxHeap.Count){
            var num = minHeap.Dequeue();
            maxHeap.Enqueue(num, num);
        }
    }
    
    public double FindMedian() {
        if(maxHeap.Count == minHeap.Count)
        {
            return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
        }
        return 1.0 * maxHeap.Peek();
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */