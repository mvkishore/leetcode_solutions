public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        StringBuilder str = new StringBuilder();
        if(numerator == 0)
            return "0";
        
        if(numerator < 0 ^ denominator < 0)
            str.Append("-");
        
        long numer = Math.Abs((long) numerator);
        long denom = Math.Abs((long) denominator);
        
        var left = numer / denom;
        str.Append(left.ToString());
        var rem = numer % denom;
        if(rem == 0)
            return str.ToString();
        
        str.Append(".");
        
        Dictionary<long, long> seenReminder = new Dictionary<long, long>();
        while(rem > 0){
            if(seenReminder.ContainsKey(rem)){
                str.Insert((int)seenReminder[rem], '(');
                str.Append(')');
                return str.ToString();
            }
            seenReminder.Add(rem, str.Length);
            rem = rem * 10;
            str.Append((rem / denom).ToString());
            rem = rem % denom;
        }
        return str.ToString();
    }
}