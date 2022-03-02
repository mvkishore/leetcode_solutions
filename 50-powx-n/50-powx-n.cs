public class Solution {
    public double MyPow(double x, int n) {
        long N = n;
        if(N < 0){
            N = -N;
            x = 1 / x;
        }
        
        var half = x;
        double res = 1;
        for(long i=N; i > 0; i/=2){
            if((i % 2) == 1)
                res = res * half;
            half = half * half;
        }
        return res;
    }
}