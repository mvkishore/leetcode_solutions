public class Solution {
    public bool IsRobotBounded(string instructions) {
        HashSet<(int, int)> seen = new HashSet<(int, int)>();
        
        (int x, int y) current = (0, 0);
        int dir = 0;
        
        foreach(var i in instructions){
            var next = GetNextPosition(current, dir, i);
            current = (next.x, next.y);
            dir = next.dir;
        }
        return (current.x == 0 && current.y ==0 ) || dir != 0 ;
    }
    
    private (int x, int y, int dir) GetNextPosition((int x, int y)current, int dir, char instruction){
        var dirs = new int[][]{ new [] {0, 1}, new [] {1, 0}, new [] {0, -1}, new[]{-1, 0} };
        
        switch(instruction){
            case 'R':
                dir = (dir + 1) % 4;
                break;
            case 'L':
                dir = (dir + 3) % 4;
                break;
            default:
                var nextMove = dirs[dir];
                current.x += nextMove[0];
                current.y += nextMove[1];
                break;
        }
        
        return (current.x, current.y, dir);
    }
}