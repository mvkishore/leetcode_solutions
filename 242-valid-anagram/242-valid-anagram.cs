public class Solution {
    public bool IsAnagram(string s, string t) {
        int[] counter = new int[26];
        foreach(var c in s)
            counter[c-'a']++;
        foreach(var c in t)
            counter[c - 'a']--;
        
        foreach(var n in counter)
            if(n != 0)
                return false;
        
        return true;
    }
}