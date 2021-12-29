/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if(root == null)
            return root;
        Node node = root;
        
        Queue<Node> level = new Queue<Node>();
        level.Enqueue(node);
        
        while(level.Count > 0){
            int size = level.Count;
            node = level.Dequeue();
            
            for(int i=1; i<size; i++){
                var next = level.Dequeue();
                node.next = next;
                
                if(node.left != null)
                    level.Enqueue(node.left);
                if(node.right != null)
                    level.Enqueue(node.right);
                
                node = next;
            }
            
            if(node.left != null)
                level.Enqueue(node.left);
            if(node.right != null)
                level.Enqueue(node.right);
        }
        
        return root;
    }
}