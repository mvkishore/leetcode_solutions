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
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        TreeNode cur = root, successor = null;
        
        while(cur != null){
            if(p.val < cur.val){
                successor = cur;
                cur = cur.left;
            }
            else
                cur = cur.right;
        }
        return successor;
    }
}