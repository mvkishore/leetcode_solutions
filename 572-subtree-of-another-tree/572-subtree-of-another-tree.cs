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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if(root == null)
            return false;
        
        if(Equal(root, subRoot)) return true;
        
        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }
    
    
    private bool Equal(TreeNode root1, TreeNode root2)
    {
        if(root1 == null && root2 == null)   
            return true;
        
        if(root1 == null || root2 == null)
            return false;
        
        if(root1.val != root2.val)
            return false;
        
        return Equal(root1.left, root2.left) && Equal(root1.right, root2.right);
    }
}