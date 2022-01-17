public class Solution {
    public int MaxProfit(int[] prices) {
        int buy = int.MinValue;
        int sell = 0;
        
        for(int i=0; i<prices.Length; i++){
            buy = Math.Max(buy, -prices[i]);
            sell = Math.Max(sell, buy + prices[i]);
        }
        
        return sell;
    }
}