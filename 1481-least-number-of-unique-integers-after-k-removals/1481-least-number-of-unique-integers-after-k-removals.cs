public class Solution {
    public int FindLeastNumOfUniqueInts(int[] arr, int k) {
        Dictionary<int, int> counter = new Dictionary<int, int>();
        foreach(var n in arr){
            if(!counter.ContainsKey(n))
                counter.Add(n, 0);
            counter[n]++;
        }
        
        SortedSet<(int count, int num)> heap = new SortedSet<(int count, int num)>();
        foreach(var count in counter){
            heap.Add((count.Value, count.Key));
        }
        
        while(k > 0 && heap.Count > 0){
            var min = heap.Min;
            if(k - min.count >= 0){
                heap.Remove(min);
                k = k - min.count;
            } else break;
        }
        
        return heap.Count;
    }
}