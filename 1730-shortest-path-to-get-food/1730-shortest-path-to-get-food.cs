public class Solution {
    public int GetFood(char[][] grid) {
        Queue<int[]> queue = new Queue<int[]>();
        
        int rows = grid.Length;
        int cols = grid[0].Length;
        
        for(int row = 0; row < rows; row++){
            for(int col = 0; col < cols; col++){
                if(grid[row][col] == '*')
                {
                    queue.Enqueue(new int[]{ row, col});
                    break;
                }
            }
            if(queue.Count > 0)
                break;
        }
        
        bool[,] visited = new bool[rows, cols];
        int length = 0;
        
        while(queue.Count > 0)
        {
            int size = queue.Count;
            
            for(int i=0; i<size; i++)
            {
                var cur = queue.Dequeue();
                int curRow = cur[0], curCol = cur[1];
                
                if(visited[curRow, curCol]) continue;
                
                if(grid[curRow][curCol] == '#') 
                    return length;
                
                visited[curRow, curCol] = true;
                
                foreach(var nei in GetNext(curRow, curCol, rows, cols)){
                    int nextRow = nei[0], nextCol = nei[1];
                    
                    if(grid[nextRow][nextCol] == '#')
                        return 1 + length;
                    
                    if(!visited[nextRow, nextCol] && grid[nextRow][nextCol] == 'O')
                        queue.Enqueue(new int[] {nextRow, nextCol});
                }
            }
            length++;
        }
        return -1;
    }
    
    private IList<int[]> GetNext(int row, int col, int rows, int cols)
    {
        var dirs = new int[][] {new []{0, 1},new []{1, 0},new []{0, -1},new []{-1, 0}};
        var res = new List<int[]>();
        
        foreach(var dir in dirs){
            int nextRow = row + dir[0], nextCol = col + dir[1];
            if(nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols)
                res.Add(new int[]{nextRow, nextCol});
        }
        
        return res;
    }
}