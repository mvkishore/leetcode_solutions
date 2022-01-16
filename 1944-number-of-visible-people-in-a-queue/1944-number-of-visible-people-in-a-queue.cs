public class Solution {
    public int[] CanSeePersonsCount(int[] heights) {
        int n = heights.Length;//7
        Stack<int> stack = new Stack<int>();
        int[] res = new int[n];
        
        for(int i=n-1; i>=0; i--){
            int count = 0;
            while(stack.Count > 0 && heights[stack.Peek()] < heights[i]){
                count++;
                stack.Pop();
            }
            
            if(stack.Count > 0)
                count++;
            
            stack.Push(i);
            res[i] = count;
        }
        return res;
    }
}