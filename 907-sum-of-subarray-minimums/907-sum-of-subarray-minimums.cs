public class Solution {
    public int SumSubarrayMins(int[] arr) {
        long[] minArrCounts = GetMinSubArrayCounts(arr);
        
        long res = 0, MOD = (long)1e9 + 7;
        for(int i=0; i<arr.Length; i++){
            res = (res + (arr[i] * minArrCounts[i]) % MOD ) % MOD;
        }
        
        return (int) res;
    }
    
    private long[] GetMinSubArrayCounts(int[] arr){
        int n = arr.Length;
        long[] leftCounts = new long[n];
        Stack<(int idx, int count)> monoStack = new Stack<(int,int)>();
        
        for(int i=0; i<n; i++){
            int count = 1;
            while(monoStack.Count > 0 && arr[monoStack.Peek().idx] > arr[i]){
                count += monoStack.Pop().count;
            }
            monoStack.Push((i, count));
            leftCounts[i] = count;
        }
        monoStack.Clear();
        
        long[] rightCounts = new long[n];
        for(int i= n - 1; i >= 0; i--){
            int count = 1;
            while(monoStack.Count > 0 && arr[monoStack.Peek().idx] >= arr[i]){
                count += monoStack.Pop().count;
            }
            monoStack.Push((i, count));
            rightCounts[i] = count;
        }
        
        var counts = new long[n];
        for(int i=0; i < n; i++){
            counts[i] = leftCounts[i] * rightCounts[i];
        }
        return counts;
    }
}