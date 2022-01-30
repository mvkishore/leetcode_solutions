public class Solution {
    Dictionary<int, char> AllSymbols = new Dictionary<int,char>(){
        {1, 'I'},
        {5, 'V'},
        {10, 'X'},
        {50, 'L'},
        {100, 'C'},
        {500, 'D'},
        {1000, 'M'}
    };
    
    
    public string IntToRoman(int num) {
        int len = num.ToString().Length;
        StringBuilder sb = new StringBuilder();
        int mul = 1;
        
        while(len > 0){
            int d = num % 10;
            
            if(d > 0)
                sb.Insert(0, GetString(d * mul, mul));
            
            mul *= 10;
            num = num / 10;
            len--;
        }
        
        return sb.ToString();
    }
    
    private string GetString(int n, int mul)
    {
        StringBuilder sb = new StringBuilder();
        if(n == mul){
            sb.Append(AllSymbols[mul]);
        }else if(n < 4 * mul){
           while(n > 0){
                sb.Append(AllSymbols[1 * mul]);
                n -= mul;
            }
        }else if(n < 5 * mul){
            sb.Append(AllSymbols[1 * mul]);
            sb.Append(AllSymbols[5 * mul]);
        }
        else if(n == 5 * mul){
            sb.Append(AllSymbols[5 * mul]);
            
        }else if(n < 9 * mul){
            sb.Append(AllSymbols[5 * mul]);
            n -= 5*mul;
            
            while(n > 0){
                sb.Append(AllSymbols[1 * mul]);
                n -= mul;
            }
        } else {
            sb.Append(AllSymbols[1 * mul]);
            sb.Append(AllSymbols[10 * mul]);
        }
        return sb.ToString();
    }
}