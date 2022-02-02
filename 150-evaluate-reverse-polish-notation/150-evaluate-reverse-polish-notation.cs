public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        for(int i=0; i < tokens.Length; i++){
            switch(tokens[i]){
                case "+" :
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(a + b);
                    break;
                case "-":
                    a = stack.Pop();
                    b = stack.Pop();
                    stack.Push(b - a);
                    break;
                case "*":
                    a = stack.Pop();
                    b = stack.Pop();
                    stack.Push(a * b);
                    break;
                case "/" :
                    a = stack.Pop();
                    b = stack.Pop();
                    stack.Push(b / a);
                    break;
                default:
                    stack.Push(Convert.ToInt32(tokens[i]));
                    break;
            }
        }
        
        return stack.Pop();
    }
}