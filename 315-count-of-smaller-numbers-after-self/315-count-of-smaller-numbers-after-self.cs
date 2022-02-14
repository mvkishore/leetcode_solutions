public class Solution {
    public class Num {
        public int val;
        public int indx;
        public Num(int val, int indx){
            this.val = val;
            this.indx = indx;
        }
    }
    public IList<int> CountSmaller(int[] nums) {
        int n = nums.Length;
        int[] counts = new int[n];
        Num[] Nums = new Num[n];
        
        for(int i=0; i < n; i++)
            Nums[i] = new Num(nums[i], i);
        
        MergeSort(Nums, 0, n-1, counts);
        
        return counts;
    }
    
    private void MergeSort(Num[] nums, int left, int right, int[] counts)
    {
        if(left >= right)
            return;
        int mid = (left + right) / 2;
        MergeSort(nums, left, mid, counts);
        MergeSort(nums, mid+1, right, counts);
        
        Merge(nums, left, mid, right, counts);
    }
    
    private void Merge(Num[] nums, int left, int mid, int right, int[] counts)
    {
        int i=left, j=mid+1, totalLeftJumps = 0;
        List<Num> merged = new List<Num>();
        
        while(i < mid + 1 && j < right + 1){
            if(nums[i].val > nums[j].val){
                totalLeftJumps++;
                merged.Add(nums[j]);
                j++;
            }else{
                counts[nums[i].indx] += totalLeftJumps;
                merged.Add(nums[i]);
                i++;
            }
        }
        
        while(i < mid + 1){
            counts[nums[i].indx] += totalLeftJumps;
            merged.Add(nums[i]);
            i++;
        }
        
        while(j < right + 1){
            merged.Add(nums[j]);
            j++;
        }
        
        j=0;
        for(i=left; i<=right; i++){
            nums[i] = merged[j++];
        }
    }
}