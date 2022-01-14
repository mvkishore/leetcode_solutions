/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int low = 1, hi = n;
        
        while(low < hi){
            int mid = low + (hi - low) / 2;
            
            if(IsBadVersion(mid))
                hi = mid;
            else
                low = mid + 1;
        }
        return low;
    }
}
    