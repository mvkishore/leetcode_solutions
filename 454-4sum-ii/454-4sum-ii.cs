public class Solution {
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4) {
        Dictionary<int, int> complements = new Dictionary<int,int>();
        foreach(var a in nums1)
            foreach(var b in nums2)
                if(!complements.ContainsKey(a+b))
                    complements.Add(a+b, 1);
                else
                    complements[a+b]++;
        int count = 0;
        foreach(var c in nums3)
            foreach(var d in nums4)
                if(complements.ContainsKey(-(c+d)))
                    count += complements[-(c+d)];
        
        return count;
    }
}