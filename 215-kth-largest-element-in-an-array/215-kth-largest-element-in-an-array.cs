public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
        int n = nums.Length;
        for(int i=0; i<n; i++){
            queue.Enqueue(nums[i], nums[i]);
            if(queue.Count > k)
                queue.Dequeue();
        }
        return queue.Dequeue();
    }
}