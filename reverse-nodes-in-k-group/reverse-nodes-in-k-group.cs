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
        ListNode cur = head, res = null, kHead=null, kTail=null;
        
        
        while(cur != null){
            int count = 0;
            while(cur != null && count < k){
                cur = cur.next;
                count++;
            }
            
            if(count == k){
                kHead = ReverseK(head, k);
                if(res == null)
                    res = kHead;
                if(kTail != null)
                    kTail.next = kHead;
                kTail = head;
                head = cur;
            }
        }
        if(kTail != null)
            kTail.next = head;
        return res ?? head;
    }
    
    private ListNode ReverseK(ListNode head, int k){
        int count = 0;
        ListNode cur = head, prev = null;
        while(cur != null && count < k){
            var next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
            count++;
        }
        
        return prev;
    }
}