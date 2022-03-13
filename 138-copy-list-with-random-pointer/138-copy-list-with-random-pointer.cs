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
        Node trav = head;
        if(head == null)
            return head;
        
        while(trav != null){
            var next = trav.next;
            var clone = new Node(trav.val);
            
            trav.next = clone;
            clone.next = next;
            trav = next;
        }
        trav = head;
        Node cloneHead = head.next;
        
        while(trav != null){
            var clone = trav.next;
            var next = clone.next;
            
            if(trav.random != null)
                clone.random = trav.random.next;
            trav = next;
        }
        
        trav = head;
        var cTrav = cloneHead;
        // 1-> 1` -> 2 -> 2` -> null
        while(trav != null){
            var clone = trav.next;
            var next = clone.next;
            
            trav.next = clone.next;
            if(next != null)
                clone.next = next.next;
            
            trav = next;
        }
        
        return cloneHead;
    }
}