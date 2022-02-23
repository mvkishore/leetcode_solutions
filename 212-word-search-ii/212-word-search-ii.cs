public class Solution {
    public class TrieNode {
        public TrieNode[] childrens;
        public string word;
        
        public TrieNode(){
            childrens = new TrieNode[26];
        }
    }
    public IList<string> FindWords(char[][] board, string[] words) {
        IList<string> results = new List<string>();
        TrieNode root = new TrieNode();
        
        foreach(var word in words)
            AddWord(word, root);
        Search(board, root, results);
        return results;
    }
    
    public void AddWord(string word, TrieNode root){
        var cur = root;
        foreach(var c in word){
            if(cur.childrens[c-'a'] == null)
                cur.childrens[c - 'a'] = new TrieNode();
            cur = cur.childrens[c - 'a'];
        }
        cur.word = word;
    }
    
    private void Search(char[][] board, TrieNode root, IList<string> results) {
        int m = board.Length, n = board[0].Length;
        for(int row=0; row < m; row++){
            for(int col=0; col < n; col++){
                if(root.childrens[board[row][col] - 'a'] != null)
                    Search(board, row, col, root, results);
            }
        }
    }
    
    private void Search(char[][] board, int row, int col, TrieNode root, IList<string> results){
        int m = board.Length, n = board[0].Length;
        var c = board[row][col];
        var curNode = root.childrens[c-'a'];
        
        if(curNode.word != null){
            results.Add(curNode.word);
            curNode.word = null;
        }
        board[row][col] = '-';
        
        foreach(var next in GetNext(row, col, m, n)){
            int nextRow = next[0], nextCol = next[1];
            var nC = board[nextRow][nextCol];

            if(nC != '-' && curNode.childrens[nC - 'a'] != null)
                Search(board, nextRow, nextCol, curNode, results);
        }
        board[row][col] = c;
        
        if(curNode.childrens.Count(x=> x != null) == 0)
            root.childrens[c - 'a'] = null;
    }
    
    private List<int[]> GetNext(int row, int col, int rows, int cols){
        var dirs = new int[][] {new []{0, 1}, new []{0, -1}, new []{1, 0}, new []{-1, 0}};
        List<int[]> list = new List<int[]>();
        
        foreach(var dir in dirs){
            var nextRow = row + dir[0];
            var nextCol = col + dir[1];
            if(nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols)
                list.Add(new []{nextRow, nextCol});
        }
        return list;
    }
    
}