/*
 
 1 zero => product of all nums at one place, remaining all 0s
 > 1 zero -> all zeros
 
 no zeros => 
    [1,2,3,4]
    [24, ]

*/

public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length, zeroCount = 0, totalProduct = 1, singleZeroIndx = -1;
        
        for(var i =0; i< n; i++){
            var num = nums[i];
            if(num == 0){
                zeroCount++;
                singleZeroIndx = i;
            }
            else
                totalProduct *= num;
        }
        
        if(zeroCount > 1)
            return new int[n];
        
        if(zeroCount == 1){
            var res = new int[n];
            res[singleZeroIndx] = totalProduct;
            return res;
        }
        
        int[] result = new int[n];
        result[0] = 1;
        
        int L = nums[0];
        for(int i=1; i<nums.Length; i++){
            result[i] = L;
            L *= nums[i];
        }
        int R = nums[nums.Length - 1];          
        for(int j=nums.Length - 2; j >=0; j--){
            result[j] *= R;
            R *= nums[j];
        }
        
        return result;
    }
}