public class Solution {
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        int n = accounts.Count;
        UnionFind uf = new UnionFind(n);
        Dictionary<string, int> emailLookUp = new Dictionary<string, int>();
        int i=0;
        
        while(i< n){
            var account = accounts[i];
            for(int j=1; j < account.Count; j++){
                if(!emailLookUp.ContainsKey(account[j]))
                    emailLookUp.Add(account[j], i);
                else 
                    uf.Union(emailLookUp[account[j]], i);
            }
            i++;
        }

        Dictionary<int, SortedSet<string>> mergedAccounts = new Dictionary<int, SortedSet<string>>();
        i = 0;
        while(i < n){
            int accountid = uf.Find(i);
            if(!mergedAccounts.ContainsKey(accountid))
                mergedAccounts.Add(accountid, new SortedSet<string>(StringComparer.Ordinal));
            
            var account = accounts[i];
            for(int j=1; j<account.Count; j++){
                mergedAccounts[accountid].Add(account[j]);
            }
            i++;
        }
        
        IList<IList<string>> result = new List<IList<string>>();
        foreach(var account in mergedAccounts){
            var list = new List<string>();
            
            list.Add(accounts[account.Key][0]);
            list.AddRange(mergedAccounts[account.Key].ToList());
            
            result.Add(list);
        }
        return result;
    }
    public class UnionFind {
        int[] parent;
        
        public UnionFind(int n)
        {
            parent = new int[n];
            for(int i=0; i<n; i++){
                parent[i] = i;
            }
        }
        
        public void Union(int x, int y){
            parent[Find(x)] = Find(y);
        }
        
        public int Find(int x){
            if(parent[x] == x)
                return x;
            
            return parent[x] = Find(parent[x]);
        }
    }
}