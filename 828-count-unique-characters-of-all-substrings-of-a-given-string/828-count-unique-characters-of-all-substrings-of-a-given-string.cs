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
        int[][] last2Indices = new int[26][];
        int res = 0;
        
        for(int i=0; i<26; i++)
            last2Indices[i] = new int[]{-1, -1};
        
        for(int i=0; i<s.Length; i++){
            var c = s[i] - 'A';
            var lastOccurances = last2Indices[c];
            
            int m = lastOccurances[1] - lastOccurances[0];
            int n = i - lastOccurances[1];
            
            res += m *n;
            last2Indices[c] = new []{lastOccurances[1], i};
        }
        
        int N = s.Length;
        for(int i=0; i<26; i++){
            var lastOccurances = last2Indices[i];
            int m = (lastOccurances[1] - lastOccurances[0]);
            int n = (N - lastOccurances[1]);
            res += m *n;
        }
        return res;
    }
}

   
