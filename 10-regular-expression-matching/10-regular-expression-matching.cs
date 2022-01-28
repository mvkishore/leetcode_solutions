/*

s=ab.*xy*.lk.*

p=abxylk


when theres . not followed by * skip a letter
when there's *, track before latter, 
prev=./ alphabet


*/

public class Solution {
    public bool IsMatch(string s, string p) {
        
        return IsMatch(0, s, 0, p);
    }
    
    private bool IsMatch(int si, string s, int pi, string p)
    {
        int sl = s.Length, pl = p.Length;
        
        if(pi == pl) 
            return si == sl;
        
        if(pi+1 < pl && p[pi + 1] == '*'){
            //0 matches for current
            if(IsMatch(si, s, pi + 2, p))
                return true;
            
            //x matches for current
            if(CheckSingle(si, s, pi, p))
                return IsMatch(si + 1, s, pi, p);
        }
        else if(CheckSingle(si, s, pi, p))
           return IsMatch(si + 1, s, pi + 1, p);
           
        return false;
    }
    
    private bool CheckSingle(int si, string s, int pi, string p)
    {
        int sl = s.Length, pl = p.Length;
        return si < sl && pi < pl && (s[si] == p[pi] || p[pi] == '.');
    }
}