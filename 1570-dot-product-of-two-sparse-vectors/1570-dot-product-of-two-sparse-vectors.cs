public class SparseVector {
    private Dictionary<int, int> values;
    public SparseVector(int[] nums) {
        values = new Dictionary<int, int>();
        for(int i=0; i<nums.Length; i++){
            if(nums[i] > 0)
                values[i] = nums[i];
        }
    }
    
    public Dictionary<int, int> Values => values;
    
    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec) {
        if(values.Count > vec.Values.Count)
            return vec.DotProduct(this);
        
        int res = 0;
        foreach(var key in values.Keys){
            if(vec.Values.ContainsKey(key)){
                res += (vec.Values[key] * values[key]);
            }
        }
        return res;
    }
}

// Your SparseVector object will be instantiated and called as such:
// SparseVector v1 = new SparseVector(nums1);
// SparseVector v2 = new SparseVector(nums2);
// int ans = v1.DotProduct(v2);