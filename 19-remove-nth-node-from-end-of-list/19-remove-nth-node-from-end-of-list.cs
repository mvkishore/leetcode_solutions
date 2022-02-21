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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode fast = head;
        while(n > 0 && fast != null){
            fast = fast.next;
            n--;
        }
        
        if(fast == null)
            return head.next;
        
        ListNode slow = head, prev = null;
        while(fast != null){
            prev = slow;
            slow = slow.next;
            fast = fast.next;
        }
        if(prev != null)
            prev.next = slow.next;
        
        return head;
    }
}