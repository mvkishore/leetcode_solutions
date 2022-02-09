public class Solution {
    public IList<string> LetterCombinations(string digits) {
        List<string> result = new List<string>();
        
        if(string.IsNullOrEmpty(digits))
            return result;
        
        Dictionary<char, List<char>> digitMap = new Dictionary<char, List<char>>(){
            {'2', new List<char>{'a', 'b','c'}},
            {'3', new List<char>{'d', 'e','f'}},
            {'4', new List<char>{'g', 'h','i'}},
            {'5', new List<char>{'j', 'k','l'}},
            {'6', new List<char>{'m', 'n','o'}},
            {'7', new List<char>{'p', 'q','r', 's'}},
            {'8', new List<char>{'t', 'u','v', }},
            {'9', new List<char>{'w', 'x','y', 'z'}}
        };
        Generate(digits, 0, result, new StringBuilder(), digitMap);
        return result;
    }
    
    private void Generate(string digits, int start, List<string> result, StringBuilder cur, Dictionary<char, List<char>> digitMap)
    {
        if(start == digits.Length){
            result.Add(cur.ToString());
            return;
        }
        
        var digit = digits[start];
        
        foreach(var c in digitMap[digit]){
            cur.Append(c);
            Generate(digits, start + 1, result, cur, digitMap);
            cur.Length--;
        }
    }
}




