public class Solution {
    public bool IsValid(string s) {
        Dictionary<char, char> brackets = new Dictionary<char, char>(){
            {'{', '}'},
            {'[', ']'},
            {'(', ')'}
        };
        
        Stack<char> seen = new Stack<char>();
        foreach(var c in s){
            if(brackets.ContainsKey(c)){
                seen.Push(brackets[c]);
            }else if(seen.Count == 0 || seen.Pop() != c)
                return false;
        }
        
        return seen.Count == 0;
    }
}