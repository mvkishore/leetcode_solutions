public class Solution {
    public uint reverseBits(uint n) {
        uint res = 0;
        for(int i=1; i<=32; i++) {
            res <<= 1;
            if((n & 1) == 1)
                res |= 1;
            n >>=1;
        }
        return res;
    }
}