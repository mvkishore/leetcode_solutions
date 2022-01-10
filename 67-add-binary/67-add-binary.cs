public class Solution {
    public string AddBinary(string a, string b) {
        StringBuilder sb = new StringBuilder();
        int p1 = a.Length - 1, p2 = b.Length - 1;
        int sum = 0;
        
        while(p1 >= 0 || p2 >= 0 || sum > 0){
            sum += p1 >= 0 ? (a[p1--] - '0') : 0;
            sum += p2 >=0 ? (b[p2--] - '0') : 0;
            
            sb.Insert(0, (sum % 2).ToString());
            sum = sum / 2;
        }
        
        return sb.ToString();
    }
}
