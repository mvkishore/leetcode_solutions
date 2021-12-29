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
    int diameter = 0;
    List<TreeNode> maxPath = new List<TreeNode>();
    public int DiameterOfBinaryTree(TreeNode root) {
        var path = MaxPath(root);
        foreach(var node in maxPath){
            Console.Write($"{node.val} ");
        }
        return diameter;
    }
    
    public List<TreeNode> MaxPath(TreeNode root) {
        if(root == null)
            return new List<TreeNode>();
        
        var leftPath = MaxPath(root.left);
        var rightPath = MaxPath(root.right);
        if(leftPath.Count + rightPath.Count > diameter){
            maxPath = new List<TreeNode>(leftPath);
            maxPath.Add(root);
            maxPath.AddRange(rightPath);
            diameter = leftPath.Count + rightPath.Count;
        }
        
        var path = new List<TreeNode>(leftPath.Count > rightPath.Count ? leftPath : rightPath);
        path.Add(root);
        return path;
    }
}