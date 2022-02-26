public class Solution {
    public double MyPow(double x, int n) {
        long N = n;
        if(N < 0)
        {
            x = 1 / x;
            N = -N;
        }
        
        double ans = 1;
        double power = x;
        for(var i= N; i > 0; i /=2)
        {
            if((i % 2) == 1)
                ans = ans* power;
            
            power = power * power;
        }
        return ans;
    }
}