public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        IList<int> res = new List<int>();
        
        int m = matrix.Length, n = matrix[0].Length;
        int[][] dirs = new int[][]{ new []{0, 1}, new []{1, 0}, new []{0,-1}, new [] {-1, 0}};
        
        int row = 0, col = 0, depth = 0, dir = 0;
        
        while(res.Count < m * n){
            res.Add(matrix[row][col]);
            
            int rows = m - depth;
            int cols = n - depth;
            
            if(dir == 0 && col == cols - 1){
                dir++; row++;
            } else if(dir == 1 && row == rows - 1){
                dir++; col--;
            } else if(dir == 2 && col == depth){
                dir++; row--;
            } else if(dir == 3 && row == depth + 1){
                dir++; col++;
                dir %= 4;
                depth++;
            }else{
                row = row + dirs[dir][0];
                col = col + dirs[dir][1];
            }
        }
        return res;
    }
}