public class Solution {
    public bool IsNumber(string s) {
        var numberParts = s.Split(".");
        var eParts = s.Split(new[]{'e', 'E'});
        
        if(eParts.Length > 2) return false;
        
        bool isDecimal = false;
        if(numberParts.Length == 2)
            isDecimal = true;
        
        return (!isDecimal) ? IsValidInteger(s) : IsValidDecimal(numberParts);
    }
    
    private bool IsValidInteger(string s, bool skipStartCheck=false){
        int n = s.Length;
        if(n == 0)
            return false;
        int i = 0;
        if(s[i] == '+')
            i++;
        else if(s[i] == '-')
            i++;
        
        while(i < n && char.IsDigit(s[i]))
            i++;
        
        if(!skipStartCheck){
            if(i == 0 || !char.IsDigit(s[i-1]))
                return false;
        }
        
        if(i < n && (s[i] == 'e' || s[i] == 'E'))
            return IsValidInteger(s.Substring(i+1, n - i - 1));
        return i == n;
    }
    
    private bool IsValidDecimal(string[] numberParts)
    {
        var leftPart = numberParts[0];
        var rightPart = numberParts[1];
        
        if((string.IsNullOrEmpty(leftPart) ||  leftPart == "-" || leftPart == "+") 
           && string.IsNullOrEmpty(rightPart))
            return false;
        
        if(leftPart.Contains("E") || leftPart.Contains("e"))
            return false;
        
        if(!string.IsNullOrEmpty(leftPart) && leftPart != "-" && leftPart != "+" 
           && !IsValidInteger(leftPart))
            return false;
        
         if(!string.IsNullOrEmpty(rightPart) &&
            (rightPart[0] == '+' || rightPart[0] == '-' || !IsValidInteger(rightPart, !string.IsNullOrEmpty(leftPart))))
            return false;
        
        return true;
    }
    
}