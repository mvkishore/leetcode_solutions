public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int[] charset = new int[256];
        int len = 0, l = 0, r = 0, n = s.Length, counter = 0;
        
        while(r < n){
            charset[s[r]]++;
            if(charset[s[r]] > 1) counter++;
            r++;
            while(counter > 0){
                charset[s[l]]--;
                if(charset[s[l]] == 1) counter--;
                l++;
            }
            len = Math.Max(len, r - l);
        }
        
        return len;
    }
}