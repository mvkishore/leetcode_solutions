public class Solution {
    public int MaxProfit(int[] prices) {
        int buy1 = int.MaxValue, buy2 = int.MinValue, 
        profitAfterSell1 = 0, profitAfterSell2 =0;
        
        for(int i=0; i<prices.Length; i++){
            buy1 = Math.Min(buy1, prices[i]);
            profitAfterSell1 = Math.Max(profitAfterSell1, prices[i] - buy1);
            
            buy2 = Math.Max(buy2, profitAfterSell1 - prices[i]);
            profitAfterSell2 = Math.Max(profitAfterSell2, buy2 + prices[i]);
        }
        return profitAfterSell2;
    }
}