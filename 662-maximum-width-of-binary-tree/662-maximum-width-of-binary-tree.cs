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
    public int WidthOfBinaryTree(TreeNode root) {
        if(root == null)
            return 0;
        
        int maxWidth = 1;
        
        Queue<(TreeNode node, int col)> queue = new Queue<(TreeNode node, int col)>();
        queue.Enqueue((root, 1));
        
        while(queue.Count > 0){
            int size = queue.Count;
            var first = queue.Peek();
            (TreeNode node, int col) last = (null, 0);
            
            for(int i=0; i < size; i++){
                last = queue.Dequeue();
                var node = last.node;
                var col = last.col;
                
                if(node.left != null)
                    queue.Enqueue((node.left, col * 2));
                
                if(node.right != null)
                    queue.Enqueue((node.right, col * 2 + 1));
            }
            maxWidth = Math.Max(last.col -  first.col + 1, maxWidth);
        }
        return maxWidth;
    }
}