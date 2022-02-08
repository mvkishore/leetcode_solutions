public class TicTacToe {
    char [,] board;
    public TicTacToe(int n) {
        board = new char[n,n];
    }
    
    public int Move(int row, int col, int player) {
        board[row, col] = player == 1 ? 'X' : 'O';
        return Check(player);
    }
    
    private int Check(int player) {
        char c = player == 1 ? 'X' : 'O'; 
        int n = board.GetLength(0);
        int diaCount = 0, aDiaCount = 0;

        for(int i=0; i < n; i++){
            int rowCount =0, colCount = 0;
            for(int j=0; j< n; j++){
                rowCount += (board[i,j] == c ? 1 : 0);
                colCount += (board[j,i] == c ? 1 : 0);
                if(i == j)
                    diaCount += (board[i,j] == c ? 1 : 0);
                if(i + j == n - 1)
                    aDiaCount += (board[i,j] == c ? 1 : 0);
            }
            if(rowCount == n || colCount == n || diaCount == n || aDiaCount == n)
                return player;
        }
        
        return 0;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */