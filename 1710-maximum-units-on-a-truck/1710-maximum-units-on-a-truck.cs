public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        Array.Sort(boxTypes, (a, b) => b[1] - a[1]);
        int units = 0, i = 0;
        while(truckSize > 0 && i < boxTypes.Length){
            int quantity = boxTypes[i][0];
            int unit = boxTypes[i][1];
            
            if(quantity < truckSize)
            {
                units += (quantity * unit);
                truckSize -= quantity;
            } else {
                units += (truckSize * unit);
                truckSize = 0;
            }
            i++;
        }
        return units;
    }
}

     
