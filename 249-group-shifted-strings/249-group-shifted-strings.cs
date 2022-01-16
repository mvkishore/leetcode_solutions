public class Solution {
    public IList<IList<string>> GroupStrings(string[] strings) {
        Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
        
        foreach(var str in strings){
            var hash = GetHash(str);
            if(!groups.ContainsKey(hash))
                groups.Add(hash, new List<string>());
            
            groups[hash].Add(str);
        }
        IList<IList<string>> res = new List<IList<string>>();
        
        foreach(var group in groups)
            res.Add(group.Value);
        return res;
    }
    
    private string GetHash(string str)
    {
        StringBuilder sb = new StringBuilder();
        int n = str.Length;
        for(int i=1; i<n; i++){
            int diff = (26 - (str[i-1] - str[i])) %26;
            sb.Append(diff);
            sb.Append('.');
        }
        
        if(sb.Length == 0)
            sb.Append('.');
        
        return sb.ToString();
    }
}

/*
"xac","zce"
-23.2 -23.2

 1.1    1.1
"ax" , "xy" 

"ax"-> 24  "xy" ->1

"xa" -> -23
"zc" -> -23
"a"-0  "v"-0
*/