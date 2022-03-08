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
        PriorityQueue<ListNode, int> queue = new PriorityQueue<ListNode, int>();
        
        var dummy = new ListNode(0);
        
        foreach(var list in lists){
            if(list != null)
                queue.Enqueue(list, list.val);
        }
        
        var trav = dummy;
        
        while(queue.Count > 0){
            var cur = queue.Dequeue();
            trav.next = cur;
            if(cur.next != null)
                queue.Enqueue(cur.next, cur.next.val);
            trav = trav.next;
        }
        trav.next = null;
        
        return dummy.next;
    }
}