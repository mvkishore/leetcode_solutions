public class Solution {
    public string CustomSortString(string order, string s) {
        int[] counter = new int[26];
        foreach(var c in s)
            counter[c - 'a']++;
        
        StringBuilder sb = new StringBuilder();
        
        foreach(var c in order){
            while(counter[c-'a'] > 0){
                sb.Append(c);
                counter[c - 'a']--;
            }
        }
        
        for(int i=0; i<26; i++){
            while(counter[i] > 0){
                sb.Append((char)(i+'a'));
                counter[i]--;
            }
        }
        
        return sb.ToString();
    }
}