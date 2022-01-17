public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int[] counter = new int[256];
        int l = 0, r = 0, n = s.Length, len = 0;
        
        while(r < n){
            counter[s[r]]++;
            
            while(counter[s[r]] > 1){
                counter[s[l]]--;
                
                if(counter[s[l++]] == 1) {
                    break;
                }
            }
            r++;
            
            len = Math.Max(len, r - l);
        }
        
        return len;
    }
}