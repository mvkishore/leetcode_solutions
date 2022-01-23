public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        int first = int.MaxValue;
        int second = int.MaxValue;
        
        foreach(var n in nums){
            if(n <= first)
                first = n;
            else if(n <= second)
                second = n;
            else return true;
        }
        return false;
    }
}