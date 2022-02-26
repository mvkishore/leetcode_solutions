//3,14,1,7
//[3, 17, 18, 25]   16
public class Solution {
    int[] w;
    int sum;
    public Solution(int[] w) {
        this.sum = w.Sum();
        this.w = w;
    }
    
    public int PickIndex() {
        var idx = new Random().Next(sum);
        int i=0;
        
        while(idx >= 0)
            idx -= w[i++];
        
        return i - 1;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */