public class Solution {
    public int[] GetModifiedArray(int length, int[][] updates) {
        int[] arr = new int[length];
        
        foreach(var update in updates){
            int val = update[2];
            arr[update[0]]+= val;
            
            if(update[1] + 1 < length)
                arr[update[1] + 1] -= val;
        }
        for(int i=1; i<length; i++){
            arr[i] += arr[i-1];
        }
        return arr;
    }
}

