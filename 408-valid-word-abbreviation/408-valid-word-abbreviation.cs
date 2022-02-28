public class Solution {
    public bool ValidWordAbbreviation(string word, string abbr) {
        int num = 0, n = abbr.Length, m = word.Length;
        int i = 0, j = 0;
        if(n > m)
            return false;
        //  word = "internationalization", abbr = "i12iz4n"
        while(j < n){
            if(char.IsDigit(abbr[j]))
            {
                if(num == 0 && abbr[j] == '0') return false;
                num = num * 10 + abbr[j] - '0';
                j++;
                continue;
            } 
            
            if(num > 0 && i + num < m && abbr[j] != word[i + num])
                return false;
            else if(num == 0 && i < m && abbr[j] != word[i])
                return false;
            j++;
            i += num + 1;
            num = 0;
        }
        if(num > 0){
            i += num;
        }
        return i == m;
    }
}