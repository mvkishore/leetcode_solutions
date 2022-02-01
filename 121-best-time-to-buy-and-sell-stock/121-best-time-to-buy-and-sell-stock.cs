public class Solution {
    public int MaxProfit(int[] prices) {
        int buy = int.MaxValue;
        int profit = 0;
        
        for(int i=0; i<prices.Length; i++)
        {
            buy = Math.Min(buy, prices[i]);
            profit = Math.Max(profit, prices[i] - buy);
        }
        
        return profit;
    }
}