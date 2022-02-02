/*

[
[1,5,9],
[10,11,13],
[12,15,18]
[13', 17, 19]
0 - n^2

7 -> 7 / 3 , 7 % 3 ==> 2, 1 ==> 3*2 => 6

(i, j) ==> 
(i-1, n) ==> find position ==> x elements less than mid ===> log(n)
(i+1, j-1) ==> find position ==> y elements less than mid

mPos = (i-2*n) + x + i + y === k - 1 ==> ans 

time: O(log(n^2)*log(n))



*/

public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        SortedSet<(int val, int row, int col)> heap = new SortedSet<(int val, int row, int col)>();
        int n = matrix.Length;
        
        heap.Add((matrix[0][0], 0, 0));
        while(k > 1){
            var min = heap.Min;
            heap.Remove(min);
            var dirs = new int[][]{new []{0, 1}, new []{1, 0}};
            foreach(var dir in dirs){
                int nextRow = min.row + dir[0];
                int nextCol = min.col + dir[1];
                
                if(nextRow < n && nextCol < n){
                    heap.Add((matrix[nextRow][nextCol], nextRow, nextCol));
                }
            }
            k--;
        }
        
        return heap.Min.val;
    }
}