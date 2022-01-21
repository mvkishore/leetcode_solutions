public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int tank = 0, n = cost.Length, minTank = int.MaxValue;
        int lastStation = -1;
        
        for(int i=0; i<n; i++){
            tank += gas[i] - cost[i];
            if(tank < minTank)
            {
                minTank = tank;
                lastStation = i;
            }
        }
        
        if(tank < 0) return -1;
        
        return (lastStation + 1) % n;
    }
}