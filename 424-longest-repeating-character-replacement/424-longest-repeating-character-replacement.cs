public class Solution {
    public int CharacterReplacement(string s, int k) {
        int l = 0, r = 0, n = s.Length, maxCount = 0;
        int[] count = new int[26];
        int maxLen = 0;
        while(r < n){
            count[s[r] - 'A']++;
            maxCount = Math.Max(maxCount, count[s[r] - 'A']);
            r++;
            
            if(r - l - maxCount > k){
                count[s[l] - 'A']--;
                l++;
            }
            maxLen = Math.Max(maxLen, r - l);
        }
        return maxLen;
    }
}