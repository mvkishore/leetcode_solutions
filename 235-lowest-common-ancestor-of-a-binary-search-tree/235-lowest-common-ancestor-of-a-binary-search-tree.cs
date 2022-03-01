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
        int pVal = p.val;
        int qVal = q.val;
        
        while(root != null){
            var val = root.val;
            
            if(val > pVal && val > qVal)
                root = root.left;
            else if(val < pVal && val < qVal)
                root = root.right;
            else return root;
        }
        return null;
    }
}