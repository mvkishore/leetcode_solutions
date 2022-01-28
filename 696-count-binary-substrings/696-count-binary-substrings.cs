public class Solution {
    public int CountBinarySubstrings(string s) {
        int cur = 1, prev = 0, res = 0;
        for(int i=1; i<s.Length; i++){
            if(s[i] == s[i-1]){
                cur++;
            }else{
                res += Math.Min(prev, cur);
                prev = cur;
                cur = 1;
            }
        }
        return res + Math.Min(cur, prev);
    }
}