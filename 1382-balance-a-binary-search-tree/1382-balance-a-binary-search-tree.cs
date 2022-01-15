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
    public TreeNode BalanceBST(TreeNode root) {
        if(root == null)
            return root;
        
        List<int> nodes = new List<int>();
        CollectNodes(root, nodes);
        return ConstructBST(nodes, 0, nodes.Count - 1);
    }
    
    private void CollectNodes(TreeNode root, List<int> nodes)
    {
        if(root == null)
            return;
        CollectNodes(root.left, nodes);
        nodes.Add(root.val);
        CollectNodes(root.right, nodes);
    }
    
    private TreeNode ConstructBST(List<int> nodes, int start, int end)
    {
        if(start > end)
            return null;
        int mid = start + (end - start) / 2;
        
        TreeNode root = new TreeNode(nodes[mid]);
        root.left = ConstructBST(nodes, start, mid - 1);
        root.right = ConstructBST(nodes, mid + 1, end);
        
        return root;
    }
}