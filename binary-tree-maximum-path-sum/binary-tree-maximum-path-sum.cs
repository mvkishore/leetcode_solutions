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
    int max = int.MinValue;
    public int MaxPathSum(TreeNode root) {
        MaxPathSumHelp(root);
        return max;
    }
    
    private int MaxPathSumHelp(TreeNode root){
        if(root == null)
            return 0; 
        
        int left_max = Math.Max(MaxPathSumHelp(root.left), 0);
        int right_max = Math.Max(MaxPathSumHelp(root.right), 0);
        
        int cur_max = root.val + left_max + right_max;
        max = Math.Max(max, cur_max);
        
        return root.val + Math.Max(left_max, right_max);
    }
}