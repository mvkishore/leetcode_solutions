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
 
    20
 
 */
public class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        int n = preorder.Length;
        return BuildTree(preorder, 0, n-1, inorder, 0, n-1);
    }
    
    private TreeNode BuildTree(int[] preorder, int pStart, int pEnd, int[] inorder, int iStart, int iEnd){
        if(pStart > pEnd || iStart > iEnd )
            return null;
        
        int val = preorder[pStart];
        var root = new TreeNode(val);
        
        if(pStart == pEnd)
            return root;
        
        int i;
        for(i=iStart; i<=iEnd ; i++){
            if(inorder[i] == val)
                break;
        }
        
        int len = i - iStart - 1;
        
        root.left = BuildTree(preorder, pStart + 1, pStart + 1 + len, inorder, iStart, i-1);
        root.right = BuildTree(preorder, pStart + len + 2, pEnd, inorder, i+1, iEnd);
        
        return root;
    }
}