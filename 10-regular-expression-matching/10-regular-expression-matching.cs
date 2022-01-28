/*

s=ab.*xy*.lk.*

p=abxylk


when theres . not followed by * skip a letter
when there's *, track before latter, 
prev=./ alphabet


*/

public class Solution {
    public bool IsMatch(string s, string p) {
        bool?[,] memo = new bool?[s.Length + 1, p.Length + 1];
        return IsMatch(0, s, 0, p, memo).Value;
    }
    
    private bool? IsMatch(int si, string s, int pi, string p,bool?[,] memo)
    {
        int sl = s.Length, pl = p.Length;
        
        if(pi == pl) 
            return si == sl;
        
        if(memo[si, pi] != null)
            return memo[si, pi];
        
        if(pi+1 < pl && p[pi + 1] == '*'){
            //0 matches for current
            if(IsMatch(si, s, pi + 2, p, memo) == true)
                return memo[si, pi] = true;
            
            //x matches for current
            if(CheckSingle(si, s, pi, p))
                return memo[si, pi] = IsMatch(si + 1, s, pi, p, memo);
        }
        else if(CheckSingle(si, s, pi, p))
           return memo[si, pi] = IsMatch(si + 1, s, pi + 1, p, memo);
           
        return memo[si, pi] = false;
    }
    
    private bool CheckSingle(int si, string s, int pi, string p)
    {
        int sl = s.Length, pl = p.Length;
        return si < sl && pi < pl && (s[si] == p[pi] || p[pi] == '.');
    }
}