public class Solution {
    int n = 3;
    public string Tictactoe(int[][] moves) {
        int[] rows = new int[n], cols = new int[n];
        int dia = 0, antiDia = 0;
        
        int player = 1;
        for(int i=0; i<moves.Length; i++){
            int row = moves[i][0];
            int col = moves[i][1];
            
            rows[row] += player;
            cols[col] += player;
            if(row == col)
                dia += player;
            if(row + col == n -1)
                antiDia += player;
            
            if(Math.Abs(rows[row]) == n || Math.Abs(cols[col]) == n ||
               Math.Abs(dia) == n || Math.Abs(antiDia) == n)
                return player == 1 ? "A" : "B";
            player = -player;
        }
        
        return moves.Length == n*n ? "Draw" : "Pending";
    }
}