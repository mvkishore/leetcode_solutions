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
    public TreeNode FindNearestRightNode(TreeNode root, TreeNode u) {
        if(root == null)
            return null;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while(queue.Count > 0){
            int size = queue.Count;
            for(int i=0; i<size; i++){
                root = queue.Dequeue();
                if(root.val == u.val)
                {
                    if(queue.Count > 0 && i < size - 1)
                        return queue.Dequeue();
                    return null;
                }
                
                if(root.left != null)
                    queue.Enqueue(root.left);
                if(root.right != null)
                    queue.Enqueue(root.right);
            }
        }
        
        return null;
    }
}