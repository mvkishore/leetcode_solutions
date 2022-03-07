public class Solution {
    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
        HashSet<string> wordSet = new HashSet<string>();
        foreach(var w in words)
            wordSet.Add(w);
        
        var res = new List<string>();
        
        foreach(var w in words){
            wordSet.Remove(w);
            if(IsConcatenatedWord(w, wordSet))
                res.Add(w);
            wordSet.Add(w);
        }
        
        return res;
    }
    
    private bool IsConcatenatedWord(string word, HashSet<string> wordSet)
    {
        int n = word.Length;
        if(n == 0)
            return false;
        bool?[] memo = new bool?[n];
        
        return IsConcatenated(word, 0, wordSet, memo).Value;
    }
    
    private bool? IsConcatenated(string word, int indx, HashSet<string> wordSet, bool?[] memo)
    {
        if(indx == word.Length)
            return true;
        
        if(memo[indx] != null)
            return memo[indx];
        
        StringBuilder sb = new StringBuilder();
        
        for(int i = indx; i<word.Length; i++){
            var c = word[i];
            sb.Append(c);
            if(wordSet.Contains(sb.ToString()) && IsConcatenated(word, i + 1, wordSet, memo) == true)
            {
                return memo[indx] = true;
            }
        }
        
        return memo[indx] = false;
    }
}