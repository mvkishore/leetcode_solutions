public class Solution {
    public string IntToRoman(int num) {
        string[] symbols = new string[] {"M", "CM", "D", "CD", "C", "XC", "L", "XL","X", "IX", "V", "IV", "I"};
        int[] values = new int[] {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        
        Dictionary<int, string> numToSymbol = new Dictionary<int, string>()
        {
            {0, ""}, {1, "I"}, {2, "II"}, {3, "III"}, {4, "IV"}, {5, "V"}, {6, "VI"}, {7, "VII"}, {8, "VIII"}, {9, "IX"},{10, "X"}, {20, "XX"}, {30, "XXX"}, {40, "XL"}, {50, "L"}, {60, "LX"}, {70, "LXX"}, {80, "LXXX"}, {90, "XC"}, {100, "C"}, {200, "CC"}, {300, "CCC"}, {400, "CD"}, {500, "D"}, {600, "DC"}, {700, "DCC"}, {800, "DCCC"}, {900, "CM"}, {1000, "M"}, {2000, "MM"}, {3000, "MMM"}
        };
        
        StringBuilder sb = new StringBuilder();
        
        int thousands = (num / 1000) * 1000;
        sb.Append(numToSymbol[thousands]);
        num = num - thousands;
        
        int hundreds = (num / 100) * 100;
        sb.Append(numToSymbol[hundreds]);
        num = num - hundreds;
        
        int tens = (num / 10) * 10;
        sb.Append(numToSymbol[tens]);
        num = num - tens;
        
        sb.Append(numToSymbol[num]);
        
        return sb.ToString();
    }
}