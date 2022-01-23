public class Solution {
    public int FirstUniqChar(string s) {
        int[] counter = new int[26];
        foreach(var c in s)
            counter[c-'a']++;
        
        for(int i=0; i<s.Length; i++){
            if(counter[s[i] - 'a'] == 1){
                return i;
            }
        }
        return -1;
    }
}