public class Solution {
    public int RomanToInt(string s) {
        Dictionary<string, int> symbolToNum = new Dictionary<string, int>(){
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };
        
        string last = s.Substring(s.Length - 1);
        int prev = symbolToNum[last];
        int num = prev;
        
        for(int i=s.Length - 2; i>=0; i--){
            last = s.Substring(i, 1);
            int cur = symbolToNum[last];
            if(prev <= cur)
                num += cur;
            else
                num -= cur;
            prev = cur;
        }
        
        return num;
    }
}