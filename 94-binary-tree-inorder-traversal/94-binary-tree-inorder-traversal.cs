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
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> res = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        
        while(root != null || stack.Count > 0){
            while(root != null){
                stack.Push(root);
                root = root.left;
            }
            root = stack.Pop();
            res.Add(root.val);
            root = root.right;
        }
        return res;
    }
}