public class Solution {
    public class DisjointSet {
        int[] parent;
        int size;
        public DisjointSet(int size){
            this.size = size;
            parent = new int[size];
            for(int i=0; i<size; i++)
                parent[i] = i;
        }
        
        public void Union(int x, int y) {
            int pX = Find(x), pY = Find(y);
            if(pX != pY) {
                parent[pX] = pY;
                size--;
            }
        }
        public int Size => size;
        
        public int Find(int id){
            if(id == parent[id])
                return id;
            return parent[id] = Find(parent[id]);
        }
    }
    
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        int n = accounts.Count;
        var ds = new DisjointSet(n);
        Dictionary<string, int> seenEmails = new Dictionary<string, int>();
        for(int i=0; i< n; i++){
            var account = accounts[i];
            for(int e=1; e < account.Count; e++) {
                var email = account[e];
                if(seenEmails.ContainsKey(email))
                    ds.Union(i, seenEmails[email]);
                else
                    seenEmails.Add(email, i);
            }
        }
        
        Dictionary<int, SortedSet<string>> accountEmails = new Dictionary<int, SortedSet<string>>();
        
        for(int i=0; i < n; i++){
            var pId = ds.Find(i);
            var account = accounts[i];
            
            if(!accountEmails.ContainsKey(pId))
                accountEmails.Add(pId, new SortedSet<string>(StringComparer.Ordinal));
            
            for(int e=1; e< account.Count; e++)
                accountEmails[pId].Add(account[e]);
        }
        
        var results = new List<IList<string>>();
        
        foreach(var key in accountEmails.Keys){
            var list = new List<string>();
            list.Add(accounts[key][0]);
            list.AddRange(accountEmails[key].ToList());
            results.Add(list);
        }
        return results;
    }
}