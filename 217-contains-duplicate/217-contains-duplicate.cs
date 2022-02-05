public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        HashSet<int> map = new HashSet<int>();
        foreach(var n in nums)
            if(!map.Add(n))
                return true;
        return false;
    }
}