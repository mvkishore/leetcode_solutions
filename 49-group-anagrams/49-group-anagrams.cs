public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, IList<string>> groups = new Dictionary<string, IList<string>>();
        
        foreach(var str in strs){
            var key = Sort(str);
            if(!groups.ContainsKey(key))
                groups.Add(key, new List<string>());
            
            groups[key].Add(str);
        }
        
        return groups.Values.ToList();
    }
    
    private string Sort(string s){
        StringBuilder sb = new StringBuilder();
        int[] counter = new int[26];
        foreach(var c in s)
            counter[c - 'a']++;
        
        for(int i=0; i<26; i++)
            while(counter[i]-- > 0)
                sb.Append((char) i + 'a');
        
        return sb.ToString();
    }
}