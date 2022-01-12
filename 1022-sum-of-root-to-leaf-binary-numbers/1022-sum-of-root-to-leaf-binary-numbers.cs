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
    public int SumRootToLeaf(TreeNode root) {
        return SumRootToLeaf(root, 0, 0);
    }
    
    private int SumRootToLeaf(TreeNode root, int current, int sum){
        if(root == null)
            return sum;
        
        current |= root.val;
        
        if(root.left == null && root.right == null)
        {
            return current;
        }
        var leftSum = SumRootToLeaf(root.left, current << 1, sum);
        var rightSum = SumRootToLeaf(root.right, current << 1, sum);
        
        return leftSum + rightSum;
    }
}