public class Solution {
    public string IntToRoman(int num) {
        int[] values = new [] {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        string[] symbols = new[]{"M", "CM", "D", "CD", "C", "XC", "L","XL","X", "IX","V", "IV", "I"};
        
        StringBuilder res = new StringBuilder();
        int i = 0;
        while(num > 0){
            while(i < values.Length && num >= values[i]){
                num -= values[i];
                res.Append(symbols[i]);
            }
            i++;
        }
        
        return res.ToString();
    }
}