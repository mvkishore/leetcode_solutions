public class Solution {
    public IList<string> LetterCombinations(string digits) {
        List<string> result = new List<string>();
        
        if(string.IsNullOrEmpty(digits))
            return result;
        
        IList<StringBuilder> cur = new List<StringBuilder>();
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
        cur.Add(new StringBuilder());
        Generate(digits, 0, result, cur, digitMap);
        return result;
    }
    
    private void Generate(string digits, int start, List<string> result, IList<StringBuilder> cur, Dictionary<char, List<char>> digitMap)
    {
        if(start == digits.Length){
            result.AddRange(cur.Select(x=>x.ToString()));
            return;
        }
        
        var digit = digits[start];
        var list = new List<StringBuilder>();
        
        foreach(var c in digitMap[digit]){
            for(int i=0; i<cur.Count; i++){
                var sb = new StringBuilder(cur[i].ToString());
                sb.Append(c);
                list.Add(sb);
            }
        }
        Generate(digits, start + 1, result, list, digitMap);
    }
}




