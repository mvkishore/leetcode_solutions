public class Solution {
    public int MaxArea(int[] height) {
        int n = height.Length, left = 0, right = n - 1;
        int area = 0;
        
        while(left < right){
            int width = right - left;
            area = Math.Max(width * Math.Min(height[left], height[right]), area);
            if(height[left] < height[right])
                left++;
            else
                right--;
        }
        return area;
    }
}