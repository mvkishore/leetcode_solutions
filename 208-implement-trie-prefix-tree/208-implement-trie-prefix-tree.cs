public class Trie {
    class TrieNode {
        public TrieNode[] child;
        public bool IsWord;
        
        public TrieNode()
        {
            child = new TrieNode[26];
        }
    }
    private TrieNode root;

    public Trie() {
        root = new TrieNode();
    }
    
    public void Insert(string word) {
        var trav = root;
        foreach(var c in word){
            if(trav.child[c - 'a'] == null){
                trav.child[c - 'a'] = new TrieNode();
            }
            trav = trav.child[c - 'a'];
        }
        trav.IsWord = true;
    }
    
    public bool Search(string word) {
        var trav = GetNode(word);
        return trav != null && trav.IsWord;
    }
    private TrieNode GetNode(string word)
    {
        var trav = root;
        foreach(var c in word){
            if(trav.child[c - 'a'] == null)
                return null;
            trav = trav.child[c - 'a'];
        }
        return trav;
    }
    public bool StartsWith(string prefix) {
        var trav = GetNode(prefix);
        return trav != null;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */