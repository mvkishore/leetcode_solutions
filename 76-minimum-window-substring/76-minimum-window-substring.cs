public class Solution {
    public string MinWindow(string s, string t) {
        int m = s.Length, n = t.Length;
        int[] counter = new int[256];
        
        
        foreach(var c in t)
            counter[c]++;
        
        int l = 0, r = 0, seenCharsOfT = 0, minLen = int.MaxValue, startIndx = -1;
       
        while(r < m){
            if(counter[s[r]] > 0)
                seenCharsOfT++;
            
            counter[s[r]]--;
            r++;
            while(seenCharsOfT == n){
                int len = r - l;
                if(len < minLen){
                    minLen = len;
                    startIndx = l;
                }
                counter[s[l]]++;
                if(counter[s[l]] > 0) seenCharsOfT--;
                l++;
            }
        }
        if(startIndx < 0)
            return string.Empty;
        return s.Substring(startIndx, minLen);
    }
}