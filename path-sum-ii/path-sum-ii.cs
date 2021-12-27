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
 
 target = 22,
 
 
 
 
 */
public class Solution {
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        IList<IList<int>> results = new List<IList<int>>();
        IList<int> path = new List<int>();
        
        PathSum(root, path, targetSum, results);
        return results;
    }
    /*
        
     
       
         target=17, node=8, curPath=[5,]
        --> right
        target=22, node=5, curPath=[5,]
    */
    private void PathSum(TreeNode node, IList<int> curPath, int target, IList<IList<int>> results){
        if(node == null)
            return;
        
        if(node.left == null && node.right == null)
        {
            if(target == node.val){
                var list = new List<int>(curPath);
                list.Add(node.val);
                results.Add(list);
            }
            return;
        }
        
        curPath.Add(node.val);
        PathSum(node.left, curPath, target - node.val, results);
        PathSum(node.right, curPath, target - node.val, results);
        curPath.RemoveAt(curPath.Count - 1);
    }
}