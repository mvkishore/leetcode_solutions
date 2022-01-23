/*

(
()
()(
()()
        ()(())
(()

*/
public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        IList<string> result = new List<string>();
        StringBuilder sb = new StringBuilder();
        Generate(sb, 0, 0, n, result);
        return result;
        
    }
    
    private void Generate(StringBuilder sb, int open, int close, int n, IList<string> result)
    {
        if(sb.Length == n*2){
            result.Add(sb.ToString());
            return;
        }
        
        if(open < n){
            sb.Append('(');
            Generate(sb, open+1, close, n, result);
            sb.Length--;
        }
        
        if(close < open){
            sb.Append(')');
            Generate(sb, open, close + 1, n, result);
            sb.Length--;
        }
    }
}