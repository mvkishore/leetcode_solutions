public class Solution {
    public string RemoveKdigits(string num, int k) {
        Stack<char> stack = new Stack<char>();
        var digits = num.ToCharArray();
        
        for(int i=0; i<digits.Length; i++){
            while(stack.Count > 0 && k > 0 && stack.Peek() > digits[i])
            {
                stack.Pop();
                k--;
            }
            stack.Push(digits[i]);
        }
        while(k > 0)
        {
            stack.Pop();
            k--;
        }
        
        List<char> res = new List<char>();
        while(stack.Count > 0)
            res.Insert(0, stack.Pop());
        
        int j = 0;
        while(j < res.Count && res[j] == '0')
            j++;
        
        StringBuilder sb = new StringBuilder();
        for(;j<res.Count; j++){
            sb.Append(res[j]);
        }
        return sb.Length == 0 ? "0" : sb.ToString();
    }
}
