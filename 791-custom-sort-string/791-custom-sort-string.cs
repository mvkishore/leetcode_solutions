public class Solution {
    public string CustomSortString(string order, string s) {
        int[] sCounter = new int[26];
        
        foreach(var c in s)
            sCounter[c - 'a']++;
        
        StringBuilder sPerm = new StringBuilder();
        foreach(var c in order){
            while(sCounter[c - 'a'] > 0)
            {
                sPerm.Append(c);
                sCounter[c - 'a']--;
            }
        }
        
        for(int i=0; i<26; i++){
            while(sCounter[i] > 0)
            {
                sPerm.Append((char)(i + 'a'));
                sCounter[i]--;
            }
        }
        
        return sPerm.ToString();
    }
}