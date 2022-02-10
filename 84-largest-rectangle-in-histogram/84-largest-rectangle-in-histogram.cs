public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length, maxArea = 0;
        if(n < 3)
            return Math.Max(heights.Max(), heights.Min() * n);
        Stack<int> seenHeights = new Stack<int>();
        
        seenHeights.Push(-1);
        
        for(int i=0; i<n; i++)
        {
            int curHeight = heights[i];
            
            while(seenHeights.Peek() != -1 && heights[seenHeights.Peek()] >= curHeight){
                var h = heights[seenHeights.Pop()];
                int r = i -1, l = seenHeights.Peek();
                maxArea = Math.Max(maxArea, h * (r - l));
            }
            
            seenHeights.Push(i);
        }
        
        while(seenHeights.Peek() != -1){
            var h = heights[seenHeights.Pop()];
            int r = n - 1, l = seenHeights.Peek();
            maxArea = Math.Max(maxArea, h * (r - l));
        }
        
        return maxArea;
    }
}