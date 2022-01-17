  
/*

  
babad
  0   1   2   3   4
0 T   
1     T
2         T
3             T
4                  T


*/

public class Solution {
    public string LongestPalindrome(string s) {
        int n = s.Length;
        int maxLen = 0;
        int startPos = -1;
        
        for(int i=0; i<n; i++)
        {
            var lenPos1 = ExpandForPalindrome(s, i, i);
            var lenPos2 = ExpandForPalindrome(s, i, i+1);
            
            var lenPos = lenPos1[0] < lenPos2[0] ? lenPos2 : lenPos1;
            
            if(lenPos[0] > maxLen){
                maxLen = lenPos[0];
                startPos = lenPos[1];
            }
        }
        
        return s.Substring(startPos, maxLen);
    }
    private int[] ExpandForPalindrome(string s, int l, int r)
    {
        int n = s.Length;
        while(l>=0 && r < n && s[l] == s[r])
        {
            l--;
            r++;
        }
        return new int[] {r - l - 1, l + 1};
    }
        
}