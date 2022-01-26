public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        HashSet<string> words = new HashSet<string>();
        foreach(var word in wordList)
            words.Add(word);
        
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(beginWord);
        Dictionary<string, bool> visited = new Dictionary<string, bool>();
        
        int steps = 1;
        while(queue.Count > 0){
            int size = queue.Count;
            for(int i=0; i<size; i++){
                var cur = queue.Dequeue();//"hit"
                if(visited.ContainsKey(cur)) continue;
                
                if(cur == endWord)
                    return steps;
                
                visited[cur] = true;
                
                foreach(var next in GetNextWords(cur, words)){
                    if(!visited.ContainsKey(next)){
                        if(next == endWord)
                            return 1 + steps;
                        queue.Enqueue(next);
                    }
                }
            }
            steps++;
        }
        
        return 0;
    }
    
    private List<string> GetNextWords(string word, HashSet<string> words)
    {
        var res = new List<string>();
        int n = word.Length;
        var sb = new StringBuilder(word);
        for(int i=0; i<n; i++){
            var prev = sb[i];
            for(var c='a'; c <='z'; c++){
                sb[i] = c;
                var next = sb.ToString();
                if(words.Contains(next)){
                    res.Add(next);
                }
            }
            sb[i] = prev;
        }
        return res;
    }
}