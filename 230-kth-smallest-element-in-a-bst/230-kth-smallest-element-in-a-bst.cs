/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        while(stack.Count > 0 || root != null){
            PushLeftTree(root, stack);
            
            root = stack.Pop();
            if(--k == 0) return root.val;
            root = root.right;
        }
        return -1;
    }
    private void PushLeftTree(TreeNode root, Stack<TreeNode> stack){
        while(root != null)
        {
            stack.Push(root);
            root = root.left;
        }
    }
}