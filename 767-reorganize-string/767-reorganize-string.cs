public class Solution {
    public string ReorganizeString(string s) {
        int[] counter = new int[26];
        foreach(var c in s)
            counter[c - 'a']++;
        SortedSet<(int count, char c)> heap = new SortedSet<(int count, char c)>();
        
        for(int i=0; i<26;i++){
            if(counter[i] > 0)
                heap.Add((counter[i], (char)(i + 'a')));
        }
        StringBuilder sb = new StringBuilder();
        char prev = '*';
        
        while(heap.Count > 0){
            var max = heap.Max;
            heap.Remove(max);
            if(prev != max.c){
                sb.Append(max.c);
            }else if(heap.Count > 0){
                var curMax = max;
                max = heap.Max;
                heap.Remove(max);
                
                sb.Append(max.c);
                heap.Add(curMax);
            }else return string.Empty;
            
            max.count -= 1;
            prev = max.c;
            if(max.count > 0)
                heap.Add(max);
        }
        return sb.ToString();
    }
}