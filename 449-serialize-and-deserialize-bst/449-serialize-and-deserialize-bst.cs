/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        StringBuilder sb = new StringBuilder();
        PostOrder(root, sb);
        if(sb.Length > 0)
            sb.Length--;
        return sb.ToString();
    }
    
    private void PostOrder(TreeNode root, StringBuilder sb){
        if(root == null)
            return;
        
        PostOrder(root.left, sb);
        PostOrder(root.right, sb);
        
        sb.Append(root.val);
        sb.Append(' ');
        return;
    }
    
    private TreeNode BuildBST(List<string> values, int min, int max){
        if(values.Count == 0)
            return null;

        var val = Convert.ToInt32(values[values.Count -1]);
        if(val < min || val > max)
            return null;
        
        values.RemoveAt(values.Count -1);
        var root = new TreeNode(val);
        root.right = BuildBST(values, val, max);
        root.left = BuildBST(values, min, val);

        return root;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(string.IsNullOrEmpty(data))
            return null;
        
        var values = data.Split(' ').ToList();
        return BuildBST(values, int.MinValue, int.MaxValue);
    }
}


// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// String tree = ser.serialize(root);
// TreeNode ans = deser.deserialize(tree);
// return ans;