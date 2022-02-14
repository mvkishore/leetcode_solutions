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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        return AddTwoNumbers(l1, l2, 0);
    }
    
    private ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry) {
        if(l1 == null && l2 == null)
            return carry > 0 ? new ListNode(carry) : null;
        
        int sum = carry;
        if(l1 != null)
            sum += l1.val;
        
        if(l2 != null)
            sum += l2.val;
        
        var node = new ListNode(sum % 10);
        node.next = AddTwoNumbers(l1?.next, l2?.next, sum / 10);
        
        return node;
    }
}