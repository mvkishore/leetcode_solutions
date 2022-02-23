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
    int maxSum = int.MinValue;
    public int MaxPathSum(TreeNode root) {
        FindPathSum(root);
        return maxSum;
    }
    
    private int FindPathSum(TreeNode root)
    {
        if(root == null)
            return 0;
        
        int leftSum = FindPathSum(root.left);
        int rightSum = FindPathSum(root.right);
        
        int sum = root.val;
        int bestOfChilds = Math.Max(leftSum, rightSum);
        int currentPathSum = sum + leftSum + rightSum;
        int resSum = Math.Max(sum, sum + bestOfChilds);
        
        maxSum = Math.Max(maxSum, Math.Max(resSum, currentPathSum));
        
        return resSum;
    }
}