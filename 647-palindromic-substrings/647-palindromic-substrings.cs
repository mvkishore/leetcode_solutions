public class Solution {
    public int CountSubstrings(string s) {
        int count = 0, n = s.Length;
        
        for(int i=0; i<n; i++){
            count += GetPalindromCount(s, i, i);
            count += GetPalindromCount(s, i, i+1);
        }
        
        return count;
    }
    
    private int GetPalindromCount(string s, int start, int end)
    {
        int n = s.Length;
        int count = 0;
        while(start >=0 && end < n && s[start] == s[end])
        {
            start--;
            end++;
            count++;
        }
        return count;
    }
    
    
}