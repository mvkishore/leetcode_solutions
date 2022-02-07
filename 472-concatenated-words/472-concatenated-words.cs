public class Solution {
    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
        HashSet<string> wordSet = new HashSet<string>();
        foreach(var word in words)
            wordSet.Add(word);
        
        IList<string> res = new List<string>();
        foreach(var word in words){
            int count = GetWordsCount(word, wordSet);
            if(count > 1)
                res.Add(word);
        }
        return res;
    }
    
    private int GetWordsCount(string word, HashSet<string> wordSet){
        int?[] memo = new int?[word.Length];
        return GetWordsCount(word, 0, memo, wordSet).Value;
    }
    
    private int? GetWordsCount(string word, int start, int?[] memo, HashSet<string> wordSet)
    {
        if(start >= word.Length)
            return 0;
        
        if(memo[start] != null)
            return memo[start];
        
        StringBuilder sb = new StringBuilder();
        
        for(int i=start; i< word.Length; i++){
            sb.Append(word[i]);
            var str = sb.ToString();
            if(wordSet.Contains(str)){
                var res = GetWordsCount(word, i+1, memo, wordSet).Value;
                if(res > -1){
                    return memo[start] = 1 + res;
                }
            }
        }
        return memo[start] = -1;
    }
}