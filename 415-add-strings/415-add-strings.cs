public class Solution {
    public string AddStrings(string num1, string num2) {
        int cary = 0, m = num1.Length - 1, n = num2.Length - 1;
        StringBuilder sum = new StringBuilder();
        
        while(m >= 0 || n >= 0 || cary > 0){
            int s = cary;
            if(m >= 0)
                s += num1[m--] - '0';
            if(n >= 0)
                s += num2[n--] - '0';
            
            sum.Insert(0, s % 10);
            cary = s / 10;
        }
        return sum.ToString();
    }
}