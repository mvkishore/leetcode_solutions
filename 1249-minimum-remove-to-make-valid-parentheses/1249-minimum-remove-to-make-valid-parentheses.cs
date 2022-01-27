public class Solution {
    public string MinRemoveToMakeValid(string s) {
        char[] charArray = s.ToCharArray();
        charArray = RemoveToMakeValid(charArray, '(', ')');
        
        Array.Reverse(charArray);
        charArray = RemoveToMakeValid(charArray, ')', '(');
        Array.Reverse(charArray);
        
        return new string(charArray);
    }
    
    private char[] RemoveToMakeValid(char[] charArray, char open, char close)
    {
        int n = charArray.Length;
        List<char> res = new List<char>();
        int count = 0;
        
        for(int i=0; i<n; i++){
            if(charArray[i] == open){
                count++;
            }else if(charArray[i] == close){
                count--;
            }
            
            if(count >= 0)
                res.Add(charArray[i]);
            else
                count = 0;
        }
        return res.ToArray();
    }
}