public class Solution {
    public int StrStr(string haystack, string needle) {
        int m = haystack.Length, n = needle.Length;
        if(n > m || (m == n && haystack != needle))
            return -1;
        if(n == 0)
            return 0;
        
        for(int i=0; i <= m - n; i++){
            int k = i, r = i;
            for(int j=0; j < n; j++){
                if(haystack[k++] != needle[j])
                    break;
                if(j == n -1)
                    return r;
            }
        }
        return -1;
    }
}