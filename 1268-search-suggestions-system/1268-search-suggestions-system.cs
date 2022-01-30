public class Solution {
    public class TrieNode {
        public Dictionary<char, TrieNode> Childrens;
        public string Word;
        
        public TrieNode()
        {
            Childrens = new Dictionary<char, TrieNode>();
        }
    }
    
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        var root = BuildTrie(products);
        IList<IList<string>> res = new List<IList<string>>();
        
        for(int i=0; i<searchWord.Length;i++){
            root = SearchWord(searchWord[i], root, res);
            if(root == null)
                res.Add(new List<string>());
        }
        return res;
    }
    //root = 'm'
    private TrieNode SearchWord(char c, TrieNode root, IList<IList<string>> res)
    {
        if(root == null)
            return root;
        
        if(root.Childrens.ContainsKey(c))
            root = root.Childrens[c];
        else
            return null;
        
        IList<string> list = new List<string>();
        GetWords(root, list);
        res.Add(list);
        
        return root;
            
    }
    
    private void GetWords(TrieNode node, IList<string> res)
    {
        if(res.Count == 3)
            return;
        
        if(!string.IsNullOrEmpty(node.Word))
            res.Add(node.Word);
        
        if(node.Childrens.Count == 0)
            return;
        
        for(char c='a'; c<= 'z'; c++){
            if(node.Childrens.ContainsKey(c))
            {
                GetWords(node.Childrens[c], res);
                if(res.Count == 3)
                    return;
            }
        }
    }
    
    private TrieNode BuildTrie(string[] products)
    {
        var root = new TrieNode();
        foreach(var word in products)
        {
            AddWord(root, word);
        }
        return root;
    }
    
    private void AddWord(TrieNode root, string word)
    {
        var trav = root;
        foreach(var c in word)
        {
            if(!trav.Childrens.ContainsKey(c))
                trav.Childrens.Add(c, new TrieNode());
            trav = trav.Childrens[c];
        }
        
        trav.Word = word;
    }
}