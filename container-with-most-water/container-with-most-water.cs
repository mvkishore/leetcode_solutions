public class Solution {
    public int MaxArea(int[] height) {
        int maxArea = 0, n = height.Length, l=0, r = n-1;
        while(l < r){
            int width = r - l;
            int length = Math.Min(height[l], height[r]);
            
            maxArea = Math.Max(maxArea, length * width);
            if(length == height[l])
                l++;
            else r--;
        }
        return maxArea;
    }
}