public class Solution {
    public string RemoveKdigits(string num, int k) {
        LinkedList<char> stack = new LinkedList<char>();
        
        for(int i=0; i<num.Length; i++){
            while(stack.Count > 0 && k > 0 && stack.Last.Value > num[i])
            {
                stack.RemoveLast();
                k--;
            }
            stack.AddLast(num[i]);
        }
        
        while(k > 0){
            stack.RemoveLast();
            k--;
        }
        
        StringBuilder sb = new StringBuilder();
        bool leadingZero = true;
        while(stack.Count > 0){
            if(leadingZero && stack.First.Value == '0'){
                stack.RemoveFirst();
                continue;
            }
            leadingZero = false;
            sb.Append(stack.First.Value);
            stack.RemoveFirst();
        }
        
        if(sb.Length == 0) return "0";
        
        return sb.ToString();
    }
}