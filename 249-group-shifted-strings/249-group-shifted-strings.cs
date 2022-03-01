public class Solution {
    public IList<IList<string>> GroupStrings(string[] strings) {
        Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
        foreach(var str in strings){
            var key = GetKey(str);
            if(!groups.ContainsKey(key))
                groups.Add(key, new List<string>());
            groups[key].Add(str);
        }
        
        IList<IList<string>> res = new List<IList<string>>();
        foreach(var value in groups.Values)
            res.Add(value);
        
        return res;
    }
    
    private string GetKey(string str){
        StringBuilder key = new StringBuilder();
        int n = str.Length;
        for(int i=1; i<n; i++){
            int d = str[i] - str[i-1];
            if(d < 0)
                d += 26;
            key.Append(d);
            key.Append("-");
        }
        
        if(key.Length > 0)
            key.Length--;
        
        return key.ToString();
    }
}


    
    