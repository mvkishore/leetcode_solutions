public class Solution {
    public string AlienOrder(string[] words) {
        int n = words.Length;
        Dictionary<char, HashSet<char>> depMap = new Dictionary<char, HashSet<char>>();
        Dictionary<char, int> inDegree = new Dictionary<char, int>();
        
        foreach(var word in words)
        {
            foreach(var c in word)
            {
                if(!inDegree.ContainsKey(c))
                    inDegree.Add(c, 0);
            }
        }
        
        var prev = words[0];
        for(int i=1; i < n; i++){
            var cur = words[i];
            bool noMatch = true;
            for(int j=0; j < Math.Min(prev.Length, cur.Length); j++){
                if(prev[j] != cur[j]){
                    var u = prev[j];
                    var v = cur[j];
                    if(!depMap.ContainsKey(u))
                        depMap.Add(u, new HashSet<char>());
                    
                    if(depMap[u].Add(v))
                        inDegree[v]++;
                    noMatch = false;
                    break;
                }
            }
            if(noMatch && cur.Length < prev.Length)
                return string.Empty;
            prev = cur;
        }
        
        StringBuilder sb = new StringBuilder();
        Queue<char> queue = new Queue<char>();
        
        foreach(var inDegreeChar in inDegree){
            if(inDegreeChar.Value == 0)
                queue.Enqueue(inDegreeChar.Key);
        }
        
        while(queue.Count > 0){
            var size = queue.Count;
            for(int i=0; i<size; i++){
                var cur = queue.Dequeue();
                sb.Append(cur);
                if(depMap.ContainsKey(cur)){
                    foreach(var nei in depMap[cur]){
                        inDegree[nei]--;
                        if(inDegree[nei] == 0)
                            queue.Enqueue(nei);
                    }
                }
            }
        }
        
        if(sb.Length == inDegree.Count) return sb.ToString();
        
        return string.Empty;
    }
}