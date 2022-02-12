public class Solution {
    public int MyAtoi(string s) {
        int sign = 1, n = s.Length, res = 0, i = 0;
        
        while(i < n && s[i] == ' ')
            i++;
        
        if(i < n && s[i] == '-'){
            sign = -1;
            i++;
        }
        else if(i < n && s[i] == '+'){
            i++;
        }
        
        while(i < n && char.IsDigit(s[i])){
            int cur = s[i] - '0';
            
            if(int.MaxValue / 10 < res || (int.MaxValue / 10 == res && cur > int.MaxValue % 10))
                return sign == 1 ? int.MaxValue : int.MinValue;
            
            res = res * 10 + s[i] - '0';
            i++;
        }
        
        return res * sign;
    }
}