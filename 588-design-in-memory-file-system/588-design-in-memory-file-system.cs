public class FileSystem {
    public class FileNode {
        public string Name;
        public Dictionary<string, FileNode> childs;
        public bool IsDirectory;
        public string Content;
        
        public FileNode(string name, bool isDirectory)
        {
            this.Name = name;
            this.IsDirectory = isDirectory;
            childs = new Dictionary<string, FileNode>();
        }
    }
    
    FileNode root;
    
    public FileSystem() {
        root = new FileNode("/", true);
    }
    
    public IList<string> Ls(string path) {
        var directories = path.Split("/");
        
        var trav = root;
        for(int i=0; i < directories.Length; i++){
            var cur = directories[i];
            if(trav.childs.ContainsKey(cur))
                trav = trav.childs[cur];
        }
        
        if(!trav.IsDirectory)
            return new List<string>(){trav.Name};
        
        var res = new List<string>();
        foreach(var name in trav.childs.Keys)
            res.Add(name);
        res.Sort();
        return res;
    }
    
    public void Mkdir(string path) {
        GetDir(path);
    }
    
    private FileNode GetDir(string path){
        var directories = path.Split("/");
        var trav = root;
        for(int i=0; i<directories.Length; i++){
            var cur = directories[i];
            if(!trav.childs.ContainsKey(cur))
                trav.childs.Add(cur, new FileNode(cur, true));
                
            trav = trav.childs[cur];
        }
        return trav;
    }
    
    public void AddContentToFile(string filePath, string content) {
        var indx = filePath.LastIndexOf("/");
        var path = filePath.Substring(0, indx);
        var node = GetDir(path);
        var fileName = filePath.Substring(indx + 1);
        
        if(!node.childs.ContainsKey(fileName))
            node.childs.Add(fileName, new FileNode(fileName, false));
        
        var fileNode = node.childs[fileName];
        
        fileNode.Content = fileNode.Content + content;
    }
    
    public string ReadContentFromFile(string filePath) {
        var indx = filePath.LastIndexOf("/");
        var path = filePath.Substring(0, indx);
        var fileName = filePath.Substring(indx + 1);
        
        var node = GetDir(path);
        var fileNode = node.childs[fileName];
        
        return fileNode.Content;
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