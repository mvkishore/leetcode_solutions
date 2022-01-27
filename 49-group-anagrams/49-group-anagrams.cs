public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, IList<string>> store = new Dictionary<string, IList<string>>();
        
        foreach(var str in strs){
            var key = GetKey(str);
            if(!store.ContainsKey(key))
                store.Add(key, new List<string>());
        
            store[key].Add(str);
        }
        
        IList<IList<string>> res = new List<IList<string>>();
        
        foreach(var rec in store){
            res.Add(rec.Value);
        }
        return res;
    }
    
    private string GetKey(string str)
    {
        StringBuilder sb = new StringBuilder();
        int[] counter = new int[26];
        foreach(var c in str)
            counter[c-'a']++;
        
        for(int i=0; i<26; i++){
            if(counter[i] > 0) {
                sb.Append((char)(i+'a'));
                sb.Append(counter[i]);
            }
        }
        return sb.ToString();
    }
}