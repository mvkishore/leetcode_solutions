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
        if(root == null)
            return true;
        return IsValidBST(root, null, null);
    }
    
    private bool IsValidBST(TreeNode root, int? max, int? min){
        if(root == null)
            return true;
        
        if(root.val <= min || root.val >= max)
            return false;
        
        return IsValidBST(root.left, root.val, min) && IsValidBST(root.right, max, root.val);
    }
}