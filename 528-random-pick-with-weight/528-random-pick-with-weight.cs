public class Solution {
    int sum = 0;
    int[] arr;
    //[1, 3, 5, 2, 4]
    
    //sum = 14
    //14 13 10 5 3 -1
    public Solution(int[] w) {
        sum = w.Sum();
        arr = w;
    }
    
    public int PickIndex() {
        int idx = new Random().Next(sum);
        
        int i = 0;
        while(idx >= 0)
            idx -= arr[i++];
        return i - 1;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */