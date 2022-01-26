/*
   max 0 index, => 1
    min 1 index => 15 

*/

public class Solution {
    public int MinFlipsMonoIncr(string s) {
        int n = s.Length;
        
        int[] f0 = new int[n + 1], f1 = new int[n + 1];
        f0[0] = f1[n] = 0;
        
        for(int i=1, j = n-1; i <= n; i++,j--){
            f0[i] = f0[i-1] + ((s[i - 1] == '1' ? 1 : 0));
            f1[j] = f1[j+1] + ((s[j] == '0' ? 1 : 0));
        }
        
        int flips = n;
        for(int i=0; i<=n; i++){
            flips = Math.Min(flips, f0[i] + f1[i]);
        }
        
        return flips;
    }
}

    
 