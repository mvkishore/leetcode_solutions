public class Solution {
    public int MaxArea(int[] height) {
        int l = 0, r = height.Length - 1;
        int maxArea = 0;
        while(l < r){
            int area = (r - l) * Math.Min(height[l], height[r]);
            maxArea = Math.Max(area, maxArea);
            
            if(height[l] < height[r])
                l++;
            else
                r--;
        }
        return maxArea;
    }
}