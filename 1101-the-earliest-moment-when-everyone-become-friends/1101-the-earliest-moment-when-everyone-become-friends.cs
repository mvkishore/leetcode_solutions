/*

[[20190101,0,1],
[20190104,3,4],[20190107,2,3],[20190211,1,5],[20190224,2,4],[20190301,0,3],[20190312,1,2],[20190322,4,5]]


4----2-----3----0 --- 1---5



*/


public class Solution {
    public class DisjointSet {
        int[] parent;
        public int size;
        
        public DisjointSet(int s){
            size = s;
            parent = new int[s];
            
            for(int i=0; i<s; i++)
                parent[i] = i;
        }
        
        public void Union(int x, int y){
            if(Find(x) != Find(y)){
                parent[Find(x)] = Find(y);
                size--;
            }
        }
        
        public int Find(int x){
            if(parent[x] == x)
                return x;
            return parent[x] = Find(parent[x]);
        }
    }
    public int EarliestAcq(int[][] logs, int n) {
        Array.Sort(logs, (a, b) => a[0] - b[0]);
        DisjointSet group = new DisjointSet(n);
        
        foreach(var log in logs){
            int a = log[1], b = log[2];
            group.Union(a, b);
            if(group.size == 1)
                return log[0];
        }
        return -1;
    }
}