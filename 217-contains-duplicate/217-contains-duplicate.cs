public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        HashSet<int> seen = new HashSet<int>();
        foreach(var num in nums)
            if(!seen.Add(num)) return true;
        return false;
    }
}