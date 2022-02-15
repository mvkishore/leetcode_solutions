public class Solution {
    public int NumKLenSubstrNoRepeats(string s, int k) {
        int l = 0, r = 0, n = s.Length;
        if(n < k)
            return 0;
        
        int[] count = new int[26];
        
        int ans = 0, distinctCount = 0;
        while(r < k){
            if(count[s[r]-'a'] == 0)
                distinctCount++;
            
            count[s[r] - 'a']++;
            r++;
        }
        
        while(r < n){
            if(distinctCount == k)
                ans++;
            
            count[s[l] - 'a']--;
            if(count[s[l]-'a'] == 0)
                distinctCount--;
            l++;
            
            if(count[s[r]-'a'] == 0)
                distinctCount++;
            
            count[s[r] - 'a']++;
            r++;
        }
        
        if(distinctCount == k) ans++;
        return ans;
    }
}