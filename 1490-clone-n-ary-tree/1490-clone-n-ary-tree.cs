/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;
    
    public Node() {
        val = 0;
        children = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        children = new List<Node>();
    }
    
    public Node(int _val, List<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/


public class Solution {
    public Node CloneTree(Node root) {
        if(root == null)
            return root;
        
        var clone = new Node(root.val);
        
        foreach(var child in root.children){
            clone.children.Add(CloneTree(child));
        }
        
        return clone;
    }
}