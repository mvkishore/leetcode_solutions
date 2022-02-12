public class Solution {
    public string IntToRoman(int num) {
        string[] symbols = new string[] {"M", "CM", "D", "CD", "C", "XC", "L", "XL","X", "IX", "V", "IV", "I"};
        int[] values = new int[] {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        
        StringBuilder sb = new StringBuilder();
        
        for(int i=0; i<values.Length; i++){
            while(num >= values[i]){
                sb.Append(symbols[i]);
                num -= values[i];
            }
        }
        return sb.ToString();
    }
}