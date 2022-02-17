public class Solution {
    public IList<string> RestoreIpAddresses(string s) {
        IList<string> res = new List<string>();
        
        Generate(s, 0, 3, new StringBuilder(), res);
        return res;
    }
    
    public void Generate(string s, int pos, int dots, StringBuilder sb, IList<string> res)
    {
        int n  = s.Length;
        if(pos >= n)
            return;
        
        for(int i=1; i<=3 && pos + i <= n; i++){
            var segment = s.Substring(pos, i);
            
            if(Valid(segment)){
                sb.Append(segment);
                if(dots == 0){
                    if(sb.Length == n + 3)
                        res.Add(sb.ToString());
                    sb.Length -= segment.Length;
                    continue;
                }
                
                sb.Append(".");
                Generate(s, pos + i, dots - 1, sb, res);
                sb.Length--;
                sb.Length -= segment.Length;
            }
        }
    }
    
    public bool Valid(string s)
    {
        return int.TryParse(s, out int value)
            && ((value <= 255 && s[0] != '0') || (value == 0 && s.Length == 1));
    }
}