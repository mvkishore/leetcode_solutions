public class Solution {
    public string RemoveDuplicates(string s, int k) {
        Stack<char> seenChars = new Stack<char>();
        Stack<int> seenCounts = new Stack<int>();
        
        for(int i=0; i< s.Length; i++){
            if(seenChars.Count > 0 && seenChars.Peek() == s[i])
            {
                var c = seenCounts.Pop();
                c++;
                if(c == k)
                    seenChars.Pop();
                else
                    seenCounts.Push(c);
                continue;
            }
            seenChars.Push(s[i]);
            seenCounts.Push(1);
        }
        
        StringBuilder sb = new StringBuilder();
        while(seenChars.Count > 0){
            var count = seenCounts.Pop();
            var c = seenChars.Pop();
            while(count > 0){
                sb.Insert(0, c);
                count --;
            }
        }
        return sb.ToString();
    }
}

