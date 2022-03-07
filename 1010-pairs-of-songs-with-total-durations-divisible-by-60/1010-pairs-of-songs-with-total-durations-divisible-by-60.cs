public class Solution {
    public int NumPairsDivisibleBy60(int[] time) {
        int[] reminders = new int[60];
        
        int count = 0;
        foreach(var t in time) {
            count += reminders[60 - (t % 60 == 0 ? 60 : t % 60)];
            reminders[t % 60]++;
        }
        
        return count;
    }
}
