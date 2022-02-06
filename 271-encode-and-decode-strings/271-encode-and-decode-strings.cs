public class Codec {

    string delimeter = @"$";
    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs) {
        var str = string.Join("", strs);
        StringBuilder sb = new StringBuilder();
        foreach(var s in strs){
            sb.Append(s.Length);
            sb.Append(" ");
        }
        sb.Length--;
        sb.Append(delimeter);
        sb.Append(str);
        return sb.ToString();
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s) {
        var strs = new List<string>();
        var pos = s.IndexOf(delimeter);
        var subStr = s.Substring(0, pos);
        var lengths = subStr.Split(" ");
        int j=0, i = pos + 1;
        
        while(i < s.Length) {
            int len = Convert.ToInt32(lengths[j++]);
            if(len == 0)
                strs.Add(string.Empty);
            else
                strs.Add(s.Substring(i, len));
            i += len;
        }
        
        while(j < lengths.Length){
            strs.Add(string.Empty);
            j++;
        }
        return strs;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));