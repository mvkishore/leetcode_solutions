public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        Stack<int> seen = new Stack<int>();
        int n = asteroids.Length;
        
        for(int i=0; i<n; i++){
            int cur = asteroids[i];
            
            bool skip = false;
            while(seen.Count > 0 && seen.Peek() > 0 && cur < 0){
                var right = seen.Pop();
                var left = Math.Abs(cur);
                if(right == left){
                    skip = true;
                    break;
                }
                if(right > left)
                    cur = right;
            }
            if(!skip)
                seen.Push(cur);
        }
        int[] res = new int[seen.Count];
        for(int i=seen.Count - 1; i>=0; i--){
            res[i] = seen.Pop();
        }
        return res;
    }
}