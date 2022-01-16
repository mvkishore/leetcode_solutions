public class Solution {
    public bool ValidWordAbbreviation(string word, string abbr) {
        int p1=0, m = word.Length, p2 = 0, n = abbr.Length;
        int num = 0;
        while(p1 < m && p2 < n){
            if(char.IsDigit(abbr[p2])){
                num = num*10 + abbr[p2] - '0';
                if(num == 0)
                    return false;
                
            } else if(p1 + num < m && word[p1+num] == abbr[p2]){
                p1 += num;
                num = 0;
                p1++;
            } else 
                return false;
            p2++;
        }
        return num == m - p1 && p2 == n;
    }
}