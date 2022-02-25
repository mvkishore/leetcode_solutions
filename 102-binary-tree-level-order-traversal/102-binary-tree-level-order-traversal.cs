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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> res = new List<IList<int>>();
        if(root == null)
            return res;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while(queue.Count > 0){
            int size = queue.Count;
            var level = new List<int>();
            for(int i=0; i<size; ++i){
                root = queue.Dequeue();
                level.Add(root.val);
                if(root.left != null)
                    queue.Enqueue(root.left);
                if(root.right != null)
                    queue.Enqueue(root.right);
            }
            
            res.Add(level);
        }
        return res;
    }
}