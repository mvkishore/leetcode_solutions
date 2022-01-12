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
    public void ReorderList(ListNode head) {
        ListNode slow = head, fast = head;
        Stack<ListNode> stack = new Stack<ListNode>();
        
        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }
        
        while(slow != null){
            var next = slow.next;
            slow.next = null;
            stack.Push(slow);
            slow = next;
        }
       
        slow = head;
   
        while(stack.Count > 0 && slow != stack.Peek()){
            var next = slow.next;
            slow.next = stack.Pop();
            if(slow.next != next)
                slow.next.next = next;
            slow = next;
        }
    }
}