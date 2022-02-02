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
    // 1 2 2 1
    public bool IsPalindrome(ListNode head) {
        ListNode slow = head, fast = head;
        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }
        
        if(fast != null)
            slow = slow.next;
        ListNode prev = null;
        
        while(slow != null){
            var next = slow.next;
            slow.next = prev;
            prev = slow;
            slow = next;
        }
        slow = prev;
        
        fast = head;
        while(slow != null){
            if(slow.val != fast.val) 
                return false;
            slow = slow.next;
            fast = fast.next;
        }
        
        return true;
    }
}