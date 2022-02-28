public class Solution {
    public IList<string> RemoveInvalidParentheses(string s) {
        IList<string> res = new List<string>();
        Queue<string> queue = new Queue<string>();
        
        HashSet<string> visited = new HashSet<string>();
        
        queue.Enqueue(s);
        visited.Add(s);
        while(queue.Count > 0){
            var size = queue.Count;

            for(int i=0; i<size; i++){
                var cur = queue.Dequeue();

                if(IsValid(cur))
                    res.Add(cur);
                
                if(res.Count > 0) continue;
                
                for(int j=0; j < cur.Length; j++) {
                   if(cur[j] == '(' || cur[j] == ')')
                   {
                       if(j > 0 && cur[j-1] == cur[j]) continue;
                       
                       var next = cur.Substring(0, j) + cur.Substring(j+1, cur.Length - j - 1);
                       if(!visited.Contains(next)){
                           visited.Add(next);
                           queue.Enqueue(next);
                       }
                   }
                }
                
                if(res.Count > 0)
                    return res;
            }
        }
        return res;
    }
    
    private bool IsValid(string s){
        int openCount = 0;
        foreach(var c in s){
            if(c == '(')
                openCount++;
            else if(c == ')')
                openCount--;
            if(openCount < 0)
                return false;
        }
        return openCount == 0;
    }
}