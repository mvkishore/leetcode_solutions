public class Solution {
    public int BitwiseComplement(int n) {
        if(n == 0)
            return 1;
        
        int res=0, i=0;
        while(n > 0)
        {
            if((n & 1) == 0){
                int x = 1 << i;
                res |= x;
            }
            n = n >> 1;
            i++;
        }
        return res;
    }
}