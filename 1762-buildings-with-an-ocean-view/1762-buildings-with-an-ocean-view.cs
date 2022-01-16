public class Solution {
    public int[] FindBuildings(int[] heights) {
        Stack<int> stack = new Stack<int>();
        
        int n = heights.Length;
        for(int i=n-1; i>=0; i--){
            if(stack.Count == 0 || heights[i] > heights[stack.Peek()])
                stack.Push(i);
        }
        
        int[] res = new int[stack.Count];
        int j = 0;
        while(stack.Count > 0){
            res[j++] = stack.Pop();
        }
        return res;
    }
}