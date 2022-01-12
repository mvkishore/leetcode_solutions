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
    public void ReorderList(ListNode head) {
        ListNode slow = head, fast = head;
        
        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }
       
        ListNode prev = null, cur = slow; 
        while(cur != null){
            var next = cur.next; 
            cur.next = prev; 
            
            prev = cur; 
            cur = next; 
        }
        
        ListNode left = head, right = prev;
        while(left != null && right != null){
            var next = left.next; 
            left.next = right; 
            left = next; 
            
            next = right.next;
            if(right != left)
                right.next = left;
            right = next; 
        }
    }
}