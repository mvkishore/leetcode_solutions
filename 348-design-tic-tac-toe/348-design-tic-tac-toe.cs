public class TicTacToe {
    int[] rows;
    int[] cols;
    int dia, antiDia;
    int n;
    public TicTacToe(int n) {
        rows = new int[n];
        cols = new int[n];
        this.n = n;
    }
    
    public int Move(int row, int col, int player) {
        int val = player == 1 ? 1 : -1;
        rows[row] += val;
        cols[col] += val;
        
        if(row == col)
            dia += val;
        
        if(row == n - col - 1)
            antiDia += val;
        
        if(Math.Abs(rows[row]) == n ||
           Math.Abs(cols[col]) == n ||
           Math.Abs(dia) == n ||
           Math.Abs(antiDia) == n)
            return player;
        
        return 0;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */