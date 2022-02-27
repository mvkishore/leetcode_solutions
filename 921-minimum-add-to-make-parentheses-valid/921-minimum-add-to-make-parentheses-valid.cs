public class Solution {
    public int MinAddToMakeValid(string s) {
        int open = 0, close = 0;
        
        foreach(var c in s){
            if(c == '(') {
                open++;
            } else if(open > 0)
                open--;
            else close++;
        }
        return close + open;
    }
}

