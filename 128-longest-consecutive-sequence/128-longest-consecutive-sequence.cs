public class Solution {
    public int LongestConsecutive(int[] nums) {
        HashSet<int> numSet = new HashSet<int>();
        
        foreach(var n in nums)
            numSet.Add(n);
        
        int maxLen = 0;
        foreach(var num in nums){
            if(!numSet.Contains(num - 1)){
                int curLen = 1;
                int n = num;
                while(numSet.Contains(n + 1)){
                    curLen++;
                    n = n + 1;
                }
                maxLen = Math.Max(curLen, maxLen);
            }
        }
        
        return maxLen;
    }
}