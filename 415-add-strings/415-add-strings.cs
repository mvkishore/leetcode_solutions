public class Solution {
    public string AddStrings(string num1, string num2) {
        StringBuilder sb = new StringBuilder();
        int m = num1.Length, n = num2.Length;
        int cary = 0, i = m -1, j = n - 1;
        
        while(i >= 0 || j >= 0 || cary > 0){
            int sum = cary;
            if(i >= 0)
                sum += num1[i--] - '0';
            if(j >= 0)
                sum += num2[j--] - '0';
            
            cary = sum / 10;
            sb.Insert(0, sum % 10);
        }
        
        return sb.ToString();
        
    }
}