public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int n = s.Length, maxLen = 0, l = 0,r = 0;
        int[] counter = new int[256];
        bool repeating = false;
        
        while(r < n){
            counter[s[r]]++;
            if(counter[s[r]] > 1)
                repeating = true;
            r++;
            
            while(repeating){
                counter[s[l]]--;
                if(counter[s[l]] == 1)
                    repeating = false;
                l++;
            }
            
            maxLen = Math.Max(maxLen, r - l);
        }
        
        return maxLen;
    }
}