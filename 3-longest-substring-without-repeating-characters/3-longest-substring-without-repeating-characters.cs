public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int n = s.Length, maxLen = 0, l = 0,r = 0;
        int[] counter = new int[256];
        
        while(r < n){
            counter[s[r]]++;
            
            while(counter[s[r]] > 1)
            {
                counter[s[l]]--;
                l++;
            }
            
            r++;
            maxLen = Math.Max(maxLen, r - l);
        }
        
        return maxLen;
    }
}