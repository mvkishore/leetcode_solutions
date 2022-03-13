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
    private int GetLength(ListNode head){
        int len = 0;
        while(head != null){
            len ++;
            head = head.next;
        }
        return len;
    }
    public ListNode RotateRight(ListNode head, int k) {
        ListNode trav = head, first = head, last = null, newLast = null;
        int n = GetLength(head);
        if(n == 0)
            return head;
        k = k % n;
        
        if(k == 0)
            return head;
        
        while(trav != null && k > 0)
        {
            trav = trav.next;
            k--;
        }
        
        while(trav != null){
            newLast = first;
            last = trav;

            first = first.next;
            trav = trav.next;
        }
        
        if(newLast != null)
            newLast.next = null;
        
        if(last != null && last != head)
            last.next = head;
        
        return first ?? head;
    }
}