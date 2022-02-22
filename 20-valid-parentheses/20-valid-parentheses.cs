public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> parenthMap = new Dictionary<char, char>(){
            {')', '(' },
            {']', '[' },
            {'}', '{' },
        };
        
        foreach(var c in s){
            if(parenthMap.ContainsKey(c)){
                if(stack.Count == 0 || stack.Pop() != parenthMap[c])
                    return false;
            }else {
                stack.Push(c);
            }
        }
        return stack.Count == 0;
    }
}