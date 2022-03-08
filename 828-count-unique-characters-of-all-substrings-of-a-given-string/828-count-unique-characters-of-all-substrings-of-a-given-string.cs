/*
// - Brute Force: O(n^2 * n) ==> O(n^3)
// - sum(f(i))
// f(i) ==> number of string that s[i] is unique
// How to compute f(i)?
//   ABC
  
//   XXX B XXXXX B XXX B XX
             m      n
               For second B = m * n
// Trick here from Lee's Solution, maintain last two position of the given char
 ex: B found at 3 6 9
    ==>For First B,  f(B) = (6 - 3) * (3 - (-1))
    ==>For Second B,  f(B) = (9 - 6) * (6 - 3)
    ==>For Third B,  f(B) = (N - 9) * (9 - 6)
*/

public class Solution {
    public int UniqueLetterString(string s) {
        int N = s.Length;
        
        int[][] last2Occurences = new int[26][];
        
        for(int i=0; i < 26; i++){
            last2Occurences[i] = new []{-1, -1};
        }
        
        int res = 0;
        for(int i=0; i < N; i++){
            var c = s[i] - 'A';
            var cur = last2Occurences[c];
            
            int m = cur[1] - cur[0];
            int n = i - cur[1];
            
            res += m * n;
            last2Occurences[c] = new[]{cur[1], i};
        }
        
        for(int i=0; i <26; i++){
            var cur = last2Occurences[i];
            
            int m = cur[1] - cur[0];
            int n = N - cur[1];
            
            res += m * n;
        }
        return res;
    }
}