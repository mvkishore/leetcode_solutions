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
    int diameter =0;//2
    public int DiameterOfBinaryTree(TreeNode root) {
        FindDiameter(root);
        return diameter;
    }
    
    private int FindDiameter(TreeNode root){
        if(root == null)
            return -1;
        
        if(root.left == null && root.right == null)
            return 0;
        
        int left = 1 + FindDiameter(root.left);
        int right = 1 + FindDiameter(root.right);
        
        diameter = Math.Max(diameter, left + right);
        return Math.Max(left, right);
    }
}