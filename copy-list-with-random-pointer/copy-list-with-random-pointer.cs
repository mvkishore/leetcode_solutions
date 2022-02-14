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
            var newNode = new Node(trav.val);
            trav.next = newNode;
            newNode.next = next;
            trav = next;
        }
        
        Node newHead = head.next;
        trav = head;
        
        while(trav != null){
            var newNode = trav.next;
            var next = newNode.next;
            
            if(trav.random != null)
                newNode.random = trav.random.next;

            trav = next;
        }
        
        trav = head;
        while(trav != null){
            var newNode = trav.next;
            var nextOldNode = newNode.next;
            trav.next = nextOldNode;
            if(nextOldNode != null)
                newNode.next = nextOldNode.next;
            
            trav = nextOldNode;
        }
        
        return newHead;
    }
}