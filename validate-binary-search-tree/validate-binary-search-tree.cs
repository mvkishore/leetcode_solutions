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
    public bool IsValidBST(TreeNode root) {
        return IsValidBST(root,(long) int.MinValue - 1,(long) int.MaxValue + 1);
    }
    
    private bool IsValidBST(TreeNode node, long min, long max){
        if(node == null)
            return true;
        
        if(node.val <= min || node.val >= max)
            return false;
        
        return IsValidBST(node.left, min, node.val) && IsValidBST(node.right, node.val, max);
    }
    
}