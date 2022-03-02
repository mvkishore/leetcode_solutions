public class Solution {
    public double MyPow(double x, int n) {
        long N = n;
        if(N < 0){
            N = -N;
            x = 1 / x;
        }
        
        return Pow(x, N);
    }
    
    private double Pow(double x, long N){
        if(N == 0)
            return 1.0;
        var half = Pow(x, N / 2);
        if(N % 2 == 1)
            return half * half * x;
        return half * half;
    }
}