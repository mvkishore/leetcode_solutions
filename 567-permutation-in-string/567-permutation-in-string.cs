public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int l=0, r = 0, m = s1.Length, n = s2.Length;
        int[] counter = new int[26];
        int count = m;
        if(n < m)
            return false;
        
        foreach(var c in s1)
            counter[c - 'a']++;
        
        while(r < m){
            int cur = s2[r] - 'a';
            if(counter[cur] > 0){
                count--;
            }
            counter[cur]--;
            r++;
        }
        
        while(r < n){
            if(count == 0)
                return true;
            
            int first = s2[l] - 'a';
            if(counter[first] >=0)
                count++;
            counter[first]++;
            l++;
            
            int cur = s2[r] - 'a';
            if(counter[cur] > 0){
                count--;
            }
            counter[cur]--;
            r++;
        }
        
        return count == 0;
    }
}