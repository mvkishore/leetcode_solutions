public class Solution {
    public string AddStrings(string num1, string num2) {
        int cary = 0, m = num1.Length - 1, n = num2.Length - 1;
        StringBuilder sum = new StringBuilder();
        
        while(m >= 0 || n >= 0 || cary > 0){
            if(m >=0 && n >= 0){
                int d1 = num1[m--] - '0';
                int d2 = num2[n--] - '0';
                sum.Insert(0, (d1 + d2 + cary) % 10);
                cary = (d1 + d2 + cary) / 10;
            }else if(m >= 0){
                int d1 = num1[m--] - '0';
                sum.Insert(0, (d1 + cary) % 10);
                cary = (d1 + cary) / 10;
            } else if(n >= 0){
                int d2 = num2[n--] - '0';
                sum.Insert(0, (d2 + cary) % 10);
                cary = (d2 + cary) / 10;
            } else if(cary > 0){
                sum.Insert(0, cary);
                cary = 0;
            }
        }
        return sum.ToString();
    }
}