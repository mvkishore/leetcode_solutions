/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        Dictionary<Node, Node> clones = new Dictionary<Node, Node>();
        
        var cloneHead = CloneNodes(head, clones);
        CloneRandoms(head, clones);
        
        return cloneHead;
    }
    
    private Node CloneNodes(Node head, Dictionary<Node, Node> clones)
    {
        if(head == null)
            return null;
        
        var clone = new Node(head.val);
        clone.next = CloneNodes(head.next, clones);
        clones.Add(head, clone);
        return clones[head];
    }
    
    private void CloneRandoms(Node head, Dictionary<Node, Node> clones)
    {
        var trav = head;
        while(trav != null){
            if(trav.random != null)
                clones[trav].random = clones[trav.random];
            trav = trav.next;
        }
    }
}