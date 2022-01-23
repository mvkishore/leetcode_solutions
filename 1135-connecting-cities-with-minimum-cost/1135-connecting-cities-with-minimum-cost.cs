public class Solution {
    public int MinimumCost(int n, int[][] connections) {
        UnionFind uf = new UnionFind(n);
        Array.Sort(connections, (a, b) => a[2] - b[2]);
        int totalCost = 0, edges = 0;
        
        for(int i=0; i<connections.Length; i++)
        {
            int city1 = connections[i][0];
            int city2 = connections[i][1];
            int cost = connections[i][2];
            
            if(uf.Union(city1, city2)){
                totalCost += cost;
                edges++;
            }
        }
        
        if(edges == n -1)
            return totalCost;
        return -1;
    }
    
    public class UnionFind
    {
        int[] parent;
        public UnionFind(int capacity)
        {
            parent = new int[capacity + 1];
            for(int i=1; i <= capacity; i++)
                parent[i] = i;
        }
        
        public bool Union(int x, int y)
        {
            int xParent = Find(x);
            int yParent = Find(y);
            if(xParent == yParent)
                return false;
            parent[xParent] = yParent;
            return true;
        }
        
        public int Find(int x)
        {
            if(parent[x] == x)
                return x;
            return parent[x] = Find(parent[x]);
        }
    }
}