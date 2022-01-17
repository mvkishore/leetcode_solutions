public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        IList<int> res = new List<int>();
        Traverse(matrix, 0, 0, 0, 0, res);
        return res;
    }
    
    private void Traverse(int[][] matrix, int row, int col, int depth, int dir, IList<int> res)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        
        if(res.Count == rows * cols)
            return;
        
        rows = rows - depth;
        cols = cols - depth;
        res.Add(matrix[row][col]);
        
        if(dir == 0 && row < rows && col == cols - 1){
            Traverse(matrix, row + 1, col, depth, dir + 1, res);
        }else if(dir == 1 && col < cols && row == rows - 1 ){
            Traverse(matrix, row, col - 1, depth, dir + 1, res);
        }else if(dir == 2 && row > depth && col == depth ){
            Traverse(matrix, row - 1, col, depth, dir + 1, res);
        }else if(dir == 3 && col >= depth && row == depth + 1){
            Traverse(matrix, row, col + 1, depth + 1, (dir + 1)%4, res);
        }else{
            var dirs = new int[][] {new []{0, 1}, new [] {1, 0}, new []{0, -1}, new []{-1, 0}};
            
            Traverse(matrix, row + dirs[dir][0], col + dirs[dir][1], depth, dir, res);  
        }
    }
}