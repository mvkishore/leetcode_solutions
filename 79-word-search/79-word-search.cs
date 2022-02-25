public class Solution {
    public bool Exist(char[][] board, string word) {
        int rows = board.Length, cols = board[0].Length;
        for(int row = 0; row< rows; row++){
            for(int col = 0; col < cols; col++){
                if(board[row][col] == word[0]){
                    bool[,] visited = new bool[rows, cols];
                    if(Exist(board, row, col, 0, word, visited))
                        return true;
                }
            }
        }
        
        return false;
    }
    
    private bool Exist(char[][] board, int row, int col, int index, string word, bool[,] visited){
        if(index > word.Length)
            return false;
        
        if(index == word.Length)
            return true;
        
        int rows = board.Length, cols = board[0].Length;
        
        if(row < 0 || row >= rows || col < 0 || col >= cols || visited[row, col])
            return false;
        
        if(word[index] != board[row][col])
            return false;
        
        visited[row, col] = true;
        var exist = Exist(board, row + 1, col, index + 1, word, visited)
                    || Exist(board, row , col + 1, index + 1, word, visited)
                    || Exist(board, row - 1, col, index + 1, word, visited)
                    || Exist(board, row, col - 1, index + 1, word, visited);
        visited[row, col] = false;
        
        return exist;
    }
}