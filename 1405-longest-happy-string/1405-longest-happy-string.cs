public class Solution {
    public string LongestDiverseString(int a, int b, int c) {
        SortedSet<(int cnt, char c)> heap = new SortedSet<(int cnt, char c)>();
        
        if(a > 0)
            heap.Add((a, 'a'));
        if(b > 0)
            heap.Add((b, 'b'));
        if(c > 0)
            heap.Add((c, 'c'));
        
        StringBuilder sb = new StringBuilder();
        char prev = '*';
        while(heap.Count > 0){
            var max = PopMax(heap);
            int added = 0;
            
            if(max.c != prev){
                added = AppendToString(max, sb, true);
            }else if(heap.Count > 0){
                var prevMax = max;
                
                max = PopMax(heap);
                added = AppendToString(max, sb, false);
                
                heap.Add(prevMax);
            }else break;
            
            prev = max.c;
            max.cnt -= added;
            if(max.cnt > 0)
                heap.Add(max);
        }
        return sb.ToString();
    }
    
    private int AppendToString((int cnt, char c) max, StringBuilder sb, bool isMax)
    {
        sb.Append(max.c);
        if(isMax && max.cnt > 1){
            sb.Append(max.c);
            return 2;
        }
        return 1;
    }
    
    private (int cnt, char c) PopMax(SortedSet<(int cnt, char c)> heap)
    {
        var max = heap.Max;
        heap.Remove(max);
        return max;
    }
}