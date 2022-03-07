public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        int n = intervals.Length;
        (int val, bool start)[] times = new (int val, bool start)[2 * n];
        
        int i=0;
        foreach(var interval in intervals){
            times[i++] = (interval[0], true);
            times[i++] = (interval[1], false);
        }
        
        Array.Sort(times, (a, b) => a.val == b.val ? 
                                    (a.start == b.start ? 
                                        0 : (a.start) ? 
                                            1 : -1) 
                                    : a.val - b.val);
        
        int rooms = 0, minRooms = 0;
        for(i = 0; i<2*n; i++){
            if(times[i].start){
                rooms++;
                if(rooms == 2)
                    Console.WriteLine(times[i].val);
            } else {
                rooms--;  
            }
            minRooms = Math.Max(minRooms, rooms);
        }
        return minRooms;
    }
}