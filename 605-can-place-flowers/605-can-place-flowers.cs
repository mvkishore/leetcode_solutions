public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        int l = flowerbed.Length;
        if(n ==0)
            return true;
        
        if(l == 1)
            return flowerbed[0] == 0;
        
        int i=0;
        while(i < l){
            if(flowerbed[i] == 0)
            {
                if((i == 0 && flowerbed[i+1] == 0)
                   || (i == l - 1 && flowerbed[i-1] == 0)
                   || i > 0 && i < l-2 && flowerbed[i+1] == 0 && flowerbed[i-1] == 0)
                {
                    flowerbed[i] = 1;
                    n--;    
                    if(n == 0)
                        return true;
                }
            }
            i++;
        }
        
        return false;
    }
}