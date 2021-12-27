public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> compliments = new Dictionary<int, int>();
        
        for(int i=0; i< nums.Length; i++){
            int y = target - nums[i];
            if(compliments.ContainsKey(y)){
                return new int[]{ compliments[y], i};
            }else {
                if(!compliments.ContainsKey(nums[i]))
                    compliments.Add(nums[i], i);
            }
        }
        return new int[0];
    }
}