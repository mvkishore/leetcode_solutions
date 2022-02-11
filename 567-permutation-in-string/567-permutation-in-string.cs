public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int m = s1.Length, n = s2.Length, l = 0, r = 0, count = 0;
        int[] s1Map = new int[26];
        
        if(n < m)
            return false;
        
        foreach(var c in s1)
            s1Map[c - 'a']++;
        
        while(r < m)
        {
            int cur = s2[r] - 'a';
            if(s1Map[cur] > 0)
                count++;
            s1Map[cur]--;
            r++;
        }
        
        while(r < n){
            if(count == m)
                return true;
            
            int left = s2[l] - 'a';
            if(s1Map[left] >= 0)
                count--;
            s1Map[left]++;
            l++;
            
            int cur = s2[r] - 'a';
            if(s1Map[cur] > 0)
                count++;
            s1Map[cur]--;
            r++;
        }
        
        return count == m;
    }
}