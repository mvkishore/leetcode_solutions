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
    int minCol = int.MaxValue, maxCol = int.MinValue;
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        Dictionary<int, List<(int row, int val)>> verticals = new Dictionary<int, List<(int row, int val)>>();
        
        VerticalOrder(root, verticals, 0, 0);
        IList<IList<int>> result = new List<IList<int>>();
        for(int i=minCol; i<=maxCol; i++){
            result.Add(verticals[i].OrderBy(x=>x.row).Select(x=>x.val).ToList());
        }
        return result;
    }
    
    private void VerticalOrder(TreeNode root, Dictionary<int, List<(int row, int val)>> verticals, int col, int row)
    {
        if(root == null)
            return;
        
        if(!verticals.ContainsKey(col))
            verticals.Add(col, new List<(int row, int val)>());
        
        minCol = Math.Min(minCol, col);
        maxCol = Math.Max(maxCol, col);
        
        verticals[col].Add((row, root.val));
        VerticalOrder(root.left, verticals, col - 1, row + 1);
        VerticalOrder(root.right, verticals, col + 1, row + 1);
    }
}