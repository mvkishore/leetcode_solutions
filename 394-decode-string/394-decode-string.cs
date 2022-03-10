public class Solution {
    public string DecodeString(string s) {
        Stack<int> seenKs = new Stack<int>();
        Stack<StringBuilder> seenStrs = new Stack<StringBuilder>();
        int curNum = 0;
        StringBuilder curStr = new StringBuilder();
        
        foreach(var c in s){
            if(char.IsDigit(c)){
                curNum = curNum * 10 + c - '0';
            } else if(c == '[')
            {
                seenKs.Push(curNum);
                seenStrs.Push(curStr);
                curStr = new StringBuilder();
                curNum = 0;
            } else if(c == ']') {
                var k = seenKs.Pop();
                var str = seenStrs.Pop();
                
                while(k > 0){
                    str.Append(curStr);
                    k--;
                }
                
                curStr = str;
            } else {
                curStr.Append(c);
            }
        }
        
        return curStr.ToString();
    }
}