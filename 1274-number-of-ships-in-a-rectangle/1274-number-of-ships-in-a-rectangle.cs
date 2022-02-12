/**
 * // This is Sea's API interface.
 * // You should not implement it, or speculate about its implementation
 * class Sea {
 *     public bool HasShips(int[] topRight, int[] bottomLeft);
 * }
 * 
 
 Algo - Divide & Conquer
 
 */

class Solution {
    public int CountShips(Sea sea, int[] topRight, int[] bottomLeft) {
        if(topRight[0] < bottomLeft[0] || topRight[1] < bottomLeft[1])
            return 0;
        if(!sea.HasShips(topRight, bottomLeft))
            return 0;
        
        if(topRight[0] == bottomLeft[0] && topRight[1] == bottomLeft[1])
            return 1;
        
        int midX = (topRight[0] + bottomLeft[0] + 1) / 2;
        int midY = (topRight[1] + bottomLeft[1] + 1) / 2;
        
        int rec1 = CountShips(sea, topRight, new int[]{midX, midY});
        int rec2 = CountShips(sea, new int[]{midX -1, topRight[1]} , new int[]{bottomLeft[0], midY});
        int rec3 = CountShips(sea, new int[]{midX - 1, midY - 1} , bottomLeft);
        int rec4 = CountShips(sea, new int[]{topRight[0], midY - 1} , new int[]{ midX, bottomLeft[1]});
        
        return rec1 + rec2 + rec3 + rec4;
    }
}