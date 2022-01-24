public class Solution {
    public bool DetectCapitalUse(string word) {
        bool isFirstCapital = (word[0] >= 'A' && word[0] <= 'Z');
        int len = word.Length;
        
        if(len == 1)
            return true;
        
        if(isFirstCapital){
            return Validate(true, word) || Validate(false, word);
        } else {
            return Validate(false, word);
        }
    }
    
    private bool Validate(bool capital, string word)
    {
        char lower = (capital) ? 'A' : 'a';
        char upper = (capital) ? 'Z' : 'z';
        for(int i=1; i<word.Length; i++){
            if(!(word[i] >= lower && word[i] <= upper))
                return false;
        }
        
        return true;
    }
    
}