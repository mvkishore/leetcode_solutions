/*
From Lee's solution, 

res = sum(A[i] * f(i))
where f(i) is the number of subarrays,
in which A[i] is the minimum.

*/
public class Solution {
    public int SumSubarrayMins(int[] arr) {
        long[] f = GetSubArraysCount(arr);
        
        long res = 0, MOD = (long)1e9 + 7;
        for(int i=0; i< arr.Length; i++)
            res = (res + (arr[i] * f[i]) % MOD) % MOD;
        
        return (int) res;
    }
    
    private long[] GetSubArraysCount(int[] arr)
    {
        int n = arr.Length;
        long[] leftCounts = new long[n];
        Stack<(int count, int idx)> monoStack = new Stack<(int count, int idx)>();
        
        for(int i=0; i < n; i++){
            int count = 1;
            while(monoStack.Count > 0 && arr[monoStack.Peek().idx] > arr[i])
                count += monoStack.Pop().count;
            
            leftCounts[i] = count;
            monoStack.Push((count, i));
        }
        
        monoStack.Clear();
        long[] rightCounts = new long[n];
        for(int i=n-1; i >= 0; i--){
            int count = 1;
            while(monoStack.Count > 0 && arr[monoStack.Peek().idx] >= arr[i])
                count += monoStack.Pop().count;
            
            rightCounts[i] = count;
            monoStack.Push((count, i));
        }
        long[] counts = new long[n];
        for(int i=0; i<n; i++)
            counts[i] = leftCounts[i] * rightCounts[i];
        
        return counts;
    }
}