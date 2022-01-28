public class WordDictionary {
    TrieNode root;
    
    public WordDictionary() {
        root = new TrieNode('*');
    }
    
    public void AddWord(string word) {
        var trav = root;
        for(int i=0; i<word.Length; i++){
            int cur = word[i] - 'a';
            if(trav.Children[cur] == null){
                trav.Children[cur] = new TrieNode(word[i]);
            }
            trav = trav.Children[cur];
        }
        trav.IsWord = true;
    }
    
    public bool Search(string word) {
        return Search(word, 0, root);
    }
    private bool Search(string word, int start, TrieNode trav)
    {
        if(start == word.Length && trav.IsWord)
            return true;
        for(int i=start; i < word.Length; i++){
            if(word[i] == '.'){
                foreach(var child in trav.Children){
                    if(child != null && Search(word, i+1, child)) 
                        return true;
                }
                return false;
            }else{
                int cur = word[i] - 'a';
                if(trav.Children[cur] != null)
                    trav = trav.Children[cur];
                else
                    return false;
            }
        }
        return trav.IsWord;
    }
    
    public class TrieNode {
        public char letter;
        public TrieNode[] Children;
        public bool IsWord;
        
        public TrieNode(char c){
            letter = c;
            Children = new TrieNode[26];
        }
    }
}



/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */