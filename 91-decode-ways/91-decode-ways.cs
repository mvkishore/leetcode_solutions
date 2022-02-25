public class Solution {
    public int NumDecodings(string s) {
        int?[] cache = new int?[s.Length];
        
        return NumDecodings(s, 0, cache).Value;
    }
    
    private int? NumDecodings(string s, int index, int?[] cache){
        if(index == s.Length)
            return 1;
        
        if(cache[index] != null)
            return cache[index];
        
        if(s[index] == '0')
            return cache[index] = 0;
        
        if(index == s.Length - 1)
            return cache[index] = 1;
        
        int? opt1 = NumDecodings(s, index + 1, cache);
        int? opt2 = 0;
        int num = Convert.ToInt32(s.Substring(index, 2));
        if(num >= 10 && num <= 26)
            opt2 = NumDecodings(s, index + 2, cache);
        
        return cache[index] = opt1 + opt2;
    }
}
    