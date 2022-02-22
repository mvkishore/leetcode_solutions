public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        IList<IList<string>> res = new List<IList<string>>();
        Dictionary<string, IList<string>> groups = new Dictionary<string, IList<string>>();
        
        foreach(var str in strs){
            var chars = str.ToCharArray();
            Array.Sort(chars);
            var key = new string(chars);
            if(!groups.ContainsKey(key))
                groups.Add(key, new List<string>());
            groups[key].Add(str);
        }
        
        foreach(var group in  groups.Values)
            res.Add(group);
        return res;
    }
}