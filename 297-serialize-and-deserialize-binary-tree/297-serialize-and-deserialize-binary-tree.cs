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
        serialize(root, sb);
        sb.Length--;
        return sb.ToString();
    }
    
    private void serialize(TreeNode root, StringBuilder sb)
    {
        if(root == null){
            sb.Append("-");
            sb.Append(",");
            return;
        }
        serialize(root.left, sb);
        serialize(root.right, sb);
        sb.Append(root.val);
        sb.Append(",");
    }
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        var nodes = data.Split(",");
        for(int i=0; i<nodes.Length; i++){
            var cur = nodes[i];
            if(cur == "-")
                stack.Push(null);
            else
            {
                var val = Convert.ToInt32(cur);
                var node = new TreeNode(val);
                if(stack.Count > 0)
                    node.right = stack.Pop();
                if(stack.Count > 0)
                    node.left = stack.Pop();
                stack.Push(node);
            }
        }
        return stack.Pop();
    }
}
// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));