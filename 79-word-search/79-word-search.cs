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
        if(index == word.Length)
            return true;
        
        if(index == word.Length - 1 && board[row][col] == word[index])
            return true;
        
        if(board[row][col] != word[index])
            return false;
        
        visited[row, col] = true;
        foreach(var next in GetNextMove(row, col, board))
        {
            int nextRow = next[0], nextCol = next[1];
            if(!visited[nextRow, nextCol] 
               && Exist(board, nextRow, nextCol, index + 1, word, visited)){
                return true;
            }
        }
        visited[row, col] = false;
        return false;
    }
    private List<int[]> GetNextMove(int row, int col, char[][] board)
    {
        int rows = board.Length, cols = board[0].Length;
        List<int[]> nextMoves = new List<int[]>();
        var dirs = new int[][] {new []{0, 1}, new []{1, 0},new []{-1, 0},new []{0, -1}};
        
        foreach(var dir in dirs){
            int nextRow = row + dir[0], nextCol = col + dir[1];
            if(nextRow < rows && nextRow >= 0 && nextCol < cols && nextCol >= 0){
                nextMoves.Add(new []{nextRow, nextCol});
            }
        }
        return nextMoves;
    }
}