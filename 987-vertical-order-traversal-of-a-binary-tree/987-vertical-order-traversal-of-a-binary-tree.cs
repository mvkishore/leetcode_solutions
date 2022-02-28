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
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        IList<IList<int>> res = new List<IList<int>>();
        if(root == null)
            return res;
        
        int minCol = int.MaxValue, maxCol = int.MinValue;
        Dictionary<int, List<int>> levels = new Dictionary<int, List<int>>();
        Queue<(TreeNode node, int col)> queue = new Queue<(TreeNode, int)>();
        
        queue.Enqueue((root, 0));
        
        while(queue.Count > 0){
            var size = queue.Count;
            Dictionary<int, List<int>> rowList = new Dictionary<int, List<int>>();
            for(int i=0; i<size; i++){
                var cur = queue.Dequeue();
                int col = cur.col;
                var node = cur.node;
                if(!rowList.ContainsKey(col))
                    rowList.Add(col, new List<int>());
                
                rowList[col].Add(node.val);
                
                if(node.left != null){
                    queue.Enqueue((node.left, col - 1));
                }
                
                if(node.right != null){
                    queue.Enqueue((node.right, col + 1));
                }
                minCol = Math.Min(minCol, col);
                maxCol = Math.Max(maxCol, col);
            }
            foreach(var pair in rowList){
                int col = pair.Key;
                var list = pair.Value;
                if(!levels.ContainsKey(col))
                    levels.Add(col, new List<int>());
                list.Sort();
                levels[col].AddRange(list);
            }
        }
        
        for(int c=minCol; c<=maxCol; c++){
            res.Add(levels[c]);
        }
        return res;
    }
}