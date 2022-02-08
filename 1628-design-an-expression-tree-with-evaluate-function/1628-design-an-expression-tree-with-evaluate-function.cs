/**
 * This is the interface for the expression tree Node.
 * You should not remove it, and you can define some classes to implement it.
 */

public abstract class Node {
    public abstract int evaluate();
    // define your fields here
}

public class NumericNode : Node {
     int val;
     public NumericNode(int val){
         this.val = val;
     }
     public override int evaluate(){
         return val;
     }
}

public abstract class OperatorNode : Node {
    public Node left;
    public Node right;
    
    public OperatorNode(Node left, Node right){
        this.left = left;
        this.right = right;
    }
}

public class AddNode : OperatorNode
{
    public AddNode(Node left, Node right): base(left, right)
    {}
    public override int evaluate(){
        var res = this.left.evaluate() + this.right.evaluate();        
        return res;
    }
}
public class MultiplyNode : OperatorNode
{
    public MultiplyNode(Node left, Node right): base(left, right)
    {}
    public override int evaluate(){
        var res = this.left.evaluate() * this.right.evaluate();
        return res;
    }
}
public class SubtractNode : OperatorNode
{
    public SubtractNode(Node left, Node right): base(left, right)
    {}
    public override int evaluate(){
        var res = this.right.evaluate() - this.left.evaluate();
        return res;
    }
}
public class DevideNode : OperatorNode
{
    public DevideNode(Node left, Node right): base(left, right)
    {}
    public override int evaluate(){
        var res = this.right.evaluate() / this.left.evaluate();
        return res;
    }
}

/**
 * This is the TreeBuilder class.
 * You can treat it as the driver code that takes the postinfix input 
 * and returns the expression tree represnting it as a Node.
 */

public class TreeBuilder {
    public Node buildTree(string[] postfix) {
        Stack<Node> seenNodes = new Stack<Node>();
        foreach(var str in postfix){
            if(int.TryParse(str, out int num)){
                seenNodes.Push(new NumericNode(num));
            }else{
                var left = seenNodes.Pop();
                var right = seenNodes.Pop();
                seenNodes.Push(getNode(str, left, right));
            }
        }
        return seenNodes.Pop();
    }
    private Node getNode(string str, Node left, Node right)
    {
        Node root = null;
        switch(str){
            case "+":
                root = new AddNode(left, right);
                break;
            case "-":
                root = new SubtractNode(left, right);
                break;
            case "*":
                root = new MultiplyNode(left, right);
                break;
            case "/":
                root = new DevideNode(left, right);
                break;
        }
        return root;
    }
}


/**
 * Your TreeBuilder object will be instantiated and called as such:
 * TreeBuilder obj = new TreeBuilder();
 * Node expTree = obj.buildTree(postfix);
 * int ans = expTree.evaluate();
 */