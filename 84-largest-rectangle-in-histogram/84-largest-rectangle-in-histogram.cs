public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length, maxArea = 0;
        Stack<int> seenHeights = new Stack<int>();
        
        seenHeights.Push(-1);
        for(int i=0; i<n; i++){
            
            while(seenHeights.Peek() != -1 && heights[seenHeights.Peek()] >= heights[i]){
                int h = heights[seenHeights.Pop()];
                int r = i - 1, l = seenHeights.Peek();
                maxArea = Math.Max(maxArea, (r - l) * h);
            }
            
            seenHeights.Push(i);
        }
        
        while(seenHeights.Peek() != -1){
            int h = heights[seenHeights.Pop()];
            int r = n - 1, l = seenHeights.Peek();
            maxArea = Math.Max(maxArea, (r - l) * h);
        }
        
        return maxArea;
    }
}