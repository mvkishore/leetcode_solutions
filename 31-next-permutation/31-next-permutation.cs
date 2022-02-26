//2 3 4 1 6 9 8 7 2  => {2, 7, 6}

//2 3 4 1 7 2 6


//7 6 4 3 2 2 1

public class Solution {
    public void NextPermutation(int[] nums) {
        int n = nums.Length;
        int i = n - 1;
        while(i > 0 && nums[i - 1] >= nums[i])
            i--;
        if(i == 0)
            Array.Reverse(nums);
        else {
            i = i - 1;
            int j = i + 1;
            while(j < n && nums[j] > nums[i])
                j++;
            Swap(nums, j-1, i);
            Reverse(nums, i+ 1, n - 1);
        }
    }
    
    private void Swap(int[] nums, int i, int j){
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
    
    private void Reverse(int[] nums, int s, int e){
        while(s < e){
            Swap(nums, s, e);
            s++;
            e--;
        }
    }
}