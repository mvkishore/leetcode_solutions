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
    int kthsmall = -1;
    int count = 0;
    public int KthSmallest(TreeNode root, int k) {
        Inorder(root, k);
        return kthsmall;
    }
    
    private void Inorder(TreeNode root, int k)
    {
        if(root == null)
            return;
        
        Inorder(root.left, k);
        count++;
        if(count == k)
            kthsmall = root.val;
        Inorder(root.right, k);
    }
}