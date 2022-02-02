public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        Dictionary<string, Func<int, int, int>> operations = new Dictionary<string, Func<int, int, int>>();
        operations.Add("+", (a, b) => a + b);
        operations.Add("-", (a, b) => a - b);
        operations.Add("*", (a, b) => a * b);
        operations.Add("/", (a, b) => a / b);
        
        for(int i=0; i < tokens.Length; i++){
            if(operations.ContainsKey(tokens[i])){
                int b = stack.Pop();
                int a = stack.Pop();
                stack.Push(operations[tokens[i]](a, b));
            }
            else stack.Push(Convert.ToInt32(tokens[i]));
        }
        
        return stack.Pop();
    }
}