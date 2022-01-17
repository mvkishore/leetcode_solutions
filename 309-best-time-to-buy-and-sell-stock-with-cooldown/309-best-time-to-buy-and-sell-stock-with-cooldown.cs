public class Solution {
    public int MaxProfit(int[] prices) {
        int buy = int.MinValue;
        int sell = 0;
        int prev_sell = 0;
        
        foreach(var price in prices){
            int oldSell = sell;
            buy = Math.Max(buy, prev_sell - price);
            sell = Math.Max(sell, buy + price);
            prev_sell = oldSell;
        }
        return sell;
    }
}