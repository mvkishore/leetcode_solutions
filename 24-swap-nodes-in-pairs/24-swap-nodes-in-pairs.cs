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
    public ListNode SwapPairs(ListNode head) {
        int k = 2;
        if(head == null)
            return null;
        ListNode cur = head, prev = null;
        while(cur != null && k > 0){
            var next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
            k--;
        }
        head.next = SwapPairs(cur);
        return prev;
    }
}