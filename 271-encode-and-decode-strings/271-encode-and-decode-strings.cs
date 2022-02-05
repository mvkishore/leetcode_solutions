public class Codec {

    string delimeter = @"`^-^`";
    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs) {
        return string.Join(delimeter, strs);
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s) {
        return s.Split(delimeter).ToList();
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));