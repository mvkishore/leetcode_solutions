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
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        int left = int.MaxValue, right = int.MinValue;
        IList<IList<int>> results = new List<IList<int>>();
        if(root == null)
            return results;
        
        Dictionary<int, IList<int>> verticalLevels = new Dictionary<int, IList<int>>();
        Queue<(TreeNode node, int level)> queue = new Queue<(TreeNode node, int level)>();
        
        queue.Enqueue((root, 0));
        while(queue.Count > 0){
            var size = queue.Count;
            
            for(int i=0; i<size; i++){
                var cur = queue.Dequeue();
                if(!verticalLevels.ContainsKey(cur.level))
                    verticalLevels.Add(cur.level, new List<int>());
                verticalLevels[cur.level].Add(cur.node.val);
                
                if(cur.node.left != null)
                    queue.Enqueue((cur.node.left, cur.level - 1));
                if(cur.node.right != null)
                    queue.Enqueue((cur.node.right, cur.level + 1));
                
                left = Math.Min(cur.level, left);
                right = Math.Max(cur.level, right);
            }
        }
        
        for(int i=left; i<= right; i++){
            results.Add(verticalLevels[i]);
        }
        return results;
    }
}