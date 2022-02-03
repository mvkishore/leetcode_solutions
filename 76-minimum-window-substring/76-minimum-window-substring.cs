public class Solution {
    public string MinWindow(string s, string t) {
        int n = s.Length, start=0, end=0, m = t.Length;
        int[] chars = new int[256];
        
        foreach(var c in t){
            chars[c]++;
        }
        
        int minLen = int.MaxValue;
        int startIndx = 0, counter = 0;
        while(end < n){
            if(chars[s[end++]]-- > 0) counter++;
            
            while(counter == m){
                if(minLen >= end - start){
                    minLen = end - start;
                    startIndx = start;
                }
                if(chars[s[start++]]++ == 0) counter--;
            }
        }
        return minLen == int.MaxValue ? string.Empty : s.Substring(startIndx, minLen);
    }
    
}