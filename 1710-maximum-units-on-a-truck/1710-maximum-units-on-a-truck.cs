public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        Array.Sort(boxTypes, (a, b) => b[1] - a[1]);
        int units = 0;
        for(int i=0; i< boxTypes.Length; i++){
            int quantity = boxTypes[i][0];
            int unit = boxTypes[i][1];
            if(quantity < truckSize)
            {
                units += (quantity * unit);
                truckSize -= quantity;
            }else{
                units += (truckSize * unit);
                break;
            }
        }
        return units;
    }
}

     
