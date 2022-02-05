public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        HashSet<string> words = new HashSet<string>();
        foreach(var word in wordDict)
            words.Add(word);
        bool?[] memo = new bool?[s.Length];
        
        return WordBreak(s, 0, words, memo).Value;
    }
    
    public bool? WordBreak(string s,int cur,HashSet<string> words, bool?[] memo)
    {
        if(cur == s.Length)
            return true;
        if(memo[cur] != null)
            return memo[cur].Value;
        
        StringBuilder sb = new StringBuilder();
        
        for(int i=cur; i< s.Length; i++){
            sb.Append(s[i]);
            if(words.Contains(sb.ToString()) && WordBreak(s, i + 1, words, memo).Value){
                return memo[cur] = true;
            }
        }
        return memo[cur] = false;
    }
}