public class Solution {
    public int MinFlipsMonoIncr(string s) {
        int n = s.Length;
        int[] f0 = new int[n + 1], f1 = new int[n+1];
        
        for(int i=1; i<=n; i++)
            f0[i] = f0[i-1] + (s[i-1] == '1' ? 1 : 0);
        
        for(int j=n-1; j >= 0; j--)
            f1[j] = f1[j+1] + (s[j] == '0' ? 1 : 0);
        
        int flips = n;
        for(int i=0; i<=n; i++){
            flips = Math.Min(flips, f0[i] + f1[i]);
        }
        
        return flips;
    }
}

    
 