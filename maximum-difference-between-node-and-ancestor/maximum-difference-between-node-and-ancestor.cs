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
    int res = 0;
    public int MaxAncestorDiff(TreeNode root) {
        if(root == null)
            return 0;
        MaxAnceHelper(root, root.val, root.val);
        return res;
    }
    
    private void MaxAnceHelper(TreeNode root, int max, int min)
    {
        if(root == null)
            return;
        max = Math.Max(max, root.val);
        min = Math.Min(min, root.val);
        
        res = Math.Max(res, Math.Abs(max - min));
        MaxAnceHelper(root.left, max, min);
        MaxAnceHelper(root.right, max, min);
    }
}