public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        IList<IList<string>> res = new List<IList<string>>();
        Dictionary<string, IList<string>> groups = new Dictionary<string, IList<string>>();
        
        foreach(var str in strs){
            var key = GetKey(str);
            if(!groups.ContainsKey(key))
                groups.Add(key, new List<string>());
            groups[key].Add(str);
        }
        
        foreach(var group in  groups.Values)
            res.Add(group);
        return res;
    }
    private string GetKey(string str) {
        
        int[] count = new int[26];
        foreach(var c in str)
            count[c - 'a']++;
        StringBuilder sb = new StringBuilder();
        
        for(int i=0; i< 26; i++){
            while(count[i] > 0) {
                sb.Append((char)(i + 'a'));
                count[i]--;
            }
        }
        
        return sb.ToString();
    }
}