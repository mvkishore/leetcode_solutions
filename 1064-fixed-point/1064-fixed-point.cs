public class Solution {
    public int FixedPoint(int[] arr) {
        int lo = 0, hi = arr.Length - 1;
        while(lo < hi){
            int mid = lo + (hi - lo) / 2;
            if(arr[mid] - mid < 0)
                lo = mid + 1;
            else
                hi = mid;
        }
        return arr[lo] == lo ? arr[lo] : -1;
    }
}