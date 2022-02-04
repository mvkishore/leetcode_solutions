
public class Solution {
    public int FindMaxLength(int[] nums) {
        Dictionary<int, int> seenCount = new Dictionary<int,int>();
        seenCount.Add(0, -1);
        int len = 0, count = 0;
        for(int i=0; i<nums.Length; i++){
            count += nums[i] == 1 ? 1 : -1;
            if(seenCount.ContainsKey(count)){
                len = Math.Max(len, i - seenCount[count]);
            }else seenCount.Add(count, i);
        }
        return len;
    }
}