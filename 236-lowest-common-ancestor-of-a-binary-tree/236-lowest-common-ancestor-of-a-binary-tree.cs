/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null)
            return null;
        
        if(root == p || root == q)
            return root;
        
        var x = LowestCommonAncestor(root.left, p, q);
        
        if(x != null && x != p && x != q)
            return x;
        
        var y = LowestCommonAncestor(root.right, p, q);
        
        if(y != null && y != p && y != q)
            return y;
        
        if(x != null && y != null)
            return root;
        else if(x == null)
            return y;
        else return x;
    }
}