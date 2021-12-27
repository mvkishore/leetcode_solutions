public class Solution {
    public int FindComplement(int num) {
        int n = 0;
        int i = 0;
        while(num > 0){
            if((num & 1) == 0 )
                n = n | (1 << i);
            
            num = num >> 1;
            i++;
        }
        return n;
    }
}