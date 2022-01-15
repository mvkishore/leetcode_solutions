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
        List<TreeNode> nodes = new List<TreeNode>();
        
        Stack<TreeNode> stack = new Stack<TreeNode>();
        PushLeftTree(root, stack);
        
        while(stack.Count > 0){
            var node = stack.Pop();
            nodes.Add(node);
            if(node.right != null)
                PushLeftTree(node.right, stack);
        }
        
        return ConstructBST(nodes, 0, nodes.Count -1);
    }
    
    private TreeNode ConstructBST(List<TreeNode> nodes, int start, int end)
    {
        if(start > end)
            return null;
        
        int mid = start + (end - start) / 2;
        var root = nodes[mid];
        root.left = ConstructBST(nodes, start, mid - 1);
        root.right = ConstructBST(nodes, mid + 1, end);
        return root;
    }
    
    private void PushLeftTree(TreeNode root, Stack<TreeNode> stack)
    {
        var trav = root;
        while(trav != null){
            stack.Push(trav);
            trav = trav.left;
        }
    }
}