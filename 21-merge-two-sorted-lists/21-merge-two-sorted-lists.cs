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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode dummy = new ListNode(0);
        ListNode trav = dummy;
        
        while(list1 != null && list2 != null){
            if(list1.val < list2.val){
                trav.next = list1;
                list1 = list1.next;
            }
            else {
                trav.next = list2;
                list2 = list2.next;
            }
            trav = trav.next;
        }
        
        trav.next = list1 ?? list2;
        
        return dummy.next;
    }
}