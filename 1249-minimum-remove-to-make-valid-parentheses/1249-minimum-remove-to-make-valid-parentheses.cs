public class Solution {
    public string MinRemoveToMakeValid(string s) {
        var res = s.ToCharArray();
        res = RemoveExtra(res, '(', ')');
        
        Array.Reverse(res);
        res = RemoveExtra(res, ')', '(');
        Array.Reverse(res);
        
        return new string(res);
    }
    
    public char[] RemoveExtra(char[] s, char open, char close)
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;
        foreach(var c in s){
            if(c == open)
                count++;
            
            if(c == close)
                if(count <= 0)
                    continue;
                else
                    count--;
            
            sb.Append(c);
        }
        return sb.ToString().ToCharArray();
    }
}