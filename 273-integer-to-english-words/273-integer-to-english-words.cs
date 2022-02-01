public class Solution {
    public string NumberToWords(int num) {
        if(num == 0)
            return Get1DigitNumStr(num);
        
        int THOUSAND = 1000, MILLION = 1000 * THOUSAND, BILLION = 1000 * MILLION;
        
        int billions = num / BILLION;
        int millions = (num - billions * BILLION) / MILLION;
        int thousands = (num - billions * BILLION - millions * MILLION) / THOUSAND;
        int remaining = num - billions * BILLION - millions * MILLION - thousands * THOUSAND;
        
        StringBuilder sb = new StringBuilder();
        if(billions > 0){
            sb.Append(GetNumberStr(billions));
            sb.Append(" Billion");
        }
        
        if(millions > 0){
            if(sb.Length > 0)
                sb.Append(" ");
            
            sb.Append(GetNumberStr(millions));
            sb.Append(" Million");
        }
        
        if(thousands > 0){
            if(sb.Length > 0)
                sb.Append(" ");
            
            sb.Append(GetNumberStr(thousands));
            sb.Append(" Thousand");
        }
        
        if(remaining > 0){
            if(sb.Length > 0)
                sb.Append(" ");
            
            sb.Append(GetNumberStr(remaining));
        }
        
        return sb.ToString();
    }
    //1-999
    //1-99
    //100s
    //
    //923
    //23
    public string GetNumberStr(int n)
    {
        int hundred = n / 100;
        int rem = n % 100;
        
        StringBuilder sb = new StringBuilder();
        if(hundred > 0){
            sb.Append(Get2DigitNumStr(hundred));
            sb.Append(" Hundred");
            
            if(rem > 0){
                sb.Append(" ");
                sb.Append(Get2DigitNumStr(rem));
            }
        } else {
            sb.Append(Get2DigitNumStr(rem));
        }
        return sb.ToString();
    }
    
    public string Get2DigitNumStr(int n){
        int tens = n / 10;
        int rem = n % 10;
        
        StringBuilder sb = new StringBuilder();
        if(tens > 0){
            if(n > 10 && n < 20){
                sb.Append(GetLessTwentyNumStr(n));
            }
            else if(rem != 0)
            {
                sb.Append(GetTensNumStr(tens));
                sb.Append(" ");
                sb.Append(Get1DigitNumStr(rem));
            } else {
                sb.Append(GetTensNumStr(tens));
            }
        } else {
            sb.Append(Get1DigitNumStr(rem));
        }
        return sb.ToString();
    }
    
    private string GetTensNumStr(int num){
        switch(num) {
            case 1: return "Ten";
            case 2: return "Twenty";
            case 3: return "Thirty";
            case 4: return "Forty";
            case 5: return "Fifty";
            case 6: return "Sixty";
            case 7: return "Seventy";
            case 8: return "Eighty";
            case 9: return "Ninety";
        }
        return "";
    }
    
    private string GetLessTwentyNumStr(int num){
        switch(num){
            case 11: return "Eleven";
            case 12: return "Twelve";
            case 13: return "Thirteen";
            case 14: return "Fourteen";
            case 15: return "Fifteen";
            case 16: return "Sixteen";
            case 17: return "Seventeen";
            case 18: return "Eighteen";
            case 19: return "Nineteen";
        }
        return  "";
    }
    private string Get1DigitNumStr(int num){
        switch(num) {
          case 0: return "Zero";
          case 1: return "One";
          case 2: return "Two";
          case 3: return "Three";
          case 4: return "Four";
          case 5: return "Five";
          case 6: return "Six";
          case 7: return "Seven";
          case 8: return "Eight";
          case 9: return "Nine";
        }
        return "";
    }
}