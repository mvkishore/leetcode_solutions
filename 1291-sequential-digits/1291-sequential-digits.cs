/*

11  15

12
23
34
45
56
78
89

123
234
345
456
567
678
789



132 --> 100 -

132-- 999,      =
1000 --- 9999,  =
10000 -- 13000  =


Sequential digits: 



*/

public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        int lowLen = low.ToString().Length, highLen = high.ToString().Length;
        IList<int> res = new List<int>();
       
        for(int i=lowLen; i<= highLen; i++)
            GenerateSequentialDigits(low, i, high, res);
        
        return res;
    }
    
    private void GenerateSequentialDigits(int low, int len, int high, IList<int> res)
    {
        var digits = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9};
        int i=0;
        while(i + len <= 9){
            int l = 0;
            int num = 0;
            while(l < len){
                num = num * 10 + digits[i + l];
                l++;
            }
            if(num >= low && num <= high)
                res.Add(num);
            i++;
        }
    }
    
    
}