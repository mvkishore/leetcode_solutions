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
    int maxPath = int.MinValue;
    public int MaxPathSum(TreeNode root) {
        CalcMaxPathSum(root);
        return maxPath;
    }
    public int CalcMaxPathSum(TreeNode root)
    {
        if(root == null)
            return int.MinValue;
        
        int leftSum = Math.Max(CalcMaxPathSum(root.left), 0);
        int rightSum = Math.Max(CalcMaxPathSum(root.right), 0);
        
        var curSum = root.val + leftSum + rightSum;
        maxPath = Math.Max(curSum, maxPath);
        
        return root.val + Math.Max(leftSum, rightSum);
    }
}