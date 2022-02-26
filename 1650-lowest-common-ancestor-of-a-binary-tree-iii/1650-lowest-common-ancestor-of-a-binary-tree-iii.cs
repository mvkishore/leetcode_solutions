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
        Node root1 = p, root2 = q;
        
        while(root1 != root2)
        {
            root1 = root1 == null ? q : root1.parent;
            root2 = root2 == null ? p : root2.parent;
        }
        
        return root1;
    }
}