public class Solution {
    public string LongestPalindrome(string s) {
        int n = s.Length, maxLen = 0, startIndx = -1;
        for(int i=0; i<n; i++){
            int oddLength = GetPalindrome(s, i, i);
            int evenLength = GetPalindrome(s, i, i+1);
            
            int len = Math.Max(oddLength, evenLength);
            if(len > maxLen){
                maxLen = len;
                startIndx = i - (len - 1) / 2;
            }
        }
        return s.Substring(startIndx, maxLen);
    }
    
    private int GetPalindrome(string s, int left, int right)
    {
        int n = s.Length;
        while(left >= 0 && right < n && s[left] == s[right]){
            left--;
            right++;
        }
        return right - left - 1;
    }
}