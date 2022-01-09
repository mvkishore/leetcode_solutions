public class Solution {
    public int WordCount(string[] startWords, string[] targetWords) {
        HashSet<int>[] startSet = new HashSet<int>[27];
        
        foreach(var word in startWords){
            int l = word.Length;
            if(startSet[l] == null)
                startSet[l] = new HashSet<int>();
            
            startSet[l].Add(GetNumber(word));
        }
        
        int result = 0;
        foreach(var word in targetWords){
            int l = word.Length;
            if(startSet[l-1] == null)
                continue;
            
            int n = GetNumber(word);
            
            for(int i=0; i<26; i++){
                int mask = 1 << i;
                if(startSet[l-1].Contains(n & ~mask)){
                    result++;
                    break;
                }
            }
        }
        return result;
    }
    
    private int GetNumber(string s)
    {
        int n = 0;
        foreach(var c in s){
            n |= 1 << (c - 'a');
        }
        return n;
    }
}