public class Solution {
    public char FindTheDifference(string s, string t) {
        int ch = 0;
        
        foreach(var c in s)
            ch ^= c;
        
        foreach(var c in t)
            ch ^= c;
        
        return (char)ch;
    }
}