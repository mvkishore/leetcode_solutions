public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if(strs == null || strs.Length == 0)
            return string.Empty;
        int minLen = int.MaxValue;
        
        foreach(string str in strs)
            minLen = Math.Min(minLen, str.Length);
            
        int lo = 0, hi = minLen;
        while(lo < hi){
            int mid = hi - (hi - lo) /2;
            var isValid = CheckPrefix(strs, mid);
            if(isValid)
                lo = mid;
            else
                hi = mid - 1;
        }
        if(lo <= 0)
            return string.Empty;
        return strs[0].Substring(0, lo);
    }
    
    private bool CheckPrefix(string[] strs, int pos)
    {
        int n = strs.Length;
        string prefix = strs[0].Substring(0, pos);
        for(int i=0; i<n; i++){
            if(!strs[i].StartsWith(prefix))
                return false;
        }
        
        return true;
    }
}