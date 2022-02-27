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
            return head;
        
        Node cur = head;
        while(cur != null){
            var next = cur.next;
            var newNode = new Node(cur.val);
            
            cur.next = newNode;
            newNode.next = next;
            
            cur = next;
        }
        
        cur = head;
        Node copyHead = head.next;
        
        while(cur != null){
            var newCur = cur.next;
            var next = newCur.next;
            
            var random = cur.random;
            if(random != null)
                newCur.random = random.next;
            
            cur = next;
        }
        
        cur = head;
        while(cur != null){
            var newCur = cur.next;
            var next = newCur.next;
            
            if(next != null)
                newCur.next = next.next;
            
            cur.next = next;
            cur = next;
        }
        
        return copyHead;
    }
}