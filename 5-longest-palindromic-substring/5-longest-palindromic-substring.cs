public class Solution {
    public string LongestPalindrome(string s) {
        int n = s.Length, maxLen = -1, startIndex = -1;
        
        for(int i=0; i<n; i++){
            int oddLen = GetPalindromeLen(s, i, i);
            int eveLen = GetPalindromeLen(s, i, i + 1);
            
            int len = Math.Max(oddLen, eveLen);
            if(maxLen < len){
                maxLen = len;
                startIndex = i - (len - 1) / 2;
            }
        }
        Console.WriteLine(startIndex);
        return s.Substring(startIndex, maxLen);
    }
    
    private int GetPalindromeLen(string s, int l, int r)
    {
        int n = s.Length;
        while(l >= 0 && r < n && s[l] == s[r]){
            l--;
            r++;
        }
        return r - l - 1;
    }
}