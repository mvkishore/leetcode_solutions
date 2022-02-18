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
    public ListNode SortList(ListNode head) {
        if(head == null || head.next == null)
            return head;
        
        var mid = GetMid(head);
        
        var leftList = SortList(head);
        var rightList = SortList(mid);
        
        return Merge(leftList, rightList);
    }
    
    private ListNode Merge(ListNode left, ListNode right){
        var dummyHead = new ListNode(0);
        var trav = dummyHead;
        
        while(left != null && right != null) {
            if(left.val < right.val) {
                trav.next = left;
                left = left.next;
            } else {
                trav.next = right;
                right = right.next;
            }
            trav = trav.next;
        }
        
        trav.next = right == null ? left : right;
        return dummyHead.next;
    }
    
    private ListNode GetMid(ListNode head)
    {
        ListNode midPrev = null;
        ListNode fast = head, slow = head;
        
        while(fast != null && fast.next != null){
            midPrev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        midPrev.next = null;
        return slow;
    }
}