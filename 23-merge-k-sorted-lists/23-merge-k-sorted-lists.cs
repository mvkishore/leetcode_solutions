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
        SortedSet<(int val, int idx, ListNode node)> heap = new SortedSet<(int val, int idx, ListNode node)>();
        ListNode dummyHead = new ListNode();
        ListNode trav = dummyHead;
        int k=0;
        for(int i=0; i<lists.Length; i++){
            if(lists[i] != null)
                heap.Add((lists[i].val, k++, lists[i]));
        }
        
        while(heap.Count > 0){
            var min = heap.Min;
            heap.Remove(min);
            
            var node = min.node;
            var next = node.next;
            
            trav.next = node;
            if(next != null)
                heap.Add((next.val, k++, next));
           
            trav = trav.next;
        }
        
        return dummyHead.next;
    }
}