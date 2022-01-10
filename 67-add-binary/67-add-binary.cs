public class Solution {
    public string AddBinary(string a, string b) {
        StringBuilder sb = new StringBuilder();
        int p1 = a.Length - 1, p2 = b.Length - 1;
        int carry = 0;
        
        while(p1 >= 0 || p2 >= 0){
            int sum = (p1 >= 0 ? (a[p1--] - '0') : 0)
                        + (p2 >=0 ? (b[p2--] - '0') : 0) + carry;
            
            sb.Insert(0, (sum % 2).ToString());
            carry = sum / 2;
        }
               
        if(carry > 0)
            sb.Insert(0, carry.ToString());
            
        return sb.ToString();
    }
}
