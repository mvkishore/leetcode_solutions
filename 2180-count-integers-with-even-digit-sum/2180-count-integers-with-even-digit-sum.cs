public class Solution {
    public int CountEven(int num) {
        int count = 0;
        int i = 1;
        while(i<= num){
            int sum = DigitSum(i);
            if(sum % 2 == 0)
                count++;
            i++;
        }
        return count;
    }
    private int DigitSum(int num){
        int sum = 0;
        while(num > 0){
            int d = num % 10;
            num = num /10;
            sum += d;
        }
        return sum;
    }
}