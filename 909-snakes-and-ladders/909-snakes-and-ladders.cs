public class Solution {
    public int SnakesAndLadders(int[][] board) {
        int n = board.Length;
        Dictionary<int, int> steps = new Dictionary<int, int>();
        steps.Add(1, 0);
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        
        while(queue.Count > 0){
            int size = queue.Count;
            for(int i=0; i < size; i++){
                int cur = queue.Dequeue();
                foreach(var next in GetNext(cur, board)){
                    
                    if(next == n*n)
                        return steps[cur] + 1;
                    
                    if(!steps.ContainsKey(next)){
                        steps.Add(next, steps[cur] + 1);
                        queue.Enqueue(next);
                    }
                }
            }
        }
        return -1;
    }
    
    public List<int> GetNext(int cur, int[][] board)
    {
        int n = board.Length;
        var nextList = new List<int>();
        
        for(int i=1; i<= 6; i++) {
            int nxt = Math.Min(cur + i, n *n);
            
            int row = (nxt - 1) / n;
            int col = (nxt - 1) % n;
            
            //Console.WriteLine($"{nxt} ==> {row}, {col} : Org");
            
            if(row % 2 != 0)
                col = n - 1 - col;
            row = n - 1 - row;
            
           // Console.WriteLine($"{nxt} ==> {row}, {col}");

            if(board[row][col] > 0)
                nxt = board[row][col];
            
            nextList.Add(nxt);
            if(nxt == n*n)
                break;
        }
        return nextList;
    }
}