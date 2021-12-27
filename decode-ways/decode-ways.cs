public class Solution {
    public int NumDecodings(string s) {
        int[] memo = new int[s.Length];
        return NumDecodings(s, 0, memo);
    }
    
    private int NumDecodings(string s, int start, int[] memo){
        if(start > s.Length)
            return 0;
        if(start == s.Length)
            return 1;
        if(s[start] == '0')
            return 0;
        if(memo[start] != 0) 
            return memo[start];
        
        int count = NumDecodings(s, start+1, memo);
        
        if(start + 1 < s.Length) {
            if(Convert.ToInt32(s.Substring(start, 2)) < 27)
                count += NumDecodings(s, start+2, memo);
        }
        
        return memo[start] = count;
    }
}