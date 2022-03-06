public class FileSystem {
    
    public class FileNode {
        public string Name;
        public Dictionary<string, FileNode> Childs;
        public bool IsDirectory;
        public string Content;
        
        public FileNode(string name, bool isDirectory){
            this.Name = name;
            this.IsDirectory = isDirectory;
            this.Childs = new Dictionary<string, FileNode>();
        }
    }

    FileNode root;
    public FileSystem() {
        root = new FileNode("/", true);
    }
    
    public IList<string> Ls(string path) {
        var node = GetFileNode(path, false);
        
        if(node == null)
            return new List<string>();
        
        if(!node.IsDirectory){
            return new List<string>{ node.Name };
        }
        
        var list = node.Childs;
        return list.Keys.OrderBy(x => x).ToList();
    }
    
    public void Mkdir(string path) {
        var node = GetFileNode(path, true);
        
    }
    
    public void AddContentToFile(string filePath, string content) {
        var node = GetFileNode(filePath, true);
        node.IsDirectory = false;
        node.Content += content;
    }
    
    public string ReadContentFromFile(string filePath) {
        var node = GetFileNode(filePath, false);
        if(node != null && !node.IsDirectory)
            return node.Content;
        return string.Empty;
    }
    
    public FileNode GetFileNode(string path, bool create){
        var tokens = path.Split("/", StringSplitOptions.RemoveEmptyEntries);
        var trav = root;
        
        for(int i=0; i<tokens.Length; i++){
            var cur = tokens[i];
            if(!trav.Childs.ContainsKey(cur)){
                if(!create)
                    return null;
                trav.Childs.Add(cur, new FileNode(cur, true));
            }
            trav = trav.Childs[cur];
        }
        
        return trav;
    }
}

/**
 * Your FileSystem object will be instantiated and called as such:
 * FileSystem obj = new FileSystem();
 * IList<string> param_1 = obj.Ls(path);
 * obj.Mkdir(path);
 * obj.AddContentToFile(filePath,content);
 * string param_4 = obj.ReadContentFromFile(filePath);
 */