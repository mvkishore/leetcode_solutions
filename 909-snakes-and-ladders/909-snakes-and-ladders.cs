public class Solution {
    public int SnakesAndLadders(int[][] board) {
        int n = board.Length;
        int steps = 0;
        bool[] visited = new bool[n * n + 1];
        Queue<int> queue = new Queue<int>();
        visited[1] = true;
        queue.Enqueue(1);
            
        while(queue.Count > 0){
            int size = queue.Count;
            for(int i=0; i<size; i++){
                var cur = queue.Dequeue();
                foreach(var next in GetNext(cur, board, n)){
                    if(next == n*n)
                        return steps + 1;
                    if(!visited[next]) {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
            }
            steps++;
        }
        return -1;
    }
    
    private List<int> GetNext(int cur, int[][] board, int n)
    {
        List<int> nextList = new List<int>();
        for(int i=1; i<=6; i++){
            var next = Math.Min(cur + i, n *n);
            
            int row = (next - 1) / n;
            int col = (next - 1) % n;
            
            if(row % 2 != 0)
                col = n - 1 - col;
            row = n - 1 - row;
            
            if(board[row][col] > 0)
                next = board[row][col];
            nextList.Add(next);
            if(next == n * n)
                break;
        }
        return nextList;
    }
}