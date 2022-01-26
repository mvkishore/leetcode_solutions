public class Solution {
    public bool IsValid(string s) {
        Dictionary<char, char> openBracketMap = new Dictionary<char, char>(){
            {'(',')'},
            {'[',']'},
            {'{','}'}
        };
        
        Stack<char> seenBrackets = new Stack<char>();
        foreach(var b in s){
            if(openBracketMap.ContainsKey(b)){
                seenBrackets.Push(openBracketMap[b]);
            }else{
                if(seenBrackets.Count == 0)
                    return false;
                if(seenBrackets.Pop() != b)
                    return false;
            }
        }
        return seenBrackets.Count == 0;
    }
}