public class Solution {
    public string RemoveDuplicates(string s) {
        StringBuilder sb = new StringBuilder();
        int n = s.Length;
        if(n <= 1)
            return s;
        
        sb.Append(s[0]);
        for(int i=1; i < n; i++){
            while(i < n && sb.Length > 0 && sb[sb.Length - 1] == s[i]){
                sb.Length--;
                i++;
                continue;
            }
            if(i < n)
                sb.Append(s[i]);
        }
        
        return sb.ToString();
    }
}