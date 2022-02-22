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
    public ListNode MergeKLists(ListNode[] lists) {
        ListNode dummy = new ListNode(0);
        PriorityQueue<ListNode, int> heap = new PriorityQueue<ListNode, int>();
        if(lists == null)
            return dummy.next;
        
        foreach(var head in lists){
            if(head != null)
                heap.Enqueue(head, head.val);
        }
        var trav = dummy;
        while(heap.Count > 0){
            var min = heap.Dequeue();
            trav.next = min;
            
            if(min.next != null)
                heap.Enqueue(min.next, min.next.val);
            
            trav = trav.next;
        }
        
        return dummy.next;
    }
}