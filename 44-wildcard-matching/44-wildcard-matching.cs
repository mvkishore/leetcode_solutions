public class Solution {
    public bool IsMatch(string s, string p) {
        int s_i = 0, p_i = 0, m = s.Length, n = p.Length;
        int p_star_i = -1, s_prev_i = -1;
        
        while(s_i < m){
            if(p_i < n && (s[s_i] == p[p_i] || p[p_i] == '?'))
            {
                s_i++;
                p_i++;
            }else if(p_i < n && p[p_i] == '*'){
                p_star_i = p_i;
                s_prev_i = s_i;
                p_i++;
            }else if(s_prev_i == -1)
                return false;
            else{
                p_i = p_star_i + 1;
                s_i = s_prev_i + 1;
                s_prev_i = s_i;
            }
        }
        
        while(p_i < n){
            if(p[p_i] != '*')
                return false;
            p_i++;
        }
        
        return true;
    }
}