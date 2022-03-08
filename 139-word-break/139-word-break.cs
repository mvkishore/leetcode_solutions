public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        HashSet<string> wordSet = new HashSet<string>();
        
        foreach(var word in wordDict)
            wordSet.Add(word);
        
        bool?[] memo = new bool?[s.Length];
        return CanBreak(s, 0, wordSet, memo).Value;
    }
    
    private bool? CanBreak(string s, int start, HashSet<string> wordDict, bool?[] memo)
    {
        if(start == s.Length)
            return true;
        
        if(memo[start] != null)
            return memo[start];
        
        StringBuilder sb = new StringBuilder();
        
        for(int i=start; i < s.Length; i++){
            sb.Append(s[i]);
            if(wordDict.Contains(sb.ToString()) && CanBreak(s, i+1, wordDict, memo) == true)
                return memo[start] = true;
        }
        return memo[start] = false;
    }
}