public class Solution {
    public int MyAtoi(string s) {
        int res = 0,n = s.Length, sign = 0;
        int i=0;
        
        //skip leading whitespace
        while(i < n && s[i] == ' ')
            i++;
        
        if(i < n && s[i] == '+'){
            sign = 1;
            i++;
        }
        
        if(i < n && sign == 0 && s[i] == '-'){
            sign = -1;
            i++;
        }
        
        while(i < n && char.IsDigit(s[i])){
            int d = s[i++] - '0';
            
            if((res > int.MaxValue / 10) || (res == int.MaxValue / 10  && d > int.MaxValue % 10))
                return sign == -1 ? int.MinValue : int.MaxValue;
            
            res = res * 10 + d;
        }
        
        return sign == 0 ? res : res * sign;
    }
}