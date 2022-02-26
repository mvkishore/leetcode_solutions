public class Solution {
    public int Calculate(string s) {
        char prev = '+';
        Stack<int> stack = new Stack<int>();
        int curNum = 0;
        for(int i =0; i<s.Length; i++){
            if(char.IsDigit(s[i])){
                curNum = curNum *10 + (s[i] - '0');
            }else if(s[i] != ' '){
                EvaluateOperation(stack, curNum, prev);
                prev = s[i];
                curNum = 0;
            }
        }
        EvaluateOperation(stack, curNum, prev);
        int res = 0;
        while(stack.Count > 0){
            res += stack.Pop();
        }
        return res;
    }
    
    private void EvaluateOperation(Stack<int> stack, int num, char op)
    {
        switch(op){
            case '+':
                stack.Push(num);
                break;
            case '-':
                stack.Push(-num);
                break;
            case '*':
                var num1 = stack.Pop();
                stack.Push(num1 * num);
                break;
            case '/':
                var num2 = stack.Pop();
                stack.Push(num2 / num);
                break;
        }
    }
}