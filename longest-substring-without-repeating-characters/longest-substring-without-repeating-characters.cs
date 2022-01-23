public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int[] charset = new int[256];
        int n = s.Length;
        int counter = 0, l=0,r=0;
        int maxlen = 0;
       
        while(r < n){
            charset[s[r]]++;
            if(charset[s[r]] > 1) counter++;
            r++;
            
            while(counter > 0){
                charset[s[l]]--;
                if(charset[s[l]] == 1) counter--;
                l++;
            }
            maxlen = Math.Max(maxlen, r - l);
        }
        
        return maxlen;
    }
}