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
        SortedSet<(int val, int indx, ListNode node)> heap = new SortedSet<(int val, int indx, ListNode node)>();
        int i=0;
        foreach(var list in lists){
            if(list != null)
                heap.Add((list.val, i++, list));
        }
        
        ListNode dummy = new ListNode(0);
        ListNode cur = dummy;
        
        while(heap.Count > 0){
            var min = heap.Min;
            heap.Remove(min);
            cur.next = min.node;
            var next = min.node.next;
            
            if(next != null)
                heap.Add((next.val, min.indx, next));
            cur = cur.next;
        }
        
        return dummy.next;
    }
}