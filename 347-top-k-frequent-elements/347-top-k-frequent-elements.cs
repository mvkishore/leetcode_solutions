public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> frequencies = new Dictionary<int, int>();
        foreach(var num in nums){
            if(!frequencies.ContainsKey(num))
                frequencies.Add(num, 0);
            frequencies[num]++;
        }
        SortedSet<(int freq, int ele)> heap = new SortedSet<(int freq, int ele)>();
        
        foreach(var numFreq in frequencies){
            if(heap.Count == k)
            {
                var min = heap.Min;
                if(min.freq < numFreq.Value)
                    heap.Remove(min);
                else continue;
            }
            heap.Add((numFreq.Value, numFreq.Key));
        }
        
        int i=0;
        int[] res = new int[k];
        while(heap.Count > 0){
            res[i++] = heap.Min.ele;
            heap.Remove(heap.Min);
        }
        return res;
    }
}