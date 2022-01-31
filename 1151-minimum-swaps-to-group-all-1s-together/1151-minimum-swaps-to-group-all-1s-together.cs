public class Solution {
    //[1,0,1,0,1]
    public int MinSwaps(int[] data) {
        int n = data.Length;
        int ones = data.Count(x=> x == 1);
        
        if(n <= 1 || ones == 0)
            return 0;
        
        int left = 0, right = 0;
        int swaps = 0;
        while(right < ones){
            if(data[right] == 0)
                swaps++;
            right++;
        }
        
        int minSwaps = swaps;
        while(right < n){
            if(data[right++] == 0)
                swaps++;
            if(data[left++] == 0)
                swaps--;
            minSwaps = Math.Min(swaps, minSwaps);
        }
        
        return minSwaps;
    }
}