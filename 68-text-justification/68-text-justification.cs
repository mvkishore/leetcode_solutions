/*
    - collect the words that can be into the given line 
    - track the total spaces, apply even spaces between each word
    - apply spaces only at the end if it's the last line.

*/

public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth) {
        var res = new List<string>();
        
        int n = words.Length;
        int len = 0;
        List<string> content = new List<string>();
        
        foreach(var word in words){
            if(len + word.Length + content.Count <= maxWidth){
                len += word.Length;
                content.Add(word);
            } else {
                JustifyLine(content, maxWidth, len, res, false);
                content.Clear();
                content.Add(word);
                len = word.Length;
            }
        }
        JustifyLine(content, maxWidth, len, res, true);
        return res;
    }
    
    private void JustifyLine(List<string> content, int maxWidth, int contentLen, IList<string> res, bool isLast)
    {
        // Console.WriteLine(content[content.Count - 1]);
        int spaces = content.Count - 1;
        int totalSpaces = maxWidth - contentLen;
        
        if(spaces == 0){
            res.Add(AppendSpace(content[0], totalSpaces));
            return;
        }
        
        int avgSpace = totalSpaces / spaces;
        int rem = totalSpaces % spaces;
        // Console.WriteLine($"{contentLen} -- {maxWidth} -- {totalSpaces} -- {avgSpace} -- {spaces}");
        if(isLast){
            avgSpace = 1;
            rem = 0;
        }
        
        StringBuilder sb = new StringBuilder();
        foreach(var word in content){
            var w = AppendSpace(word, avgSpace);
            sb.Append(w);
            if(rem > 0){
                sb.Append(" ");
                rem--;
            }
        }
        if(isLast){
            res.Add(AppendSpace(sb.ToString().Trim(), totalSpaces - spaces));
            return;
        }
                    
        res.Add(sb.ToString().Trim());
    }
    
    private string AppendSpace(string word, int count)
    {
        StringBuilder sb = new StringBuilder(word);
        
        while(count-- > 0)
            sb.Append(" ");
        
        return sb.ToString();
    }
}