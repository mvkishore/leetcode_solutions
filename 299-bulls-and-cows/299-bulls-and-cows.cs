public class Solution {
    public string GetHint(string secret, string guess) {
        int n = secret.Length;
        HashSet<int> bulls = new HashSet<int>();
        int[] counter = new int[10];
        
        for(int i=0; i<n; i++)
        {
            if(secret[i] == guess[i])
                bulls.Add(i);
        }
        
        for(int i=0; i<n; i++) {
            if(!bulls.Contains(i))
                counter[secret[i] - '0']++;
        }
        
        int cows = 0;
        for(int i=0; i<n;i++){
            if(!bulls.Contains(i) && counter[guess[i] - '0'] > 0){
                counter[guess[i] - '0']--;
                cows++;
            }
        }
        
        return $"{bulls.Count}A{cows}B";
    }
}