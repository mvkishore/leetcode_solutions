public class Solution {
    public bool IsPalindrome(string s) {
        int l = 0, r = s.Length - 1;
        while(l < r){
            while(l < r && !IsValid(s[l]))
                l++;
            while(l < r && !IsValid(s[r]))
                r--;
            if(char.ToLower(s[l]) != char.ToLower(s[r]))
                return false;
            l++;
            r--;
        }
        return true;
    }
    
    private bool IsValid(char c){
        return (char.IsDigit(c)) || (c >= 'a' && c<= 'z') || (c >= 'A' && c<= 'Z');
    }
}