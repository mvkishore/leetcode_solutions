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
        if(head == null)
            return null;
        
        if(head.next == null)
            return head;
    
        ListNode mid = GetMid(head);
        
        var sortedLeft = SortList(head);
        var sortedRight = SortList(mid);
        
        return Merge(sortedLeft, sortedRight);
    }
    
    private ListNode GetMid(ListNode head){
        if(head == null)
            return null;
        
        ListNode fast = head, slow = head, prev = null;
        while(fast != null && fast.next != null)
        {
            prev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        
        var mid = prev.next;
        prev.next = null;
        return mid;
    }
    
    private ListNode Merge(ListNode list1, ListNode list2){
        ListNode dummy = new ListNode(0);
        var trav = dummy;
        
        while(list1 != null && list2 != null){
            if(list1.val < list2.val){
                trav.next = list1;
                list1 = list1.next;
            }else{
                trav.next = list2;
                list2 = list2.next;
            }
            trav = trav.next;
        }
        
        trav.next = list1 ?? list2;
        
        return dummy.next;
    }
    
    
}
