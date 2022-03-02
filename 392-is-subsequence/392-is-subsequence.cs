public class Solution {
    public bool IsSubsequence(string s, string t) {
        int p1 = 0, p2 = 0;
        int n = s.Length, m = t.Length;
        if(n > m)
            return false;
        
        while(p1 < n && p2 < m){
            if(s[p1]==t[p2]){
                p1++;
                p2++;
            }else {
                p2++;
            }
        }
        return p1 == n;
    }
}