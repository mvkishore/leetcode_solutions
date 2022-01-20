public class NumMatrix {
    int[,] cache;
    int[][] matrix;
    public NumMatrix(int[][] matrix) {
        int m = matrix.Length;
        int n = matrix[0].Length;
        this.matrix = matrix;
        
        cache = new int[m, n];
        for(int row=0; row < m; row++){
            int sum =0;
            for(int col=0; col< n; col++){
                sum += matrix[row][col];
                cache[row, col] = sum + ((row > 0) ? cache[row-1, col] : 0);
            }
        }
    }
    public void Update(int uRow, int uCol, int val) {
        var prev = matrix[uRow][uCol];
        var diff = prev - val;
        
        matrix[uRow][uCol] = val;
        
        int m = matrix.Length;
        int n = matrix[0].Length;
        for(int row=uRow; row < m; row++){
            for(int col=uCol; col< n; col++){
                cache[row, col] = cache[row, col] - diff;
            }
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        int OA = (row1 > 0 && col1 > 0 ) ? cache[row1 - 1, col1 - 1] : 0;
        int OB = (row1 > 0) ? cache[row1 - 1, col2] : 0;
        int OC = (col1 > 0) ? cache[row2, col1 - 1] : 0;
        int OD = cache[row2, col2];
        
        return OD - OB - OC + OA;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * obj.Update(row,col,val);
 * int param_2 = obj.SumRegion(row1,col1,row2,col2);
 */