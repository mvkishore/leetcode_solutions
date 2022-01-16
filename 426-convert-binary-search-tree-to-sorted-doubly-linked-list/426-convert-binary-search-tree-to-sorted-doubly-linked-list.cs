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

dummy 1
prev  cur
prev.right = cur
cur.left = prev;

dymmy  -> <- 1 -> <-2

*/

public class Solution {
    public Node TreeToDoublyList(Node root) {
        if(root == null)
            return null;
            
        Node dummy = new Node(0);
        var last = Connect(root, dummy);
        var first = dummy.right;
        
        first.left = last;
        last.right = first;
        
        return first;
    }
    
    private Node Connect(Node cur, Node prev)
    {
        if(cur == null)
            return prev;
        
        prev = Connect(cur.left, prev);
        
        prev.right = cur;
        cur.left = prev;
        
        return Connect(cur.right, cur);
    }
}