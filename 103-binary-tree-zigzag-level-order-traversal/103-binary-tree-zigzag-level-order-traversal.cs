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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        IList<IList<int>> res = new List<IList<int>>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        
        if(root != null)
            queue.Enqueue(root);
        int level = 0;
        while(queue.Count > 0){
            int size = queue.Count;
            var list = new List<int>();
            for(int i=0; i<size; i++){
                root = queue.Dequeue();
                if(root.left != null)
                    queue.Enqueue(root.left);
                if(root.right != null)
                    queue.Enqueue(root.right);
                if(level % 2 == 0)
                    list.Add(root.val);
                else
                    list.Insert(0, root.val);
            }
            res.Add(list);
            level++;
        }
        
        return res;
    }
}