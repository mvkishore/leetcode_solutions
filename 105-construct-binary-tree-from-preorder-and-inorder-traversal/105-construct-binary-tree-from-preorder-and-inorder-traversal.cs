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
    int index = 0;
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        int n = preorder.Length;
        Dictionary<int, int> inorderIndex = new Dictionary<int, int>();
        for(int i=0; i < n; i++){
            inorderIndex.Add(inorder[i], i);
        }
        return BuildTree(preorder, 0, n-1, inorderIndex);
    }
    
    private TreeNode BuildTree(int[] preorder, int left, int right, Dictionary<int, int> inorder)
    {
        if(left > right || index >= preorder.Length)
            return null;
        
        int rootVal = preorder[index++];
        var root = new TreeNode(rootVal);
        
        int i = inorder[rootVal];
                 
        root.left = BuildTree(preorder, left, i -1, inorder);
        root.right = BuildTree(preorder, i + 1, right, inorder);
        
        return root;
    }
}