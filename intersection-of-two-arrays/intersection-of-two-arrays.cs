public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        List<int> res = new List<int>();
        HashSet<int> seen = new HashSet<int>();
        
        foreach(var n in nums1)
            seen.Add(n);
        
        foreach(var n in nums2){
            if(seen.Contains(n)){
                res.Add(n);
                seen.Remove(n);
            }
        }
        
        return res.ToArray();
    }
}