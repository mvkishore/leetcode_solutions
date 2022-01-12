/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;

    public Node() {}

    public Node(int _val) {
        val = _val;
        left = null;
        right = null;
    }

    public Node(int _val,Node _left,Node _right) {
        val = _val;
        left = _left;
        right = _right;
    }
}
*/

public class Solution {
    public Node TreeToDoublyList(Node root) {
        if(root == null)
            return root;
        
        Node dummy = new Node(0);
        var last = LinkNodes(root, dummy);
        var first = dummy.right;
        
        last.right = first;
        first.left = last;
        
        return first;
    }
    
    private Node LinkNodes(Node cur, Node prev)
    {
        if(cur == null)
            return prev;
        
        prev = LinkNodes(cur.left, prev);
        
        prev.right = cur;
        cur.left = prev;
        
        return LinkNodes(cur.right, cur);
    }
}