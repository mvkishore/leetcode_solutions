public class Solution {
    public int LengthLongestPath(string input) {
        Dictionary<int, int> levelLengths = new Dictionary<int, int>();
        levelLengths.Add(0, 0);
        int maxLen = 0;
        foreach(var s in input.Split("\n")){
            int level = s.LastIndexOf("\t") + 1;
            int len = s.Length - level;
            
            if(s.Contains(".")){
                maxLen = Math.Max(maxLen, levelLengths[level] + len);
            }else {
                levelLengths[level + 1] = levelLengths[level] + len + 1;
            }
        }
        return maxLen;
    }
}