/*
"aabab"
    "a"  "abab"
                                        
    
    "aabab"  ""
    
    
    ["a", "a", "b","a", "b"], ["a", "a", "bab"], ["a", "aba", "b"]
    ["aa", "b","a", "b"]["aa", "bab"]
    
    */

public class Solution {
    public IList<IList<string>> Partition(string s) {
        IList<IList<string>> result = new List<IList<string>>();
        IList<string> current = new List<string>();
        bool[,] memo = new bool[s.Length, s.Length];
        
        Partition(s, 0, current, result, memo);
        return result;
    }
    
    private void Partition(string s, int start, IList<string> current, IList<IList<string>> result, bool[,] memo)
    {
        if(start >= s.Length){
            result.Add(new List<string>(current));
            return;
        }
        
        for(int i=start; i< s.Length; i++){
            if(s[start] == s[i] && (i - start <= 2 || memo[start+1, i - 1])){
                memo[start, i] = true;
                current.Add(s.Substring(start, i-start + 1));
                Partition(s, i+1, current, result, memo);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
            
    private bool CheckPalindrome(string s, int start, int end) {
        while(start < end){
            if(s[start++] != s[end--]) return false;
        }
        return true;
    }
}