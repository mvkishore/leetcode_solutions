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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        int n = preorder.Length;
        return BuildTree(preorder, 0, n-1, inorder, 0, n -1);
    }
    
    private TreeNode BuildTree(int[] preorder, int pS, int pE, int[] inorder, int iS, int iE)
    {
        if(pS > pE || iS > iE)
            return null;
        
        int rootVal = preorder[pS];
        var root = new TreeNode(rootVal);
        
        if(iS == iE)
            return root;
        
        int i = -1;
        for(i = iS; i<= iE; i++){
            if(inorder[i] == rootVal)
                break;
        }
        
        int leftTreeLength = i - iS;
        int rightTreeLength = iE - i;
            
        root.left = BuildTree(preorder, pS + 1, pS + leftTreeLength, inorder, iS, i - 1);
        root.right = BuildTree(preorder, pS + leftTreeLength + 1, pE, inorder, i+1, iE);
        
        return root;
    }
}