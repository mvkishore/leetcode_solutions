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
    public ListNode DeleteDuplicatesUnsorted(ListNode head) {
        Dictionary<int, int> counter = new Dictionary<int, int>();
        var trav = head;
        while(trav != null){
            if(!counter.ContainsKey(trav.val))
                counter.Add(trav.val, 0);
            
            counter[trav.val]++;
            trav = trav.next;
        }
        
        var dummy = new ListNode(0, head);
        var prev = dummy;
        trav = head;
        
        while(trav != null){
            if(counter[trav.val] > 1){
                prev.next = trav.next;
            } else {
                prev = prev.next;
            }
            trav = trav.next;
        }
        
        return dummy.next;
    }
}