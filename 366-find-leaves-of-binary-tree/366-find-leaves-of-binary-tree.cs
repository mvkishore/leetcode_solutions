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
    public IList<IList<int>> FindLeaves(TreeNode root) {
        IList<IList<int>> res = new List<IList<int>>();
        
        CollectLeaves(root, res);
        return res;
    }
    private int CollectLeaves(TreeNode root, IList<IList<int>> res)
    {
        if(root == null)
            return -1;
        
        int leftHeight = CollectLeaves(root.left, res);
        int rightHeight = CollectLeaves(root.right, res);
        
        int height = 1 + Math.Max(leftHeight, rightHeight);
        if(res.Count == height){
            res.Add(new List<int>());
        }
        
        res[height].Add(root.val);
        
        return height;
    }
}