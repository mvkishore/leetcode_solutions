public class Solution {
    public int CherryPickup(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int[,,] memo = new int[m, n, n];
        for(int i=0;i<m; i++)
            for(int j=0;j<n; j++)
                for(int k=0;k<n; k++)
                    memo[i,j,k] = -1;
        
        
        return CherryPickup(grid, 0, 0, n-1, memo);
    }
    
    private int CherryPickup(int[][] grid, int row, int rob1, int rob2,int [,,] memo){
        int m = grid.Length;
        int n = grid[0].Length;
        
        if(rob1 >= n || rob1 < 0 || rob2 >= n || rob2 < 0)
            return 0;
        
        if(memo[row, rob1, rob2] != -1)
            return memo[row, rob1, rob2];
        
        int result = 0;
        result += grid[row][rob1];
        
        if(rob1 != rob2)
            result += grid[row][rob2];
        
        if(row == m -1)
            return result;
        
        int max = 0;
        for(int nextRob1 = rob1 - 1; nextRob1 <= rob1 + 1; nextRob1++){
            for(int nextRob2 = rob2 - 1; nextRob2 <= rob2 + 1; nextRob2++){
                max = Math.Max(max, CherryPickup(grid, row + 1, nextRob1, nextRob2, memo));
            }
        }
        return memo[row, rob1, rob2] = result + max;
    }
}