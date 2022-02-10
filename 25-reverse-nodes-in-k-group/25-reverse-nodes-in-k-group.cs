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
        ListNode cur = head, prev = null;
        int count = 0;
        while(cur != null && count < k){
            cur = cur.next;
            count++;
        }
        
        if(count < k)
            return head;
        
        count = 0;
        cur = head;
        while(cur != null && count < k){
            var next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
            count++;
        }
        head.next = ReverseKGroup(cur, k);
        return prev;
    }
}