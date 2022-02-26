public class Solution {
    public int MaximumSwap(int num) {
        var digits = num.ToString().ToArray();
        int n = digits.Length;
        int[] rightMax = new int[n];
        rightMax[n - 1] = n - 1;
        
        for(int i = n-2; i>=0; i--){
            int d1 = digits[rightMax[i + 1]] - '0', d2 = digits[i + 1] - '0';
            var max = Math.Max(d1, d2);
            rightMax[i] = (max == d1) ? rightMax[i + 1] : i+1;
        }
        
        for(int i=0; i < n - 1;i++){
            if(digits[i] - '0' < digits[rightMax[i]] - '0'){
                var temp = digits[i];
                digits[i] = digits[rightMax[i]];
                digits[rightMax[i]] = temp;
                break;
            }
        }
        return Convert.ToInt32(new string(digits));
    }
}


//2736
   