public class Solution {
    public int FindPairs(int[] nums, int k) {
        Dictionary<int, int> seenNums = new Dictionary<int, int>();
        int count = 0;
        if(k == 0){
            for(int i=0; i<nums.Length;i++){
                if(!seenNums.ContainsKey(nums[i]))
                    seenNums.Add(nums[i], 0);
                seenNums[nums[i]]++;
            }
            count = seenNums.Count(x=> x.Value > 1);
        }
        
        for(int i=0; i<nums.Length; i++){
            int a = nums[i];
            int b = a - k, c = a + k;
            
            if(seenNums.ContainsKey(a)){
                continue;
            }
            
            if(seenNums.ContainsKey(b) && seenNums[b] < i)
                count++;
            if(seenNums.ContainsKey(c) && seenNums[c] < i)
                count++;
            
            seenNums.Add(a, i);
        }
        return count;
    }
}