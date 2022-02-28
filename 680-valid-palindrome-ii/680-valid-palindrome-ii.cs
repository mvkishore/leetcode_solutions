public class Solution {
    public bool ValidPalindrome(string s) {
        return ValidPalindrome(s, 0, s.Length - 1, true);
    }
    
    private bool ValidPalindrome(string s, int start, int end,bool skip) 
    {
        while(start < end){
            if(s[start] != s[end]){
                if(skip){
                    return ValidPalindrome(s, start + 1, end, false) ||
                        ValidPalindrome(s, start, end - 1, false);
                }
                return false;
            }
            start++;
            end--;
        }
        return true;
    }
}

