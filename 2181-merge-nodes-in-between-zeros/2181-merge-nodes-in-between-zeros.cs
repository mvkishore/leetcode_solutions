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
    public ListNode MergeNodes(ListNode head) {
        var trav = head;
        ListNode res = null;
        while(trav != null){
            var list = trav.next;
            
            if(res == null)
                res = list;
            
            var cur = list;
            while(cur != null && cur.val != 0)
            {
                cur = cur.next;
                list.val += cur.val;
                if(cur.val == 0)
                    list.next = cur.next;
            }
            
            trav = list;
        }
        return res;
    }
}