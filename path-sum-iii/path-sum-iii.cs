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
 
 Keypoints:
    - Maintain seens sums upto the node in hashmap
    - When curSum reaches targetSum, increment count
    - if there's already seenSum = curSum - targetSum, increment count by seenSum times
    
 */
public class Solution {
    
    public int PathSum(TreeNode root, int targetSum) {
        Dictionary<int, int> seenSums = new Dictionary<int,int>();
        seenSums.Add(0, 1);
        return PathSum(root, 0, targetSum, seenSums);
    }
    /*
    
    
    ----
    root=3,
    curSum=18
    targetSum=8,
    seenSum=[(0: 1), (10: 1), (15: 1), (18:1)]
    count=1
    ----
    root=5,
    curSum=15
    targetSum=8,
    seenSum=[(0: 1), (10: 1), (15: 1)]
    -----------
    root=10,
    curSum=10
    targetSum=8,
    seenSum=[(0: 1), (10: 1)]
    
    */
    private int PathSum(TreeNode root, int curSum, int targetSum, Dictionary<int, int> seenSums)
    {
        if(root == null)
            return 0;
        
        int count = 0;
        curSum += root.val;
        
        if(seenSums.ContainsKey(curSum - targetSum))
            count += seenSums[curSum - targetSum];
        
        if(!seenSums.ContainsKey(curSum))
            seenSums.Add(curSum, 0);
        
        seenSums[curSum]++;
        
        count += PathSum(root.left, curSum, targetSum, seenSums);
        count += PathSum(root.right, curSum, targetSum, seenSums);
        
        seenSums[curSum]--;
        return count;
    }
}