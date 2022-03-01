public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int missing = 1;
        HashSet<int> seenNums = new HashSet<int>();
        foreach(var num in nums){
            seenNums.Add(num);
            if(num == missing){
                while(seenNums.Contains(missing))
                    missing++;
            }
        }
        return missing;
    }
}