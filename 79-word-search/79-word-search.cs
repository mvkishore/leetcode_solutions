public class Solution {
    public bool Exist(char[][] board, string word) {
        int rows = board.Length, cols = board[0].Length;
        
        for(int row = 0; row < rows; row++){
            for(int col = 0; col < cols; col++){
                if(board[row][col] == word[0]){
                    var visited = new bool[rows, cols];
                    if(Find(word, 0, board, row, col, visited))
                        return true;
                }
            }
        }
        return false;
    }
    private bool Find(string word, int indx, char[][] board, int row, int col, bool[,] visited)
    {
        int rows = board.Length, cols = board[0].Length;
        if(indx == word.Length)
            return true;
        
        
        if(row < 0 || row >= rows || col < 0 || col >= cols || visited[row, col])
            return false;
        
        if(board[row][col] != word[indx])
            return false;
        
        visited[row, col] = true;
        
        if( Find(word, indx + 1, board, row + 1, col, visited) ||
            Find(word, indx + 1, board, row - 1, col, visited) ||
            Find(word, indx + 1, board, row, col + 1, visited) ||
            Find(word, indx + 1, board, row, col - 1, visited))
            return true;
            
        visited[row, col] = false;
        return false;
    }
}