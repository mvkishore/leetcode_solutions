/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
*/

public class Solution {
    public Node LowestCommonAncestor(Node p, Node q) {
        if(p == null || q == null)
            return null;
        Node node1 = p, node2 = q;
        while(node1 != node2){
            node1 = node1 == null ? q : node1.parent;
            node2 = node2 == null ? p : node2.parent;
        }
        
        return node1;
    }
}