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
/*


Solution for 
https://www.facebookrecruiting.com/portal/coding_practice_question/?problem_id=623634548182866&c=590581968727992&ppid=454615229006519&practice_plan=0

*/
public class Solution {
    public ListNode ReverseList(ListNode head) {
        if(head == null)
            return head;
        
        ListNode cur = head, prev = null;
        while(cur != null){
            var next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
        }
        return prev;
    }
}