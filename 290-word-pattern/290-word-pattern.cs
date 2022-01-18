public class Solution {
    public bool WordPattern(string pattern, string s) {
        Dictionary<char, string> slots1 = new Dictionary<char, string>();
        Dictionary<string, char> slots2 = new Dictionary<string, char>();
        
        var words = s.Split(" ");
        int n = pattern.Length;
        if(n != words.Length)
            return false;
        
        for(int i=0; i<n; i++){
            var c = pattern[i];
            var word = words[i];
            
            if(slots1.ContainsKey(c)){
                if(slots1[c] != word)
                    return false;
            }
            else
                slots1[c] = word;
            
            if(slots2.ContainsKey(word)){
                if(slots2[word] != c)
                    return false;
            }
            else
                slots2[word] = c;
        }
        
        return true;
    }
}