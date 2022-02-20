public class Solution {
    public string RepeatLimitedString(string s, int repeatLimit) {
        SortedSet<(char c, int cnt)> heap = new SortedSet<(char c, int cnt)>();
        
        int[] counter = new int[26];
        foreach(var c in s)
            counter[c-'a']++;
        
        for(int i=0;i<26; i++){
            if(counter[i] > 0)
                heap.Add(((char) (i+'a'), counter[i]));
        }
        
        StringBuilder sb = new StringBuilder();
        char prev =  '*';
        int count = 0;
        
        while(heap.Count > 0) {
            var max = heap.Max;
            heap.Remove(max);
            int cnt = 0;
            if(max.c != prev){
                cnt = Math.Min(repeatLimit, max.cnt);
            }else if(heap.Count > 0 ){
                var curMax = max;
                max = heap.Max;
                heap.Remove(max);
                heap.Add(curMax);
                cnt = 1;
            }else break;

            for(int i=0; i<cnt; i++)
                sb.Append(max.c);
            
            max.cnt -= cnt;
            prev = max.c;
            if(max.cnt > 0)
                heap.Add(max);
        }
        
        return sb.ToString();
    }
}