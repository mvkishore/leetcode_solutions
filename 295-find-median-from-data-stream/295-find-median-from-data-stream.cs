public class MedianFinder {
    private SortedSet<(int val, long indx)> leftPart;
    private SortedSet<(int val, long indx)> rightPart;
    private long indx = 0;
    public MedianFinder() {
        leftPart = new SortedSet<(int, long)>();
        rightPart = new SortedSet<(int, long)>();
    }
    
    public void AddNum(int num) {
        if(leftPart.Count == 0){
            leftPart.Add((num, indx++));
            return;
        }
        
        var max = leftPart.Max;
        var min = (rightPart.Count > 0) ? rightPart.Min : (int.MinValue, indx++);
        
        if(num < max.val)
            leftPart.Add((num, indx++));
        else
            rightPart.Add((num, indx++));
        
        Balance();
    }
    
    private void Balance(){
        int leftLen = leftPart.Count;
        int rightLen = rightPart.Count;
        if(leftLen != rightLen){
            var diff = Math.Abs(leftLen - rightLen);
            if(diff == 1 && rightLen > leftLen) {
                var min = Pop(rightPart, MinOrMax.MIN);
                leftPart.Add(min);
            } else if(diff == 2) {
                var max = Pop(leftPart, MinOrMax.MAX);
                rightPart.Add(max);
            }
        }
    }
    public enum MinOrMax {
        MIN,
        MAX
    }
    private (int, long) Pop(SortedSet<(int, long)> heap, MinOrMax minOrmax)
    {
        var minOrMax = MinOrMax.MIN == minOrmax ? heap.Min : heap.Max;
        heap.Remove(minOrMax);
        return minOrMax;
    }
    
    public double FindMedian() {
        int leftLen = leftPart.Count;
        int rightLen = rightPart.Count;
        if(leftLen == 0)
            return 0;
        
        if(leftLen == rightLen)
            return (leftPart.Max.val + rightPart.Min.val) / 2.0;
        return leftPart.Max.val*1.0;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */