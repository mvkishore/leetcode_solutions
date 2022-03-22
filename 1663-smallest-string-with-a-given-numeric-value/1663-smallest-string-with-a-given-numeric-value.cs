public class Solution {
    public string GetSmallestString(int n, int k) {
        int val = k - n;//73-5=68, 
        char[] result = Enumerable.Repeat('a', n).ToArray();
        int i=n-1;
        while(val >= 26){
            result[i--] = 'z';
            val -= 25;
        }
        result[i] = (char)('a' + val);
        return new string(result);
    }
}
