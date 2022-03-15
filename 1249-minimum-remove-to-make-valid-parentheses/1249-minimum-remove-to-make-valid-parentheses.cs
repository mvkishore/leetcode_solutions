public class Solution {
    public string MinRemoveToMakeValid(string s) {
        var chars = s.ToCharArray();
        chars = Remove(chars, '(', ')');
        Array.Reverse(chars);
        chars = Remove(chars, ')', '(');
        Array.Reverse(chars);
        
        return new string(chars);
    }
    
    public char[] Remove(char[] charArray, char open, char close)
    {
        int count = 0;
        var res = new List<char>();
        foreach(var c in charArray){
            if(c == open){
                count++;
            } else if(c == close){
                if(count <= 0)
                    continue;
                count--;
            }
            
            res.Add(c);
        }
        
        return res.ToArray();
    }
}