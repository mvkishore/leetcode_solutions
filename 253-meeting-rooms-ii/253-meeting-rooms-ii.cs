public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        int n = intervals.Length;
        int[] starts = new int[n];
        int[] ends = new int[n];
        
        for(int i=0; i<n; i++){
            starts[i] = intervals[i][0];
            ends[i] = intervals[i][1];
        }
        
        Array.Sort(starts);
        Array.Sort(ends);
        
        int sI = 0, eI = 0, rooms = 0;
        int minRooms = 0;
        while(sI < n){
            if(starts[sI] < ends[eI]){
                rooms++;
                minRooms = Math.Max(minRooms, rooms);
                sI++;
            }else{
                eI++;
                rooms--;
            }
        }
        
        return minRooms;
    }
}