public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> seen = new HashSet<int>();
        while(!seen.Contains(n)){
            seen.Add(n);
            n = GetDigitSum(n);
            if(n == 1)
                return true;
        }
        return false;
    }
    
    public int GetDigitSum(int n){
        int sum = 0;
        while(n > 0){
            int d = n % 10;
            sum += (d*d);
            n = n / 10;
        }
        return sum;
    }
}