public class Solution {
    public bool IsMatch(string s, string p) {
        int sI = 0, pI = 0, m = s.Length, n = p.Length;
        int starIndx = -1, prevSi=-1;
        
        while(sI < m){
            if(pI < n && (s[sI] == p[pI] || p[pI] == '?'))
            {
                sI++;
                pI++;
            }else if(pI < n && p[pI] == '*'){
                starIndx = pI;
                prevSi = sI;
                pI++;
            }else if(starIndx == -1) return false;
            else {
                pI = starIndx + 1;
                sI = prevSi + 1;
                prevSi = sI;
            }
        }
        
        while(pI < n){
            if(p[pI++] != '*')
                return false;
        }
        return true;
    }
}