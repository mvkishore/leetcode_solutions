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
        if(head == null)
            return null;
        
        var trav = head;
        while(trav != null){
            var next = trav.next;
            
            var clone = new Node(trav.val);
            trav.next = clone;
            clone.next = next;
            
            trav = next;
        }
        
        var cloneHead = head.next;
        
        trav = head;
        while(trav != null){
            var clone = trav.next;
            
            if(trav.random != null)
                clone.random = trav.random.next;
            trav = trav.next.next;
        }
        trav = head;
        while(trav != null)
        {
            var clone = trav.next;
            trav.next = clone.next;
            clone.next = trav.next?.next;
            trav = trav.next;
        }
        
        return cloneHead;
    }
}