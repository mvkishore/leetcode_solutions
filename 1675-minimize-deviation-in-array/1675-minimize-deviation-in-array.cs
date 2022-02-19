public class Solution {
    public int MinimumDeviation(int[] nums) {
        SortedSet<(int val, int indx)> heap = new SortedSet<(int val, int indx)>();
        int n = nums.Length;
        for(int i=0; i<n; i++){
            if(nums[i] % 2 == 0){
                heap.Add((nums[i], i));
            }else{
                heap.Add((nums[i]*2, i));
            }
        }
        int diff = int.MaxValue;
        while(heap.Max.val % 2 == 0){
            diff = Math.Min(diff, heap.Max.val - heap.Min.val);
            var max = heap.Max;
            heap.Remove(max);
            max.val = max.val / 2;
            heap.Add(max);
        }
        diff = Math.Min(diff, heap.Max.val - heap.Min.val);
        return diff;
    }
}