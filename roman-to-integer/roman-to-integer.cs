public class Solution {
    public int RomanToInt(string s) {
        Dictionary<int, string> numToSymbol = new Dictionary<int, string>()
        {
            {0, ""}, {1, "I"}, {2, "II"}, {3, "III"}, {4, "IV"}, {5, "V"}, {6, "VI"}, {7, "VII"}, {8, "VIII"}, {9, "IX"},{10, "X"}, {20, "XX"}, {30, "XXX"}, {40, "XL"}, {50, "L"}, {60, "LX"}, {70, "LXX"}, {80, "LXXX"}, {90, "XC"}, {100, "C"}, {200, "CC"}, {300, "CCC"}, {400, "CD"}, {500, "D"}, {600, "DC"}, {700, "DCC"}, {800, "DCCC"}, {900, "CM"}, {1000, "M"}, {2000, "MM"}, {3000, "MMM"}
        };
        Dictionary<string, int> symbolToNum = new Dictionary<string, int>();
        
        foreach(var pair in numToSymbol)
            symbolToNum[pair.Value] = pair.Key;
        
     
        int i = s.Length - 1, num = 0;
        while(i >= 0){
            int j = i > 2 ? 2 : i;
            
            while(j >= 0 && i - j >= 0){
                var str = s.Substring(i - j, j + 1);
                if(symbolToNum.ContainsKey(str)){
                    num += symbolToNum[str];
                    i = i - j - 1;
                    break;
                }
                j--;
            }
        }
        
        return num;
    }
}