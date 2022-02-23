public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        SortedSet<(int val, int row, int col)> heap = new SortedSet<(int val, int row, int col)>();
        int rows = matrix.Length, cols = matrix[0].Length;
        
        heap.Add((matrix[0][0], 0, 0));
        var dirs = new int[][]{new []{0, 1}, new [] {1, 0}};
        
        while(k > 1){
            var pos = heap.Min;
            heap.Remove(pos);
            foreach(var dir in dirs)
            {
                int nextRow = pos.row + dir[0], nextCol = pos.col + dir[1];
                if(nextRow < rows && nextCol < cols){
                    heap.Add((matrix[nextRow][nextCol], nextRow, nextCol));
                }
            }
            k--;
        }
        return heap.Min.val;
    }
}