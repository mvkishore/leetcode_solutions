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
        ListNode cur = head, res_head = null, prevRevTail = null;
        
        while(cur != null){
            int count = 0;
            while(cur != null && count < k){
                cur = cur.next;
                count++;
            }
            
            if(count == k){
                var revHead = RevereseKList(head, k);
                
                if(res_head == null)
                    res_head = revHead;
                
                if(prevRevTail != null)
                    prevRevTail.next = revHead;
                
                prevRevTail = head;
                head = cur;
            }
        }
        
        if(prevRevTail != null)
            prevRevTail.next = head;
        
        return res_head ?? head;
    }
    private ListNode RevereseKList(ListNode head, int k)
    {
        ListNode cur = head, prev = null;
        while(k > 0){
            var next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
            k--;
        }
        return prev;
    }
}