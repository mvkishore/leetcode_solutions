public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        int[] charMap = new int[512];
        int count = 0, l = 0, r = 0, n = s.Length, len = 0;
        
        while(r < n){
            if(charMap[s[r]] == 0)
                count++;
            charMap[s[r]]++;
            r++;
            while(count > k) {
                if(charMap[s[l]] == 1)
                    count--;
                charMap[s[l]]--;
                l++;
            }
            len = Math.Max(len, r - l);
        }
        return len;
    }
}