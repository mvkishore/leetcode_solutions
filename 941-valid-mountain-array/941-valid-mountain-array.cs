public class Solution {
    public bool ValidMountainArray(int[] arr) {
        int len = arr.Length;
        if(len < 3)
            return false;
        
        int i=0;
        while(i + 1 < len && arr[i] < arr[i+1])
            i++;
        
        if(i == len - 1 || i == 0) return false;
        
        while(i + 1 < len && arr[i+1] < arr[i])
            i++;
        
        if(i < len - 1) return false;
        
        return true;
    }
}