public class Solution {
    public string AlienOrder(string[] words) {
        Dictionary<char, List<char>> orderGraph = new Dictionary<char, List<char>>();
        Dictionary<char, int> indegrees = new Dictionary<char, int>();
        
        foreach(var word in words){
            foreach(var c in word){
                if(!orderGraph.ContainsKey(c)){
                    orderGraph.Add(c, new List<char>());
                    indegrees.Add(c, 0);
                }
            }
        }
        
        for(int i=0; i < words.Length - 1; i++){
            var word1 = words[i];
            var word2 = words[i+1];
            
            if(word1 == word2) continue;
            
            if(word1.Length > word2.Length && word1.StartsWith(word2))
                return string.Empty;
            
            for(int j=0; j< Math.Min(word1.Length, word2.Length); j++)
            {
                if(word1[j] != word2[j]){
                    //if(!orderGraph[word1[j]].Contains(word2[j])){
                        orderGraph[word1[j]].Add(word2[j]);
                        indegrees[word2[j]]++;
                    //}
                    break;
                }
            }
        }
        
        StringBuilder sb = new StringBuilder();
        Queue<char> queue = new Queue<char>();
        
        foreach(var c in indegrees.Where(x => x.Value == 0).Select(x=> x.Key))
            queue.Enqueue(c);
        
        while(queue.Count > 0){
            var cur = queue.Dequeue();
            sb.Append(cur);
            foreach(var nextChars in orderGraph[cur]){
                indegrees[nextChars]--;
                if(indegrees[nextChars] == 0)
                    queue.Enqueue(nextChars);
            }
        }
        
        return sb.Length != indegrees.Count ? string.Empty: sb.ToString();
    }
}