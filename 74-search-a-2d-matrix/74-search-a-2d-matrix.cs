public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int m = matrix.Length, n = matrix[0].Length, row = m - 1, col = 0;
        
        while(row > 0){
            if(matrix[row][col] == target)
                return true;
            
            if(matrix[row][col] > target)
                row--;
            else
                break;
        }
        
        int lo = 0, hi = n-1;
        
        while(lo <= hi){
            int mid = lo + (hi - lo) / 2;

            if(matrix[row][mid] == target)
                return true;
            
            if(matrix[row][mid] < target)
                lo = mid + 1;
            else
                hi = mid - 1;
        }
        return false;
    }
}