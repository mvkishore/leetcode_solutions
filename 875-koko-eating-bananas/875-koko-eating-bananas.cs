/*
 piles = [3,6,7,11]
 
 k=6
 
 1+1+2+3 = 
 
 h=8
 
 k=1
 
 k=11
[27,15, 10,7, 7, 5, .. . . ]

*/

public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int n = piles.Length, low = 1, hi = piles.Max();
        
        while(low < hi){
            int mid = low + (hi - low) / 2;
            
            int hrs = GetHoursToEat(piles, mid);
            if(hrs <= h)
                hi = mid;
            else
                low = mid + 1;
        }
        return low;
    }
    private int GetHoursToEat(int[] piles, int k)
    {
        int hours = 0;
        for(int i=0; i<piles.Length; i++)
            hours += (int)Math.Ceiling(piles[i] * 1.0/ k);
        return hours;
    }
}