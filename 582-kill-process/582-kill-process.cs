public class Solution {
    public IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill) {
        Dictionary<int, List<int>> parents = new Dictionary<int, List<int>>();
        int n = pid.Count;
        
        for(int i=0; i<n; i++){
            var parent = ppid[i];
            if(!parents.ContainsKey(parent))
                parents.Add(parent, new List<int>());
            
            parents[parent].Add(pid[i]);
        }
        
        IList<int> res = new List<int>();
        Queue<int> killQueue = new Queue<int>();
        
        killQueue.Enqueue(kill);
        while(killQueue.Count > 0){
            var id = killQueue.Dequeue();
            res.Add(id);
            if(parents.ContainsKey(id)){
                foreach(var child in parents[id])
                    killQueue.Enqueue(child);
            }
        }
        return res;
    }
}