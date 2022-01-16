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
 
 
            3                       0
        9       8
    4       01      7
 
 
 
 
 */
public class Solution {
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        if(root == null)
            return new List<IList<int>>();
        
        Dictionary<int, List<int>> cols = new Dictionary<int, List<int>>();
        Queue<(TreeNode node, int col)> queue = new Queue<(TreeNode node, int col)>();
        queue.Enqueue((root, 0));
        
        int minCol = 0, maxCol = 0;
        while(queue.Count > 0){
            int size = queue.Count;
            
            for(int i= 0; i < size ; i++){
                var cur = queue.Dequeue();
                
                int col = cur.col;
                int val = cur.node.val;
                
                if(!cols.ContainsKey(col))
                    cols.Add(col, new List<int>());
                
                cols[col].Add(val);
                
                if(cur.node.left != null)
                    queue.Enqueue((cur.node.left, col - 1));
                
                if(cur.node.right != null)
                    queue.Enqueue((cur.node.right, col + 1));
                                  
                minCol = Math.Min(minCol, col);
                maxCol = Math.Max(maxCol, col);
            }
        }
        
        IList<IList<int>> res = new List<IList<int>>();
        for(int i=minCol; i<= maxCol; i++)
            res.Add(cols[i]);
        
        return res;
    }
}