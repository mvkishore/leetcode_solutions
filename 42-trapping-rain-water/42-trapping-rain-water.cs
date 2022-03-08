public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        
        int[] leftMax = new int[n];
        int[] rightMax = new int[n];
        
        leftMax[0] = height[0];
        rightMax[n - 1] = height[n - 1];
        for(int i = 1; i<n; i++){
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
            rightMax[n - 1 - i] = Math.Max(rightMax[n - i], height[n - 1 - i]);
        }
        
        int water = 0;
        for(int i=0; i<n; i++){
            water += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }
        return water;
    }
}
/*
[0,1,0,2,1,0,1,3,2,1,2,1]

[0,1,1,2,2,2,2,3,3,3,3,3]
[3,3,3,3,3,3,3,3,2,2,2,1] 
*/
