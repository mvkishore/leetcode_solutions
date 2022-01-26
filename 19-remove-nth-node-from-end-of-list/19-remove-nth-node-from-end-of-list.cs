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
        ListNode first = head;
        while(n > 0 && first != null){
            first = first.next;
            n--;
        }
        
        if(n > 0) return null;
        
        ListNode second = head, prev = null;
        while(first != null){
            prev = second;
            second = second.next;
            first = first.next;
        }
        if(prev != null)
            prev.next = second.next;
        else
            head = head.next;
        return head;
    }
}