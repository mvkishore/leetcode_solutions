public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        Stack<int> stack = new Stack<int>();
        Dictionary<int, int> indxMap = new Dictionary<int, int>();
        int n = pushed.Length;
        for(int i=0; i<n; i++){
            indxMap.Add(pushed[i], i);
        }
        int lastPush = -1;
        foreach(var p in popped){
            int indx = indxMap[p];
            for(int i = lastPush + 1; i <= indx; i++){
                stack.Push(pushed[i]);
            }
            lastPush = Math.Max(lastPush, indx);
            if(stack.Peek() != p)
                return false;
            stack.Pop();
        }
        return true;
    }
}
    
    
    