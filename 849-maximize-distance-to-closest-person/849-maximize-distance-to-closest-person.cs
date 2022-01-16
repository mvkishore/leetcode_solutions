
public class Solution {
    public int MaxDistToClosest(int[] seats) {
        int n = seats.Length, i=0;
        while(i < n && seats[i] != 1)
            i++;
        int leadDis = i;
        
        i = n - 1;
        while(i >= 0 && seats[i] != 1)
            i--;
        
        int trailDis = n - i - 1;
        int lastOneIdx = i;
            
        int count = 0, midDis = 0;
        for(i=leadDis + 1; i < lastOneIdx; i++){
            if(seats[i] == 1){
                midDis = Math.Max(midDis, (int) Math.Ceiling(count / 2.0));
                count = 0;
            }else
                count++;
        }
        
        if(count > 0)
            midDis = Math.Max(midDis, (int) Math.Ceiling(count / 2.0));
        
        return Math.Max(midDis, Math.Max(leadDis, trailDis));
    }
}