public class Solution {
    //[4,5,6,7,0,1,2]
    public int Search(int[] nums, int target) {
        int low = 0, hi = nums.Length -1;
        
        while(low < hi){
            int mid = low + (hi - low) / 2;
            
            if(nums[mid] < nums[0])
                hi = mid;
            else
                low = mid + 1;
        }
        
        int res = Find(nums, 0, low - 1, target);
        if(res != -1)
            return res;
        return Find(nums, low, nums.Length - 1, target);
    }
    
    public int Find(int[] nums, int low, int hi, int target)
    {
        while(low <= hi){
            int mid = low + (hi - low) /2;
            if(nums[mid] == target)
                return mid;
            if(nums[mid] < target)
                low = mid + 1;
            else
                hi = mid - 1;
        }
        return -1;
    }
    
    
}

/*
[4,5,6,7,0,1,2]

[8,1,2,4,5,6,7] */