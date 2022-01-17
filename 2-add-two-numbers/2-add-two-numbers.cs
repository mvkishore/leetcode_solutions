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
        int carry = 0;
        ListNode dummy = new ListNode(0);
        ListNode trav = dummy;
        while(l1 != null || l2 != null || carry > 0){
            if(l1 != null){
                carry += l1.val;
                l1 = l1.next;
            }
            
            if(l2 != null){
                carry += l2.val;
                l2 = l2.next;
            }
            
            var sumNode = new ListNode(carry % 10);
            carry = carry / 10;
            trav.next = sumNode;
            trav = trav.next;
        }
        
        return dummy.next;
    }
}