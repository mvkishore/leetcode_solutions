public class Solution {
    public string GetHint(string secret, string guess) {
        int n = secret.Length;
        int[] counter = new int[10];

        for(int i=0; i<n; i++) {
            if(secret[i] != guess[i])
                counter[secret[i] - '0']++;
        }
        
        int cows = 0, bulls = 0;
        for(int i=0; i<n;i++){
            if(secret[i] == guess[i]){
                bulls++;
            }else if(counter[guess[i] - '0'] > 0){
                counter[guess[i] - '0']--;
                cows++;
            }
        }
        
        return $"{bulls}A{cows}B";
    }
}