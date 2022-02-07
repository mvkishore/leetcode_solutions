/*
Explanation from Lee's post
---------------------------

The order in initial arrays doesn't matter,
my first intuition is to sort the array.

For each number A[i]:

There are i smaller numbers,
so there are 2 ^ i sequences in which A[i] is maximum.
we should do res += A[i] * 2^i

There are n - i - 1 bigger numbers,
so there are 2 ^ (n - i - 1) sequences in which A[i] is minimum.
we should do res -= A[i] * 2^(n - i - 1)

Done.

*/
public class Solution {
    public int SumSubseqWidths(int[] nums) {
        long res = 0, n = nums.Length, MOD = 1_000_000_007, pow = 1;
        Array.Sort(nums);
        for(int i=0; i < n; i++, pow = (2 * pow) % MOD){
           res = (res + nums[i] * pow - nums[n - i - 1] * pow) % MOD;
        }
        return (int) res;
    }
}


    
