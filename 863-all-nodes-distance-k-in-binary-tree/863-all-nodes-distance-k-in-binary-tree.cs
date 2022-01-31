/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        Dictionary<int, int> lengths = new Dictionary<int, int>();
        IList<int> res = new List<int>();
        
        Find(root, target, lengths);
        DistanceK(root, lengths, k, 0, res);
        return res;
    }
    
    private void DistanceK(TreeNode root, Dictionary<int, int> lengths, int k, int length, IList<int> res)
    {
        if(root == null)
            return;
        
        if(lengths.ContainsKey(root.val))
            length = lengths[root.val];
        if(length == k)
        {
            res.Add(root.val);
        }
        
        DistanceK(root.left, lengths, k, length + 1, res);
        DistanceK(root.right, lengths, k, length + 1, res);
    }
    
    private int Find(TreeNode root, TreeNode target, Dictionary<int, int> lengths)
    {
        if(root == null)
            return -1;
        
        if(root.val == target.val)
        {
            lengths.Add(root.val, 0);
            return 0;
        }
        
        int left = Find(root.left, target, lengths);
        if(left >= 0)
        {
            lengths.Add(root.val, left + 1);
            return left + 1;
        }
        
        int right = Find(root.right, target, lengths);
        if(right >= 0)
        {
            lengths.Add(root.val, right + 1);
            return right + 1;
        }
        
        return -1;
    }
}