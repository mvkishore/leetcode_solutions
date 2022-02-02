public class Vector2D {
    int[][] vector;
    int row, col;
    int rows, cols;
    public Vector2D(int[][] vec) {
        vector = vec;
        rows = vec.Length;
    }
    
    public int Next() {
        if(HasNext()){
            return vector[row][col++];
        }
        return -1;
    }
    
    public bool HasNext() {
        while(row < rows && col == vector[row].Length){
            row++;
            col = 0;
        }
        return row < rows;
    }
}

/**
 * Your Vector2D object will be instantiated and called as such:
 * Vector2D obj = new Vector2D(vec);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */