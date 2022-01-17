public class Solution {
    public int MaxProfit(int k, int[] prices) {
        int n = prices.Length;
        
        if(k > n/2){
            int profit = 0;
            for(int i=1; i<n; i++)
                if(prices[i - 1] < prices[i])
                    profit+= prices[i] - prices[i-1];
            
            return profit;
        }
        
        int[] buy = Enumerable.Repeat(int.MinValue, k+1).ToArray();
        int[] sell = new int[k+1];
        
        foreach(var price in prices){
            for(int j=1; j<=k; j++){
                buy[j] = Math.Max(buy[j], sell[j-1] - price);
                sell[j] = Math.Max(sell[j], buy[j] + price);
            }
        }
        return sell[k];
    }
}