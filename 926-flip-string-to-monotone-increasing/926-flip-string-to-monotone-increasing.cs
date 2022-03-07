public class Solution {
    public int MinFlipsMonoIncr(string s) {
        int n = s.Length;
        int[] flip1 = new int[n + 1];
        int[] flip0 = new int[n + 1];
        
        for(int i=1; i<= n; i++)
            flip1[i] = flip1[i-1] + (s[i - 1] == '1' ? 1 : 0);
        
        for(int i = n - 1; i >= 0; i--)
            flip0[i] = flip0[i + 1] + (s[i] == '0' ? 1 : 0);
        
        int flips = n;
        for(int i=0; i<= n; i++){
            flips = Math.Min(flip1[i] + flip0[i], flips);
        }
        
        return flips;
    }
}