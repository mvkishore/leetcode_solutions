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
    int dia = int.MinValue;
    public int DiameterOfBinaryTree(TreeNode root) {
        Depth(root, 0);
        return dia;
    }
    
    public int Depth(TreeNode root, int depth){
        if(root == null)
            return 0;
        
        int leftDepth = Depth(root.left, depth + 1);
        int rightDepth = Depth(root.right, depth + 1);

        dia = Math.Max(dia, leftDepth + rightDepth);
        
        return 1 + Math.Max(leftDepth, rightDepth);;
    }
}