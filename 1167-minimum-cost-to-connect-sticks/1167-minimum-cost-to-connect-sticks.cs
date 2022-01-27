public class Solution {
    public int ConnectSticks(int[] sticks) {
        SortedSet<(int val, int idx)> heap = new SortedSet<(int val, int idx)>();
        int i=0, n = sticks.Length;
        
        if(n <= 1)
            return 0;
        
        foreach(var stick in sticks)
            heap.Add((stick, i++));
        int res = 0;
        while(heap.Count > 1){
            var min1 = heap.Min;
            heap.Remove(min1);
            var min2 = heap.Min;
            heap.Remove(min2);
            
            (int val, int idx) newStick = (min1.val + min2.val, min1.idx);
            res += newStick.val;
            heap.Add(newStick);
        }
        return res;
    }
}