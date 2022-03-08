public class Solution {
    Dictionary<int, string> LessThan20 = new Dictionary<int, string>(){
        {10, "Ten"},
        {11, "Eleven"},
        {12, "Twelve"},
        {13, "Thirteen"},
        {14, "Fourteen"},
        {15, "Fifteen"},
        {16, "Sixteen"},
        {17, "Seventeen"},
        {18, "Eighteen"},
        {19, "Nineteen"}
    };
    Dictionary<int, string> Tens = new Dictionary<int, string>(){
        {1, "Ten"},
        {2, "Twenty"},
        {3,"Thirty"},
        {4,"Forty"},
        {5,"Fifty"},
        {6,"Sixty"},
        {7,"Seventy"},
        {8,"Eighty"},
        {9,"Ninety"}
    };
    Dictionary<int, string> Ones = new Dictionary<int, string>(){
        {1, "One"},
        {2, "Two"},
        {3, "Three"},
        {4, "Four"},
        {5, "Five"},
        {6, "Six"},
        {7, "Seven"},
        {8, "Eight"},
        {9, "Nine"}
    };
    
    public string NumberToWords(int num) {
        if(num == 0)
            return "Zero";
        
        StringBuilder sb = new StringBuilder();
        
        int billions = num / 1000000000;
        num = num % 1000000000;
        if(billions > 0){
            sb.Append(ThreeNumToWord(billions));
            sb.Append(" Billion");
        }
        
        int millions = num / 1000000; // 9
        num = num % 1000000;// 100
        if(millions > 0){
            if(sb.Length > 0)
                sb.Append(" ");
            sb.Append(ThreeNumToWord(millions));
            sb.Append(" Million");
        }
        
        int thousands = num / 1000;
        num = num % 1000;
        if(thousands > 0){
            if(sb.Length > 0)
                sb.Append(" ");
            sb.Append(ThreeNumToWord(thousands));
            sb.Append(" Thousand");
        }
        if(num > 0){
            if(sb.Length > 0)
                sb.Append(" ");
            sb.Append(ThreeNumToWord(num));
        }
        return sb.ToString();
    }
    
    private string ThreeNumToWord(int num){
        int hundreds = num / 100; // 9
        num = num % 100;// 100
        
        StringBuilder sb = new StringBuilder();
        if(hundreds > 0){
            sb.Append(Ones[hundreds]);
            sb.Append(" Hundred");
        }
        
        if(num > 0){
            if(sb.Length > 0)
                sb.Append(" ");
            sb.Append(TwoNumToWord(num));
        }
        return sb.ToString();
    }
    
    private string TwoNumToWord(int num){
        StringBuilder sb = new StringBuilder();
        if(num >= 10 && num < 20){
            sb.Append(LessThan20[num]);
            return sb.ToString();
        }
        
        int tens = num / 10;
        num = num % 10;
        
        if(tens > 0){
            if(sb.Length > 0)
                sb.Append(" ");
            sb.Append(Tens[tens]);
        }
        
        if(num > 0){
            if(sb.Length > 0)
                sb.Append(" ");
            
            sb.Append(Ones[num]);
        }
        return sb.ToString();
    }
}
/*
1--9 => 
11-19=>
10--90=>

1234567 => 
               
    567 => 5 hundred 
    67 => sixty seven
    */