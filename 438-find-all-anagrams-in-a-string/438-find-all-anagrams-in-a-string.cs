public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        int l=0, r=0, n = s.Length;
        int[] counter = new int[26];
        
        foreach(var c in p)
            counter[c - 'a']++;
        
        int count = 0, m = p.Length;
        IList<int> res = new List<int>();
       
        while(r < n){
            if(counter[s[r++] - 'a']-- > 0)
                count++;
            
            while(count == m){
                if(r - l == m){
                    res.Add(l);
                }
                
                if(counter[s[l++] - 'a']++ == 0)
                    count--;
            }
        }
        
        return res;
    }
}