public class TicTacToe {
    int [,] board;
    int n;
    public TicTacToe(int n) {
        board = new int[n,n];
        this.n = n;
    }
    
    public int Move(int row, int col, int player) {
        board[row, col] = player;
        
        if(CheckRow(row, player) || CheckColumn(col, player)
          || (row == col && CheckDiagonal(player))
          || (row == n - col - 1 && CheckAntiDiagonal(player)))
            return player;
        
        return 0;
    }
    
    private bool CheckRow(int row, int player){
        for(int i=0; i < n; i++)
            if(board[row, i] != player)
                return false;
        return true;
    }
    
    private bool CheckColumn(int col, int player){
        for(int i=0; i < n; i++)
            if(board[i, col] != player)
                return false;
        return true;
    }
    
    private bool CheckDiagonal(int player){
        for(int i=0; i<n; i++)
            if(board[i, i] != player)
                return false;
        return true;
    }
    
    private bool CheckAntiDiagonal(int player){
        for(int i=0; i<n; i++)
            if(board[i, n - i -1] != player)
                return false;
        return true;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */