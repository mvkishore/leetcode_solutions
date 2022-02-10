public class Solution {
    public int LongestValidParentheses(string s) {
        int left = 0, right =0, maxLen = 0;
        foreach(var c in s){
            if(c == '(')
                left++;
            else
                right++;
            
            if(left == right)
                maxLen = Math.Max(maxLen,2 * right);
            else if(right > left)
                left = right = 0;
        }
        left = right = 0;
        for(int i=s.Length - 1; i>=0; i--){
            var c = s[i];
            if(c == '(')
                left++;
            else
                right++;
            
            if(left == right)
                maxLen = Math.Max(maxLen,2 * left);
            else if(left > right)
                left = right = 0;
        }
        return maxLen;
    }
}