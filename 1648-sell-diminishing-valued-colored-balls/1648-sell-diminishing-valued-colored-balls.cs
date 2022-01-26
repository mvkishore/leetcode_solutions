public class Solution {
    public int MaxProfit(int[] inventory, int orders) {
        Array.Sort(inventory);
        long res = 0;
        int colors = 1;
        long MOD = 1000000007;
        for(int i = inventory.Length - 1; i>=0; i--, colors++){
            long cur = inventory[i], prev = i > 0 ? inventory[i-1] : 0;
            long rounds = Math.Min(orders / colors, cur - prev);
            orders -= (int)rounds * colors;
            
            long soldBalls = GetTotalSold(cur, cur - rounds, colors);
            res = (res + soldBalls) % MOD;
            if(cur - prev > rounds){
                res = (res + orders * (cur - rounds)) % MOD;
                break;
            }
        }
        return (int)res;
    }
    
    private long GetTotalSold(long cur, long x, int colors)
    {
        return (cur * (cur + 1) - x * (x+1)) / 2 * colors;
    }
}

    
    