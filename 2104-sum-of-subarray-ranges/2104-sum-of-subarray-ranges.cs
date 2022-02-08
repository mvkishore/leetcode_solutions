/*
https://leetcode.com/problems/sum-of-subarray-ranges/discuss/1624268/Reformulate-Problem-O(n)
from votrubac idea,
The solution for this problem can be formulated as sum(max(b)) - sum(min(b)), where b ranges over every (contiguous) subarray of n.
sum(min(b)) -  Leetcode 907. Sum of Subarray Minimums
*/

public class Solution {
    public enum CountType {
        MIN,
        MAX
    }
    public long SubArrayRanges(int[] nums) {
        long[] minCounts = GetSubArrayCounts(nums, CountType.MIN);
        long[] maxCounts = GetSubArrayCounts(nums, CountType.MAX);
        
        long res = 0;
        for(int i=0; i<nums.Length; i++){
            res += nums[i] * (maxCounts[i] - minCounts[i]);
        }
        return res;
    }
    
    private long[] GetSubArrayCounts(int[] nums, CountType type)
    {
        int n = nums.Length;
        int[] leftCounts = new int[n];
        Stack<(int count, int val)> monoStack = new Stack<(int count, int val)>();
        for(int i=0; i<n; i++){
            int count = 1;
            while(monoStack.Count > 0 && ((type == CountType.MIN) ? monoStack.Peek().val > nums[i] 
                                                                 : monoStack.Peek().val < nums[i]))
                count += monoStack.Pop().count;
                
            monoStack.Push((count, nums[i]));
            leftCounts[i] = count;
        }
        
        monoStack.Clear();
        int[] rightCounts = new int[n];
        
        for(int i=n-1; i>=0 ; i--){
            int count = 1;
            while(monoStack.Count > 0 && ((type == CountType.MIN) ? monoStack.Peek().val >= nums[i] 
                                                                 : monoStack.Peek().val <= nums[i]))
                count += monoStack.Pop().count;
                
            monoStack.Push((count, nums[i]));
            rightCounts[i] = count;
        }
        
        long[] counts = new long[n];
        for(int i=0; i<n; i++)
            counts[i] = leftCounts[i] * rightCounts[i];
        
        return counts;
    }
}