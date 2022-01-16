public class Solution {
    public int[] FindDiagonalOrder(int[][] mat) {
        List<int> result = new List<int>();
        
        Traverse(mat, 0, 0, 1, result);
        return result.ToArray();
    }
    
    private void Traverse(int[][] mat, int row, int col, int dir, IList<int> result)
    {
        int rows = mat.Length;
        int cols = mat[0].Length;
        
        if(result.Count == rows * cols)
            return;
        
        result.Add(mat[row][col]);
        
        if(dir == 1 && row < rows && col == cols - 1)
            Traverse(mat, row + 1, col, -dir, result);
        else if(dir == 1 && col < cols && row == 0)
            Traverse(mat, row, col + 1, -dir, result);
        else if(dir == -1 && col < cols && row == rows -1)
            Traverse(mat, row, col + 1, -dir, result);
        else if(dir == -1 && row < rows && col == 0)
            Traverse(mat, row + 1, col, -dir, result);
        else
            Traverse(mat, row - dir, col + dir, dir, result);
    }
}