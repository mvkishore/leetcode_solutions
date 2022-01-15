public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        SortedSet<(int ele, int idx)> heap = new SortedSet<(int ele, int idx)>();
        int i=0;
        foreach(var num in nums){
            if(heap.Count == k){
                if(heap.Min.ele < num)
                    heap.Remove(heap.Min);
                else
                    continue;
            }
            heap.Add((num, i++));
        }
        return heap.Min.ele;
    }
}

//[6,6,5,5,6,6,3,2,1,3]