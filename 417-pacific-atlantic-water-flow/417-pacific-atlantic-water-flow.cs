public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        int rows = heights.Length;
        int cols = heights[0].Length;
        
        bool[,] flowsToPacific = new bool[rows, cols];
        bool[,] flowsToAtlantic = new bool[rows, cols];
        
        for(int row=0; row<rows; row++)
        {
            flowsToPacific[row, 0] = true;
            flowsToAtlantic[row, cols-1] = true;
        }
        for(int col=0; col< cols; col++)
        {
            flowsToPacific[0, col] = true;
            flowsToAtlantic[rows-1, col] = true;
        }
        
        flowWater(heights, flowsToPacific);
        flowWater(heights, flowsToAtlantic);
        
        IList<IList<int>> res = new List<IList<int>>();
        for(int row=0; row<rows; row++){
            for(int col=0; col<cols; col++){
                if(flowsToPacific[row, col] && flowsToAtlantic[row, col])
                    res.Add(new List<int>{row, col});
            }
        }
        
        return res;
    }
    
    private void flowWater(int[][] heights, bool[,] waterReached) {
        int rows = heights.Length;
        int cols = heights[0].Length;
        
        Queue<int[]> queue = new Queue<int[]>();
        for(int row=0; row<rows; row++){
            for(int col=0; col<cols; col++){
                if(waterReached[row, col])
                    queue.Enqueue(new []{ row, col});
            }
        }
        
        while(queue.Count > 0){
            var cur = queue.Dequeue();
            int row = cur[0], col = cur[1];
            foreach(var nextLand in GetNextLand(row, col, rows, cols)){
                int nextRow = nextLand[0], nextCol = nextLand[1];
                if(heights[row][col] <= heights[nextRow][nextCol] && !waterReached[nextRow, nextCol]){
                    waterReached[nextRow, nextCol] = true;
                    queue.Enqueue(new []{ nextRow, nextCol});
                }
            }
        }
    }
    
    private IList<int[]> GetNextLand(int row, int col, int rows, int cols){
        var nextLands = new List<int[]>();
        var dirs = new int [][] {new []{ 0, 1}, new []{ 0, -1}, new []{ 1, 0}, new []{ -1, 0}};
        
        foreach(var dir in dirs){
            int nextRow = row + dir[0], nextCol = col + dir[1];
            if(nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols)
                nextLands.Add(new []{ nextRow, nextCol});
        }
        return nextLands;
    }
}