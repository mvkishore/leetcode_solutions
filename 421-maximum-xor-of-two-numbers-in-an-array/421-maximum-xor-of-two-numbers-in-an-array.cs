public class Solution {
    public int FindMaximumXOR(int[] nums) {
        int max = 0, mask= 0;
        int L = Convert.ToString(nums.Max(), 2).Length;
        for(int i = L-1; i>=0; i--){
            mask = mask | (1 << i);
            
            HashSet<int> prefixes = new HashSet<int>();
            foreach(var num in nums)
                prefixes.Add(num & mask);
            
            int temp = max | (1 << i);
            foreach(var prefix in prefixes){
                if(prefixes.Contains(prefix ^ temp)){
                    max = temp;
                    break;
                }
            }
        }
        return max;
    }
}
