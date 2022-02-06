public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        SortedSet<(int val, int idx)> heap = new SortedSet<(int val, int idx)>();
        int n = nums.Length;
        for(int i=0; i<k; i++)
            heap.Add((nums[i], i));
        int[] results = new int[n - k + 1];
        int left = 0, right = k;
        
        while(right < n){
            var max = heap.Max;
            results[left] = max.val;
            
            heap.Remove((nums[left], left));
            heap.Add((nums[right], right));
            left++;
            right++;
        }
        results[left] = heap.Max.val;
        return results;
    }
}