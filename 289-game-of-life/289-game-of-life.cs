public class Solution {
    public void GameOfLife(int[][] board) {
        int m = board.Length;
        int n = board[0].Length;
        
        for(int i=0; i<m ; i++){
            for(int j=0; j<n; j++){
                UpdateNextState(board, i, j, board[i][j] > 0);
            }
        }
        
        for(int i=0; i<m ; i++){
            for(int j=0; j<n; j++){
                if(board[i][j] == -1)
                    board[i][j] = 1;
                else if(board[i][j] == 2)
                    board[i][j] = 0;
            }
        }
    }
    
    private void UpdateNextState(int[][] board, int row, int col, bool live)
    {
        int rows = board.Length;
        int cols = board[0].Length;
        int population = 0;
        
        foreach(var nei in GetNeighboars(row, col, rows, cols))
        {
            if(board[nei[0]][nei[1]] > 0)
                population++;
        }
        
        if(!live && population == 3)
        {
            board[row][col] = -1;
            return;
        }
        
        if(live && (population < 2 || population > 3))
            board[row][col] = 2;
    }
    
    private List<int[]> GetNeighboars(int row, int col, int rows, int cols)
    {
        var nextPos = new List<int[]>();
        int[][] dirs = new int[][]{
                            new []{ 0, 1}, new []{ 1, 0}, new []{ 0, -1}, new []{ -1, 0},
                            new []{ 1, 1}, new []{ -1, 1}, new []{ 1, -1}, new []{ -1, -1}
                        };
        
        foreach(var dir in dirs){
            int nRow = row + dir[0], nCol = col + dir[1];
            if(nRow >= 0 && nRow < rows && nCol >=0 && nCol < cols)
                nextPos.Add(new []{nRow, nCol});
        }
        return nextPos;
    }
}