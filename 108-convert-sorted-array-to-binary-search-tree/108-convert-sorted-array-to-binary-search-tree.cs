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
    public TreeNode SortedArrayToBST(int[] nums) {
        int n = nums.Length;
        return BuildBST(nums, 0, n - 1);
    }
    
    public TreeNode BuildBST(int[] nums, int start, int end){
        if(start > end)
            return null;
        
        if(start == end)
            return new TreeNode(nums[start]);
        
        int mid = (start + end) / 2;
        TreeNode root = new TreeNode(nums[mid]);
        root.left = BuildBST(nums, start, mid - 1);
        root.right = BuildBST(nums, mid + 1, end);
        
        return root;
    }
}