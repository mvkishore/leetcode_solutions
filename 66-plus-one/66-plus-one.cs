public class Solution {
    public int[] PlusOne(int[] digits) {
        int n = digits.Length;
        int i = n -1;
        
        while(i >= 0 && digits[i] == 9)
            i--;
        int[] res;
        if(i < 0)
        {
            res = new int[n + 1];
            res[0] = 1;
            return res;
        }
        
        res = new int[n];
        res[i] = digits[i] + 1;
            
        for(int j = 0; j < i; j++)
            res[j] = digits[j];

        return res;
    }
}
    