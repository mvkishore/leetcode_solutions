public class Solution {
    public bool DetectCapitalUse(string word) {
        bool isFirstCapital = char.IsUpper(word[0]);
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
        for(int i=1; i<word.Length; i++){
            if(capital){
                if(!char.IsUpper(word[i]))
                    return false;
            }
            else if(!char.IsLower(word[i]))
                return false;    
        }
        Console.WriteLine(true);
        return true;
    }
    
}