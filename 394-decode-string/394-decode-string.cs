public class Solution {
    public string DecodeString(string s) {
        Stack<int> seenKs = new Stack<int>();
        Stack<StringBuilder> seenStrings = new Stack<StringBuilder>();
        
        StringBuilder curString = new StringBuilder();
        int curNum = 0;
        
        foreach(var c in s){
            if(char.IsDigit(c)){
                curNum = curNum * 10 + c - '0';
            }else if(c == '['){
                
                seenKs.Push(curNum);
                curNum = 0;
                seenStrings.Push(curString);
                curString = new StringBuilder();
                
            }else if(c == ']'){
                
                var k = seenKs.Pop();
                var str = seenStrings.Pop();
                while(k > 0){
                    str.Append(curString);
                    k--;
                }
                curString = str;
                
            } else {
                curString.Append(c);
            }
        }
        
        return curString.ToString();
    }
}
     