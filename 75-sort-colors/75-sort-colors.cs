public class Solution {
    public void SortColors(int[] nums) {
        int[] counter = new int[3];
        foreach(var n in nums)
            counter[n]++;
        int j=0;
        for(int i=0; i<=2; i++){
            while(counter[i]-- > 0){
                nums[j++] = i;
            }
        }
    }
}