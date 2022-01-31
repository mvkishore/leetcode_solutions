public class Solution {
    public class TrieNode{
        public Dictionary<char, TrieNode> Childrens;
        public string Word;
        
        public TrieNode(){
            Childrens = new Dictionary<char, TrieNode>();
        }
    }
    public IList<string> FindWords(char[][] board, string[] words) {
        TrieNode root = new TrieNode();
        
        foreach(var word in words){
            AddWord(word, root);
        }
        
        int rows = board.Length;
        int cols = board[0].Length;
        IList<string> res = new List<string>();
        
        for(int row=0; row<rows; row++){
            for(int col=0; col< cols; col++){
                if(root.Childrens.ContainsKey(board[row][col])){
                    FindWords(board, row, col, root, res);
                }
            }
        }
        
        return res;
    }
    
    private void FindWords(char[][] board, int row, int col, TrieNode trie, IList<string> res)
    {
        int rows = board.Length;
        int cols = board[0].Length;
        char letter = board[row][col];
        
        var curNode = trie.Childrens[letter];
        if(!string.IsNullOrEmpty(curNode.Word)){
            res.Add(curNode.Word);
            curNode.Word = string.Empty;
        }
        board[row][col] = '#';
        
        foreach(var next in GetNextMoves(row, col, rows, cols)){
            if(curNode.Childrens.ContainsKey(board[next[0]][next[1]]))
                FindWords(board, next[0], next[1], curNode, res);
        }
        
        board[row][col] = letter;
        
        //optimization
        if(curNode.Childrens.Count ==0)
        {
            trie.Childrens.Remove(letter);
        }
    }
    
    private List<int[]> GetNextMoves(int row, int col, int rows, int cols)
    {
        var res = new List<int[]>();
        
        var dirs = new int[][] {new []{0,1}, new []{0,-1}, new []{-1,0}, new []{1, 0}};
        
        foreach(var dir in dirs){
            int nextRow = row + dir[0], nextCol = col + dir[1];
            
            if(nextRow >= 0 && nextRow < rows && nextCol >=0 && nextCol < cols)
                res.Add(new int[]{ nextRow, nextCol});
        }
        return res;
    }
    
    private void AddWord(string word, TrieNode root){
        foreach(var c in word){
            if(!root.Childrens.ContainsKey(c))
                root.Childrens.Add(c, new TrieNode());
            
            root = root.Childrens[c];
        }
        root.Word = word;
    }
}