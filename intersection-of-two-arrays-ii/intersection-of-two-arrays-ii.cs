public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        Dictionary<int, int> counter = new Dictionary<int, int>();
        
        foreach(var num in nums1){
            if(!counter.ContainsKey(num))
                counter.Add(num, 0);
            counter[num]++;
        }
        
        IList<int> result = new List<int>();
        foreach(var num in nums2){
            if(counter.ContainsKey(num) && counter[num] > 0){
                result.Add(num);
                counter[num]--;
            }
        }
        
        return result.ToArray();
    }
}