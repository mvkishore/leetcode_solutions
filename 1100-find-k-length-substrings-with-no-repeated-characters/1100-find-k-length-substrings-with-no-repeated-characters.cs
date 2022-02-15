public class Solution {
    public int NumKLenSubstrNoRepeats(string s, int k) {
        int l = 0, r = 0, n = s.Length;
        if(n < k)
            return 0;
        
        int[] count = new int[26];
        
        int ans = 0, counter = 0;
        while(r < k){
            if(count[s[r]-'a'] == 0)
                counter++;
            
            count[s[r] - 'a']++;
            r++;
        }
        
        while(r < n){
            if(counter == k)
                ans++;
            
            count[s[l] - 'a']--;
            if(count[s[l]-'a'] == 0)
                counter--;
            l++;
            
            if(count[s[r]-'a'] == 0)
                counter++;
            
            count[s[r] - 'a']++;
            r++;
        }
        if(counter == k) ans++;
        return ans;
    }
}