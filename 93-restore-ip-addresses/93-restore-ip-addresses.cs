public class Solution {
    public IList<string> RestoreIpAddresses(string s) {
        int n = s.Length;
        IList<string> res = new List<string>();
        
        if(n > 12)
            return res;
        
        GenerateIps(s, 0, 3, new StringBuilder(), res);
        return res;
    }
    
    private void GenerateIps(string s, int cur, int dots, StringBuilder sb, IList<string> res)
    {
        int n = s.Length;
        if(cur >= n)
            return;
        
        for(int i=1; i<= 3 && cur + i <= n; i++){
            var segment = s.Substring(cur, i);
            
            if(Valid(segment)){
                sb.Append(segment);
                
                if(dots == 0) {
                    if(sb.Length == n + 3) {
                        res.Add(sb.ToString());
                    }
                    sb.Length -= segment.Length;
                    continue;
                }
                
                sb.Append(".");
                GenerateIps(s, cur + i, dots - 1, sb, res);
                sb.Length--;
                sb.Length -= segment.Length;
            }
        }
    }
    
    private bool Valid(string segment)
    {
        return int.TryParse(segment, out int value) 
            && ((value <= 255 && segment[0] != '0') || (value == 0 && segment.Length == 1));
    }
    
}

    