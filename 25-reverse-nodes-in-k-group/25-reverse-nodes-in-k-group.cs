/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        ListNode cur = head, res = null, revTail = null;
        
        while(cur != null){
            int count = 0;
            
            while(cur != null && count < k){
                cur = cur.next;
                count++;
            }
            
            if(count == k){
                var revHead = RevereseKNodes(head, k);
                
                if(res == null)
                    res = revHead;
                               
                if(revTail != null)
                    revTail.next = revHead;
                
                revTail = head;
                head = cur;
            }
        }
        if(revTail != null)
            revTail.next = head;
        
        return res ?? head;
    }
    
    public ListNode RevereseKNodes(ListNode head, int k){
        ListNode cur = head, prev = null;
        while(cur != null && k > 0){
            var next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
            k--;
        }
        return prev;
    }
}