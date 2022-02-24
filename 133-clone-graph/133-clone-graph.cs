/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if(node == null)
            return node;
        
        Dictionary<Node, Node> cloneNodes = new Dictionary<Node, Node>();
        
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);
        
        while(queue.Count > 0){
            var cur = queue.Dequeue();
            if(!cloneNodes.ContainsKey(cur))
                cloneNodes.Add(cur, new Node(cur.val));
            
            foreach(var nei in cur.neighbors){
                if(!cloneNodes.ContainsKey(nei)){
                    cloneNodes.Add(nei, new Node(nei.val));
                    queue.Enqueue(nei);
                }
                cloneNodes[cur].neighbors.Add(cloneNodes[nei]);
            }
        }
        return cloneNodes[node];
    }
}