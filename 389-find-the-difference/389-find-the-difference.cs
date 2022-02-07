public class Solution {
    public char FindTheDifference(string s, string t) {
        int[] counter = new int[26];
        foreach(var c in s)
            counter[c-'a']++;
        
        foreach(var c in t)
            counter[c-'a']--;
        
        for(int i=0;i<26; i++)
            if(counter[i] == -1)
                return (char) (i + 'a');
        
        return ' ';
    }
}