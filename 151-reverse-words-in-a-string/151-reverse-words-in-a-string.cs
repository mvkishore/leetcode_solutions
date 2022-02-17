public class Solution {
    public string ReverseWords(string s) {
        var sArray = s.Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToArray();
        Array.Reverse(sArray);
        return string.Join(" ", sArray);
    }
}

