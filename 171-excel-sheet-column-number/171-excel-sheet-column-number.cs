public class Solution {
    public int TitleToNumber(string columnTitle) {
        int n = columnTitle.Length, i = 0;
        int res = 0;
        while(i < n){
            var c = columnTitle[i];
            res = res * 26 + (c - 'A') + 1;
            i++;            
        }
        return res;
    }
}