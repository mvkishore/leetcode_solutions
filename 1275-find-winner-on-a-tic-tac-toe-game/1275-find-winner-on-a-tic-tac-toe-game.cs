public class Solution {
    public string Tictactoe(int[][] moves) {
        int totalMoves = moves.Length;
        char[,] board = new char[3,3];
        
        for(int i=0; i<moves.Length; i++){
            board[moves[i][0], moves[i][1]] = (i % 2 == 0) ? 'X' : 'O';
        }
        
        if(CheckWinner(board, 'X'))
            return "A";
        if(CheckWinner(board, 'O'))
            return "B";
        
        if(moves.Length == 9)
            return "Draw";
        
        return "Pending";
    }
    
    private bool CheckWinner(char[,] board, char mark)
    {
        int diaCount = 0;
        int revDiaCount = 0;
        for(int i=0; i<3; i++){
            int rowCount = 0, colCount = 0;
            for(int j=0; j<3; j++){
                if(board[i,j] == mark)
                    rowCount++;
                if(board[j,i] == mark)
                    colCount++;
                if(i==j && board[i,j] == mark)
                    diaCount++;
                if(i == 2 - j && board[i, j] == mark)
                    revDiaCount++;
            }
            if(rowCount == 3 || colCount == 3)
                return true;
        }
        return diaCount == 3 || revDiaCount == 3;
    }
}