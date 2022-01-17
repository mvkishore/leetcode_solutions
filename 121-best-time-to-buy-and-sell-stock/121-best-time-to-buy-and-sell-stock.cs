public class Solution {
    public int MaxProfit(int[] prices) {
        int buy = int.MaxValue;
        int sell = 0;
        
        for(int i=0; i<prices.Length; i++){
            buy = Math.Min(buy, prices[i]);
            sell = Math.Max(sell, prices[i] - buy);
        }
        
        return sell;
    }
}